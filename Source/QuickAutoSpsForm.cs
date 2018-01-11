//Copyright (c) 2017-present, Firstec, Inc.

//This library is free software; you can redistribute it and/or
//modify it under the terms of the GNU Lesser General Public
//License as published by the Free Software Foundation; either
//version 2.1 of the License, or (at your option) any later version.

//This library is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//Lesser General Public License for more details.

//You should have received a copy of the GNU Lesser General Public
//License along with this library; if not, write to the Free Software
//Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301
//USA

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;



namespace FileInfoExtractor
{
   

    public partial class QuickAutoSpsForm : Form
    {
        Dictionary<string, string> extensionMapToClass = null;
        Dictionary<string, string> subStringMapToClass = null;

        private Crc32 _crc32 = new Crc32();

        private String exeFilePath = "sps_auto_temp1231231231.hwp";

        private String scrFilePath = "sps_auto_temp1231231232.hwp";

        public QuickAutoSpsForm()
        {
            InitializeComponent();
        }

        private void extractDirPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            bool autoPathDel = false;

            dialog.ShowDialog();

            tbExtractPath.Text = dialog.SelectedPath;

            if(  tbExtractPath.Text.StartsWith("c:\\") )
            {
                tbPathDel.Text = "c:\\";
                autoPathDel = true;
            }

            if (tbExtractPath.Text.StartsWith("C:\\") )
            {
                tbPathDel.Text = "C:\\";
                autoPathDel = true;
            }

            if (!autoPathDel)
                tbPathDel.Text = "";

        }

        private void resultDirPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            dialog.ShowDialog();

            tbResultPath.Text = dialog.SelectedPath;


        }




        private void extractExcel()
        {
            try
            {

                DirectoryInfo dirInfo = new DirectoryInfo(tbExtractPath.Text);

                IEnumerable<FileSystemInfo> infos = dirInfo.EnumerateFileSystemInfos("*", SearchOption.AllDirectories);

                string checkSumCode = "";
                StringBuilder itemContents = new StringBuilder();

                int i = 1;
                int row = 1;

                extractDirPath.Enabled = false;
                resultDirPath.Enabled = false;
                startExtract.Enabled = false;
                close.Enabled = false;
                btDisplayResult.Visible = false;

                pbProgress.Visible = true;
                lbFile.Text = "";
                lbFile.Visible = true;


                string resultPath = Path.Combine(new string[] { tbResultPath.Text, tbResultName.Text });

                if (System.IO.File.Exists(resultPath))
                {
                    System.IO.File.Delete(resultPath);
                }

                Excel.Application oXL;
                Excel._Workbook oWB;
                Excel._Worksheet oSheet;

                //Start Excel and get Applicatio  n object.
                oXL = new Excel.Application();
                oXL.DisplayAlerts = false;

                //Get a new workbook.
                oWB = (Excel._Workbook)(oXL.Workbooks.Add());
                oSheet = (Excel._Worksheet)oWB.ActiveSheet;


                //Add table headers going cell by cell.
                if (rbSrcTypeExe.Checked == true)
                {
                    oSheet.Cells[row, 1] = "구 분";
                    oSheet.Cells[row, 2] = "순번";
                    oSheet.Cells[row, 3] = "파일명";
                    oSheet.Cells[row, 4] = "버전";
                    oSheet.Cells[row, 5] = "크기\n(Byte)";
                    oSheet.Cells[row, 6] = "첵섬";
                    oSheet.Cells[row, 7] = "수정일";
                    oSheet.Cells[row, 8] = "부품번호";
                    oSheet.Cells[row, 9] = "기능 설명";
                }
                else
                {
                    oSheet.Cells[row, 1] = "순번";
                    oSheet.Cells[row, 2] = "파일명";
                    oSheet.Cells[row, 3] = "버전";
                    oSheet.Cells[row, 4] = "크기\n(Byte)";
                    oSheet.Cells[row, 5] = "첵섬";
                    oSheet.Cells[row, 6] = "생성일자";
                    oSheet.Cells[row, 7] = "라인수";
                    oSheet.Cells[row, 8] = "기능 설명";
                }


                row++;

                string lastDirectoryName = "";
                string strExeNumber = "";
                string strLibNumber = "";
                int exeNumberIndex = 1;
                int libNumberIndex = 1;

                foreach (FileSystemInfo info in infos)
                {

                    if (info.Attributes.HasFlag(FileAttributes.Directory) || info.Attributes.HasFlag(FileAttributes.Hidden))
                    {
                        continue;
                    }

                    FileInfo fileInfo = new FileInfo(info.FullName);

                    // 상태바에 처리 데이터 이름 출력
                    lbFile.Text = info.Name;

                    // 경로 변경 시 경로 정보
                    if (fileInfo.DirectoryName != lastDirectoryName)
                    {

                        String path;


                        if ( tbPathDel.Text != String.Empty &&  fileInfo.DirectoryName.IndexOf(tbPathDel.Text) >= 0  ) // 경로에 사용자가 삭제할 경로문자가 존재하는 경우
                        {
                            path = string.Format(tbPathHead.Text + fileInfo.DirectoryName.Replace(tbPathDel.Text, ""  ) );

                        }
                        else
                        {
                            path = string.Format(tbPathHead.Text + fileInfo.DirectoryName);

                        }

                        if (cbUseLower.Checked)
                            path = path.ToLower();
                        else
                            path = path.ToUpper();

                        oSheet.Cells[row, 1] = path;


                        if (rbSrcTypeExe.Checked == true)
                        {
                            oSheet.Range[oSheet.Cells[row, 1], oSheet.Cells[row, 9]].Merge(true);
                        }
                        else
                        {
                            oSheet.Range[oSheet.Cells[row, 1], oSheet.Cells[row, 8]].Merge(true);
                        }


                        Excel.Range PathLine = (Excel.Range)oSheet.Rows[row + 1];
                        PathLine.Insert();

                        row++;

                        lastDirectoryName = fileInfo.DirectoryName;
                    }



                    // 체크섬
                    StringBuilder hashCodeString = new StringBuilder();

                    byte[] srcContents = File.ReadAllBytes(info.FullName);

                    byte[] hashCode = _crc32.ComputeHash(srcContents);

                    for (int index = 0; index < hashCode.Length; index++)
                    {
                        hashCodeString.Append(hashCode[index].ToString("x2"));
                    }

                    checkSumCode = hashCodeString.ToString();


                    // 생성일자


                    // 라인 수
                    string[] lines = null;
                    if (info.Extension == ".cs" || info.Extension == ".c" || info.Extension == ".h" || info.Extension == ".cpp" || info.Extension == ".txt" || info.Extension == ".csproj"
                        || info.Extension == ".sln" || info.Extension == ".user" || info.Extension == ".resx" || info.Extension == ".config" || info.Extension == ".settings"
                        || info.Extension == ".wpj" || info.Extension == ".wsp" || info.Name == "Makefile")
                    {
                        lines = File.ReadAllLines(info.FullName);
                    }

                    // 조립
                    if (rbSrcTypeExe.Checked == true)
                    {
                        oSheet.Cells[row, 1] = GetFileClassName(fileInfo);
                        oSheet.Cells[row, 2] = i;
                        oSheet.Cells[row, 3] = info.Name;
                        oSheet.Cells[row, 4] = string.Format("'"+tbVersion.Text);
                        oSheet.Cells[row, 5] = string.Format("{0:n0}", fileInfo.Length);
                        oSheet.Cells[row, 6] = checkSumCode;
                        oSheet.Cells[row, 7] = string.Format("{0}.{1}.{2}", info.LastWriteTime.Year, info.LastWriteTime.Month, info.LastWriteTime.Day);

                        if (fileInfo.FullName.Contains("SYSTEM"))
                        {
                            oSheet.Cells[row, 8] = string.Format("'{0:D}E{1:D3}", tbLibNumberBase.Text, libNumberIndex++);
                        }
                        else
                        {
                            oSheet.Cells[row, 8] = string.Format("'{0:D}E{1:D3}", tbExeNumberbase.Text, exeNumberIndex++);
                        }

                        oSheet.Cells[row, 9] = "-";
                    }
                    else
                    {
                        oSheet.Cells[row, 1] = i;
                        oSheet.Cells[row, 2] = info.Name;
                        oSheet.Cells[row, 3] = string.Format("'" + tbVersion.Text);
                        oSheet.Cells[row, 4] = string.Format("{0:n0}", fileInfo.Length);
                        oSheet.Cells[row, 5] = checkSumCode;
                        oSheet.Cells[row, 6] = string.Format("{0}.{1}.{2}", info.CreationTime.Year, info.CreationTime.Month, info.CreationTime.Day);
                        oSheet.Cells[row, 7] = (lines == null ? "-" : string.Format("{0}", lines.Length + 1));
                        oSheet.Cells[row, 8] = "-";
                    }


                    Excel.Range Line = (Excel.Range)oSheet.Rows[row + 1];
                    Line.Insert();

                    checkSumCode = "";
                    i++;
                    row++;

                    System.Windows.Forms.Application.DoEvents();
                }

                oWB.SaveAs(resultPath, Excel.XlFileFormat.xlWorkbookNormal);
                oWB.Close();
                oXL.Quit();

                pbProgress.Visible = false;
                lbFile.Visible = false;
                btDisplayResult.Visible = true;
                MessageBox.Show((IWin32Window)this, "추출 완료");

                if (cbAutoRun.Checked)
                    btDisplayResult.PerformClick();

            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);

                MessageBox.Show(errorMessage, "Error");
            }
            finally
            {
                extractDirPath.Enabled = true;
                resultDirPath.Enabled = true;
                startExtract.Enabled = true;
                close.Enabled = true;

                pbProgress.Visible = false;
                lbFile.Visible = false;
            }


        }


        private void extractHwp()
        {


            try
            {

                String[] hwpInsertText = new String[9];

                String[] hwpInsertTextCode = new String[8];

                DirectoryInfo dirInfo = new DirectoryInfo(tbExtractPath.Text);

                IEnumerable<FileSystemInfo> infos = dirInfo.EnumerateFileSystemInfos("*", SearchOption.AllDirectories);

                string checkSumCode = "";
                StringBuilder itemContents = new StringBuilder();

                int i = 1;

                extractDirPath.Enabled = false;
                resultDirPath.Enabled = false;
                startExtract.Enabled = false;
                close.Enabled = false;
                btDisplayResult.Visible = false;

                pbProgress.Visible = true;
                lbFile.Text = "";
                lbFile.Visible = true;


                string resultPath = Path.Combine(new string[] { tbResultPath.Text, tbResultName.Text });

                if (System.IO.File.Exists(resultPath))
                {
                    System.IO.File.Delete(resultPath);
                }


                resourceCopy();// c# 리소스에서 한글 템플릿 파일 복사,  temp1,hwp,  temp2.hwp

                
                if (rbSrcTypeExe.Checked == true)
                {
                    axHwpCtrl1.Open(exeFilePath);

                }
                else
                {
                    axHwpCtrl1.Open(scrFilePath);  
 
                }

                axHwpCtrl1.MoveToField("table1_field1");


                string lastDirectoryName = "";
                int exeNumberIndex = 1;
                int libNumberIndex = 1;

                foreach (FileSystemInfo info in infos)
                {

                    if (info.Attributes.HasFlag(FileAttributes.Directory) || info.Attributes.HasFlag(FileAttributes.Hidden))
                    {
                        continue;
                    }

                    FileInfo fileInfo = new FileInfo(info.FullName);

                    // 상태바에 처리 데이터 이름 출력
                    lbFile.Text = info.Name;

                    // 경로 변경 시 경로 정보
                    if (fileInfo.DirectoryName != lastDirectoryName)
                    {
                        String path;

                        if (tbPathDel.Text != String.Empty && fileInfo.DirectoryName.IndexOf(tbPathDel.Text) >= 0) // 경로에 사용자가 삭제할 경로문자가 존재하는 경우
                        {
                            path = string.Format(tbPathHead.Text + fileInfo.DirectoryName.Replace(tbPathDel.Text, ""));
                        }
                        else
                        {
                            path = string.Format(tbPathHead.Text + fileInfo.DirectoryName);
                        }


                        if (cbUseLower.Checked)
                            path = path.ToLower();
                        else
                            path = path.ToUpper();


                        hwp_insertPath(path);
                            


                        lastDirectoryName = fileInfo.DirectoryName;
                    }



                    // 체크섬
                    StringBuilder hashCodeString = new StringBuilder();

                    byte[] srcContents = File.ReadAllBytes(info.FullName);

                    byte[] hashCode = _crc32.ComputeHash(srcContents);

                    for (int index = 0; index < hashCode.Length; index++)
                    {
                        hashCodeString.Append(hashCode[index].ToString("x2"));
                    }

                    checkSumCode = hashCodeString.ToString();


                    // 생성일자


                    // 라인 수
                    string[] lines = null;
                    if (info.Extension == ".cs" || info.Extension == ".c" || info.Extension == ".h" || info.Extension == ".cpp" || info.Extension == ".txt" || info.Extension == ".csproj"
                        || info.Extension == ".sln" || info.Extension == ".user" || info.Extension == ".resx" || info.Extension == ".config" || info.Extension == ".settings"
                        || info.Extension == ".wpj" || info.Extension == ".wsp" || info.Name == "Makefile")
                    {
                        lines = File.ReadAllLines(info.FullName);
                    }

                    // 조립
                    if (rbSrcTypeExe.Checked == true)
                    {
                        hwpInsertText[0] = GetFileClassName(fileInfo);
                        hwpInsertText[1] = i.ToString();
                        hwpInsertText[2] = info.Name;
                        hwpInsertText[3] = tbVersion.Text;
                        hwpInsertText[4] = string.Format("{0:n0}", fileInfo.Length);
                        hwpInsertText[5] = checkSumCode;
                        hwpInsertText[6] = string.Format("{0}.{1}.{2}", info.LastWriteTime.Year, info.LastWriteTime.Month, info.LastWriteTime.Day);


                        if (fileInfo.FullName.Contains("SYSTEM"))
                        {
                            hwpInsertText[7] = string.Format("{0:D}E{1:D3}", tbLibNumberBase.Text, libNumberIndex++);

                        }
                        else
                        {
                            hwpInsertText[7] = string.Format("{0:D}E{1:D3}", tbExeNumberbase.Text, exeNumberIndex++);

                        }
                        hwpInsertText[8] = "-";
           

                        hpw_insertData(hwpInsertText);
                    }
                    else
                    {

                        hwpInsertTextCode[0] = i.ToString();
                        hwpInsertTextCode[1] = info.Name;
                        hwpInsertTextCode[2] = tbVersion.Text;
                        hwpInsertTextCode[3] = string.Format("{0:n0}", fileInfo.Length);
                        hwpInsertTextCode[4] = checkSumCode;
                        hwpInsertTextCode[5] = string.Format("{0}.{1}.{2}", info.CreationTime.Year, info.CreationTime.Month, info.CreationTime.Day);
                        hwpInsertTextCode[6] = (lines == null ? "-" : string.Format("{0}", lines.Length + 1));
                        hwpInsertTextCode[7] = "-";


                        hpw_insertData(hwpInsertTextCode);

                    }

                    


                    checkSumCode = "";
                    i++;
        

                    System.Windows.Forms.Application.DoEvents();
                }


                //표의 마지막 라인 삭제
                hwp_end();
                
                if(cbTableHeaderSet.Checked)
                {
                    hwp_setHeaderCell(); // 제목 셀 반복 설정
                }

                //커서 위치 이동
                axHwpCtrl1.MoveToField("table1_field1");
                
                //한글 세이브
                axHwpCtrl1.SaveAs(resultPath);

                //한글 파일 닫기
                axHwpCtrl1.Clear();


                //임시파일 삭제
                File.Delete(exeFilePath);
                File.Delete(scrFilePath);


                pbProgress.Visible = false;
                lbFile.Visible = false;
                btDisplayResult.Visible = true;
                MessageBox.Show((IWin32Window)this, "추출 완료");

                if (cbAutoRun.Checked)
                    btDisplayResult.PerformClick();

            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);

                MessageBox.Show(errorMessage, "Error");
            }
            finally
            {
                extractDirPath.Enabled = true;
                resultDirPath.Enabled = true;
                startExtract.Enabled = true;
                close.Enabled = true;

                pbProgress.Visible = false;
                lbFile.Visible = false;
            }

        }



        private void startExtract_Click(object sender, EventArgs e)
        {

            if (rbRetTypeHwp.Checked)
            {
                extractHwp();
            }
            else
            {
                extractExcel();
            }



            Properties.LastInfo.Default.strSrcPath = tbExtractPath.Text;
            Properties.LastInfo.Default.strDstPath = tbResultPath.Text;
            Properties.LastInfo.Default.strDstFile = tbResultName.Text;
            Properties.LastInfo.Default.bSrcTypeExe = rbSrcTypeExe.Checked;
            Properties.LastInfo.Default.strExeNumberBase = tbExeNumberbase.Text;
            Properties.LastInfo.Default.strLibNumberBase = tbLibNumberBase.Text;
            Properties.LastInfo.Default.bRstTypeHwp = rbRetTypeHwp.Checked;
            Properties.LastInfo.Default.strVersion = tbVersion.Text;
            Properties.LastInfo.Default.bResultAutoRun = cbAutoRun.Checked;
            Properties.LastInfo.Default.Save();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            tbExtractPath.Text = Properties.LastInfo.Default.strSrcPath;

            if (Properties.LastInfo.Default.bSrcTypeExe == true)
            {
                rbSrcTypeExe.Select();
            }
            else
            {
                rbSrcTypeSrc.Select();
            }


            if (Properties.LastInfo.Default.bRstTypeHwp == true)
            {
                rbRetTypeHwp.Select();
                
            }
            else
            {
                rbRetTypeExl.Select();
            }




            if (Properties.LastInfo.Default.strDstPath == "")
            {
                if (Properties.LastInfo.Default.bRstTypeHwp == true)
                {
                    tbResultName.Text = "Result.hwp";
                
                }
                else
                    tbResultName.Text = "Result.xls";
            }
            else
            {
                tbResultName.Text = Properties.LastInfo.Default.strDstFile;
            }

            if (Properties.LastInfo.Default.strDstPath == "")
            {
                tbResultPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }
            else
            {
                tbResultPath.Text = Properties.LastInfo.Default.strDstPath;
            }

            if (Properties.LastInfo.Default.strExeNumberBase != "")
            {
                tbExeNumberbase.Text = Properties.LastInfo.Default.strExeNumberBase;
            }

            if (Properties.LastInfo.Default.strLibNumberBase != "")
            {
                tbLibNumberBase.Text = Properties.LastInfo.Default.strLibNumberBase;
            }

            //strVersion
            if( Properties.LastInfo.Default.strVersion == "" )
            {
                tbVersion.Text = "1.0";
            }
            else
            {
                tbVersion.Text = Properties.LastInfo.Default.strVersion;
            }


            if (tbExtractPath.Text.StartsWith("c:\\"))
            {
                tbPathDel.Text = "c:\\";
            }

            if (tbExtractPath.Text.StartsWith("C:\\"))
            {
                tbPathDel.Text = "C:\\";
            }

            if(  Properties.LastInfo.Default.bResultAutoRun )
            {
                cbAutoRun.Checked = true;
            }

           
        }

        private void close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btDisplayResult_Click(object sender, EventArgs e)
        {
            try
            {
                FileInfo fi = new FileInfo(tbResultPath.Text + @"\" + tbResultName.Text);
                if (fi.Exists)
                {
                    System.Diagnostics.Process.Start(tbResultPath.Text + @"\" + tbResultName.Text);
                }
            }
            catch(Exception ex )
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, ex.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, ex.Source);

                MessageBox.Show(errorMessage, "Error");
            }

            Console.WriteLine("end");
        }






        /* 한글 컨트롤*/

        void hwp_insertTable()
        {
            HWPCONTROLLib.DHwpAction act = (HWPCONTROLLib.DHwpAction)axHwpCtrl1.CreateAction("TableAppendRow");

            HWPCONTROLLib.DHwpParameterSet pset = (HWPCONTROLLib.DHwpParameterSet)act.CreateSet();

            act.GetDefault(pset);

            act.Execute(pset);

            hwp_colBegin();
        }



        void hwp_moveDonw()
        {
            HWPCONTROLLib.DHwpAction act1 = (HWPCONTROLLib.DHwpAction)axHwpCtrl1.CreateAction("MoveDown");

            HWPCONTROLLib.DHwpParameterSet pset1 = (HWPCONTROLLib.DHwpParameterSet)act1.CreateSet();

            act1.GetDefault(pset1);

            act1.Execute(pset1);
        }


        void hwp_moveUp()
        {
            HWPCONTROLLib.DHwpAction act1 = (HWPCONTROLLib.DHwpAction)axHwpCtrl1.CreateAction("MoveUp");

            HWPCONTROLLib.DHwpParameterSet pset1 = (HWPCONTROLLib.DHwpParameterSet)act1.CreateSet();

            act1.GetDefault(pset1);

            act1.Execute(pset1);
        }


        void hwp_colMerge()
        {
            axHwpCtrl1.Run("TableCellBlock");
            axHwpCtrl1.Run("TableColBegin");
            axHwpCtrl1.Run("TableCellBlockExtend");
            axHwpCtrl1.Run("TableColEnd");
            axHwpCtrl1.Run("TableMergeCell");
        }


        void hwp_colBegin()
        {
            axHwpCtrl1.Run("TableCellBlock");
            axHwpCtrl1.Run("TableColBegin");
            axHwpCtrl1.Run("Cancel");
        }



        void hwp_insertTableData(String[] data)
        {
            HWPCONTROLLib.DHwpAction act = (HWPCONTROLLib.DHwpAction)axHwpCtrl1.CreateAction("InsertText");

            HWPCONTROLLib.DHwpParameterSet text = (HWPCONTROLLib.DHwpParameterSet)act.CreateSet();



            for (int i = 0; i < data.Length; i++)
            {
                text.SetItem("Text", data[i]);

                act.Execute(text);

                if (i + 1 != data.Length)
                    axHwpCtrl1.Run("MoveRight"); // axHwpCtrl1.Run("TableRightCell");
            }
        }

        void hwp_TextLeft()
        {
            axHwpCtrl1.Run("ParagraphShapeAlignLeft");
        }



        void hwp_init()
        {
            axHwpCtrl1.Open("temp1.hwp");

            axHwpCtrl1.MoveToField("table1_field1");

        }


        void hwp_end()
        {


            HWPCONTROLLib.DHwpAction act = (HWPCONTROLLib.DHwpAction)axHwpCtrl1.CreateAction("TableDeleteRow");

            HWPCONTROLLib.DHwpParameterSet pset = (HWPCONTROLLib.DHwpParameterSet)act.CreateSet();

            act.GetDefault(pset);

            act.Execute(pset);

            hwp_colBegin();

        }


        void hwp_tabClose()
        {


            HWPCONTROLLib.DHwpAction act = (HWPCONTROLLib.DHwpAction)axHwpCtrl1.CreateAction("TabClose");

            HWPCONTROLLib.DHwpParameterSet pset = (HWPCONTROLLib.DHwpParameterSet)act.CreateSet();

            act.GetDefault(pset);

            act.Execute(pset);

            hwp_colBegin();

        }


       

        void hwp_insertPath(String data)
        {


            hwp_insertTable();

            hwp_moveUp();

            hwp_colMerge();


            String[] path = new String[1];

            path[0] = data;

            hwp_insertTableData(path);


            hwp_TextLeft();

            hwp_moveDonw();


            hwp_colBegin();

            
        }

        void hpw_insertData(String[] data)
        {

            hwp_insertTableData(data);
            hwp_insertTable();
        }


        void hwp_setHeaderCell()
        {

            axHwpCtrl1.MoveToField("table1_field2");// 제목셀로 지정된 셀로 이동

            HWPCONTROLLib.DHwpAction act = (HWPCONTROLLib.DHwpAction)axHwpCtrl1.CreateAction("TablePropertyDialog");

            HWPCONTROLLib.DHwpParameterSet aa = (HWPCONTROLLib.DHwpParameterSet)axHwpCtrl1.CreateSet("Table");

            act.GetDefault(aa);

            HWPCONTROLLib.DHwpParameterSet bb = (HWPCONTROLLib.DHwpParameterSet)aa.CreateItemSet("Cell", "Cell");

            bb.SetItem("Header", 1);

            //axHwpCtrl1.CharShape = aa;

            act.Execute(aa);
        }





        private void rbRetTypeHwp_CheckedChanged(object sender, EventArgs e)
        {
            tbResultName.Text = "Result.hwp";

            if (rbRetTypeHwp.Checked)
                MessageBox.Show("작업 중인 한글 파일을(HWP) 모두 닫아 주세요.\n 한글 파일 생성 중 오류가 발생 할 수 있음.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }

        private void rbRetTypeExl_CheckedChanged(object sender, EventArgs e)
        {
            tbResultName.Text = "Result.xls";
        }

        private void pathWarning(object sender, EventArgs e)
        {

            if (tbPathDel.Text == String.Empty || tbExtractPath.Text.IndexOf(tbPathDel.Text) >= 0) // 경로에 사용자가 삭제할 경로문자가 존재하는 경우
            {
                lbDelText.Visible = false;

            }
            else
            {
                lbDelText.Visible = true;
            }


        }


        private  void resourceCopy()
        {
            FileStream fs = null;

            try
            {
                byte[] fileBytes = Properties.Resources.temp1;
                string targetPath = exeFilePath;

                fs = new FileStream(targetPath, FileMode.Create);
                fs.Write(fileBytes, 0, fileBytes.Length);

                fs.Close();

                fileBytes = Properties.Resources.temp2;
                targetPath = scrFilePath;

                fs = new FileStream(targetPath, FileMode.Create);
                fs.Write(fileBytes, 0, fileBytes.Length);

                fs.Close();

                Console.WriteLine("Done Copy");
            }
            catch (IOException exception)
            {
                Console.WriteLine("Error in file writing\r\n{0}", exception.Message);
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
        }


        public static void dllCopy()
        {
            FileStream fs = null;

            try
            {
                byte[] fileBytes = Properties.Resources.AxInterop_HWPCONTROLLib;
                string targetPath = "AxInterop.HWPCONTROLLib.dll";

                fs = new FileStream(targetPath, FileMode.Create);
                fs.Write(fileBytes, 0, fileBytes.Length);

                fs.Close();

                fileBytes = Properties.Resources.Interop_HWPCONTROLLib;
                targetPath = "Interop.HWPCONTROLLib.dll";

                fs = new FileStream(targetPath, FileMode.Create);
                fs.Write(fileBytes, 0, fileBytes.Length);

                fs.Close();

                Console.WriteLine("Done Copy");
            }
            catch (IOException exception)
            {
                Console.WriteLine("Error in file writing\r\n{0}", exception.Message);
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // Topic 패널 아래 경계선 긋기.
            System.Drawing.Pen penGray = null;
            System.Drawing.Pen penWhite = null;

            try
            {
                penGray = new System.Drawing.Pen(Color.DarkGray);
                penWhite = new System.Drawing.Pen(Color.White);

                e.Graphics.DrawLine(penGray, panelTopic.Bounds.X + 2, panelTopic.Bounds.Y + panelTopic.Bounds.Height,
                                    panelTopic.Bounds.X + panelTopic.Bounds.Width - 2, panelTopic.Bounds.Y + panelTopic.Bounds.Height);
                e.Graphics.DrawLine(penWhite, panelTopic.Bounds.X + 2, panelTopic.Bounds.Y + 1 + panelTopic.Bounds.Height,
                                    panelTopic.Bounds.X + panelTopic.Bounds.Width - 2, panelTopic.Bounds.Y + panelTopic.Bounds.Height + 1);
            }
            finally
            {
                if (penGray != null)
                    penGray.Dispose();

                if (penWhite != null)
                    penWhite.Dispose();
            }
        }

        private void QuickAutoSpsForm_Load(object sender, EventArgs e)
        {
            const string classByExtensionPath = ".\\classByExtension.txt";
            const string classBySubStringPath = ".\\classBySubString.txt";

            extensionMapToClass = LoadFileClassRule(classByExtensionPath);
            subStringMapToClass = LoadFileClassRule(classBySubStringPath);
        }

        private string GetFileClassName(FileInfo fileInfo)
        {
            string fileClass = null;
            bool bDone = false;

            foreach (string subStringKey in subStringMapToClass.Keys)
            {
                if (fileInfo.FullName.Contains(subStringKey))
                {
                    fileClass = subStringMapToClass[subStringKey] as string;
                    bDone = true;
                    break;
                }
            }

            if (bDone == false)
            {
                if (extensionMapToClass.TryGetValue(fileInfo.Extension, out fileClass) == false)
                {
                    // 정의되지 않은 확장자 또는 확장자가 없는 파일.
                    fileClass = "";
                }
            }

            return fileClass;
        }

        private Dictionary<string, string> LoadFileClassRule(string filePath)
        {
            string[] linesDirty = File.ReadAllLines(filePath, Encoding.Default);

            string[] lines = linesDirty.Where(line => !String.IsNullOrWhiteSpace(line) && !line.StartsWith("//")).ToArray();

            Dictionary<string, string> dictionary = lines.Select(s => s.Split(new char[] { '=' })).ToDictionary(s => s[0].Trim(), s => s[1].Trim());

            return dictionary;
        }


    }
}




