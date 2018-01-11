namespace FileInfoExtractor
{
    partial class QuickAutoSpsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuickAutoSpsForm));
            this.startExtract = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.extractDirPath = new System.Windows.Forms.Button();
            this.resultDirPath = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbExtractPath = new System.Windows.Forms.TextBox();
            this.tbResultPath = new System.Windows.Forms.TextBox();
            this.tbResultName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rbRetTypeHwp = new System.Windows.Forms.RadioButton();
            this.rbRetTypeExl = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbFile = new System.Windows.Forms.Label();
            this.btDisplayResult = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbTableHeaderSet = new System.Windows.Forms.CheckBox();
            this.lbDelText = new System.Windows.Forms.Label();
            this.cbUseLower = new System.Windows.Forms.CheckBox();
            this.tbPathDel = new System.Windows.Forms.TextBox();
            this.tbPathHead = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbVersion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbLibNumberBase = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbExeNumberbase = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbSrcTypeExe = new System.Windows.Forms.RadioButton();
            this.rbSrcTypeSrc = new System.Windows.Forms.RadioButton();
            this.cbAutoRun = new System.Windows.Forms.CheckBox();
            this.panelTopic = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbProgress = new System.Windows.Forms.PictureBox();
            this.panelMiddle = new System.Windows.Forms.Panel();
            this.axHwpCtrl1 = new AxHWPCONTROLLib.AxHwpCtrl();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panelTopic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).BeginInit();
            this.panelMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axHwpCtrl1)).BeginInit();
            this.SuspendLayout();
            // 
            // startExtract
            // 
            this.startExtract.Location = new System.Drawing.Point(420, 565);
            this.startExtract.Name = "startExtract";
            this.startExtract.Size = new System.Drawing.Size(75, 23);
            this.startExtract.TabIndex = 0;
            this.startExtract.Text = "추출 시작";
            this.startExtract.UseVisualStyleBackColor = true;
            this.startExtract.Click += new System.EventHandler(this.startExtract_Click);
            // 
            // close
            // 
            this.close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.close.Location = new System.Drawing.Point(501, 565);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(75, 23);
            this.close.TabIndex = 1;
            this.close.Text = "닫기";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // extractDirPath
            // 
            this.extractDirPath.Location = new System.Drawing.Point(461, 29);
            this.extractDirPath.Name = "extractDirPath";
            this.extractDirPath.Size = new System.Drawing.Size(75, 23);
            this.extractDirPath.TabIndex = 2;
            this.extractDirPath.Tag = "";
            this.extractDirPath.Text = "탐색";
            this.extractDirPath.UseVisualStyleBackColor = true;
            this.extractDirPath.Click += new System.EventHandler(this.extractDirPath_Click);
            // 
            // resultDirPath
            // 
            this.resultDirPath.Location = new System.Drawing.Point(461, 79);
            this.resultDirPath.Name = "resultDirPath";
            this.resultDirPath.Size = new System.Drawing.Size(75, 23);
            this.resultDirPath.TabIndex = 3;
            this.resultDirPath.Text = "탐색";
            this.resultDirPath.UseVisualStyleBackColor = true;
            this.resultDirPath.Click += new System.EventHandler(this.resultDirPath_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "경로 : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "경로 :";
            // 
            // tbExtractPath
            // 
            this.tbExtractPath.Location = new System.Drawing.Point(112, 31);
            this.tbExtractPath.Name = "tbExtractPath";
            this.tbExtractPath.Size = new System.Drawing.Size(343, 21);
            this.tbExtractPath.TabIndex = 6;
            // 
            // tbResultPath
            // 
            this.tbResultPath.Location = new System.Drawing.Point(112, 81);
            this.tbResultPath.Name = "tbResultPath";
            this.tbResultPath.Size = new System.Drawing.Size(343, 21);
            this.tbResultPath.TabIndex = 7;
            // 
            // tbResultName
            // 
            this.tbResultName.Location = new System.Drawing.Point(112, 109);
            this.tbResultName.Name = "tbResultName";
            this.tbResultName.Size = new System.Drawing.Size(343, 21);
            this.tbResultName.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "파일 이름 :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbResultName);
            this.groupBox1.Controls.Add(this.resultDirPath);
            this.groupBox1.Controls.Add(this.tbResultPath);
            this.groupBox1.Location = new System.Drawing.Point(12, 177);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(559, 141);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "결과 파일";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rbRetTypeHwp);
            this.groupBox5.Controls.Add(this.rbRetTypeExl);
            this.groupBox5.Location = new System.Drawing.Point(10, 25);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(171, 45);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "결과 파일 종류";
            // 
            // rbRetTypeHwp
            // 
            this.rbRetTypeHwp.AutoSize = true;
            this.rbRetTypeHwp.Location = new System.Drawing.Point(14, 20);
            this.rbRetTypeHwp.Name = "rbRetTypeHwp";
            this.rbRetTypeHwp.Size = new System.Drawing.Size(47, 16);
            this.rbRetTypeHwp.TabIndex = 1;
            this.rbRetTypeHwp.TabStop = true;
            this.rbRetTypeHwp.Text = "한글";
            this.rbRetTypeHwp.UseVisualStyleBackColor = true;
            this.rbRetTypeHwp.CheckedChanged += new System.EventHandler(this.rbRetTypeHwp_CheckedChanged);
            // 
            // rbRetTypeExl
            // 
            this.rbRetTypeExl.AutoSize = true;
            this.rbRetTypeExl.Location = new System.Drawing.Point(91, 20);
            this.rbRetTypeExl.Name = "rbRetTypeExl";
            this.rbRetTypeExl.Size = new System.Drawing.Size(47, 16);
            this.rbRetTypeExl.TabIndex = 0;
            this.rbRetTypeExl.TabStop = true;
            this.rbRetTypeExl.Text = "엑셀";
            this.rbRetTypeExl.UseVisualStyleBackColor = true;
            this.rbRetTypeExl.CheckedChanged += new System.EventHandler(this.rbRetTypeExl_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.extractDirPath);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.tbExtractPath);
            this.groupBox2.Location = new System.Drawing.Point(12, 103);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(559, 63);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "소스 경로";
            // 
            // lbFile
            // 
            this.lbFile.AutoSize = true;
            this.lbFile.Location = new System.Drawing.Point(71, 538);
            this.lbFile.Name = "lbFile";
            this.lbFile.Size = new System.Drawing.Size(9, 12);
            this.lbFile.TabIndex = 13;
            this.lbFile.Text = " ";
            // 
            // btDisplayResult
            // 
            this.btDisplayResult.Location = new System.Drawing.Point(12, 565);
            this.btDisplayResult.Name = "btDisplayResult";
            this.btDisplayResult.Size = new System.Drawing.Size(75, 23);
            this.btDisplayResult.TabIndex = 14;
            this.btDisplayResult.Text = "결과 보기";
            this.btDisplayResult.UseVisualStyleBackColor = true;
            this.btDisplayResult.Visible = false;
            this.btDisplayResult.Click += new System.EventHandler(this.btDisplayResult_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbTableHeaderSet);
            this.groupBox3.Controls.Add(this.lbDelText);
            this.groupBox3.Controls.Add(this.cbUseLower);
            this.groupBox3.Controls.Add(this.tbPathDel);
            this.groupBox3.Controls.Add(this.tbPathHead);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.tbVersion);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.tbLibNumberBase);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.tbExeNumberbase);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Location = new System.Drawing.Point(12, 332);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(558, 192);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "정보 추출 설정";
            // 
            // cbTableHeaderSet
            // 
            this.cbTableHeaderSet.AutoSize = true;
            this.cbTableHeaderSet.Location = new System.Drawing.Point(22, 76);
            this.cbTableHeaderSet.Margin = new System.Windows.Forms.Padding(1);
            this.cbTableHeaderSet.Name = "cbTableHeaderSet";
            this.cbTableHeaderSet.Size = new System.Drawing.Size(148, 16);
            this.cbTableHeaderSet.TabIndex = 14;
            this.cbTableHeaderSet.Text = "한글 제목 셀 자동 반복";
            this.cbTableHeaderSet.UseVisualStyleBackColor = true;
            // 
            // lbDelText
            // 
            this.lbDelText.AutoSize = true;
            this.lbDelText.ForeColor = System.Drawing.Color.Red;
            this.lbDelText.Location = new System.Drawing.Point(150, 169);
            this.lbDelText.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lbDelText.Name = "lbDelText";
            this.lbDelText.Size = new System.Drawing.Size(141, 12);
            this.lbDelText.TabIndex = 13;
            this.lbDelText.Text = "삭제할 문자열이 잘못 됨.";
            this.lbDelText.Visible = false;
            // 
            // cbUseLower
            // 
            this.cbUseLower.AutoSize = true;
            this.cbUseLower.Location = new System.Drawing.Point(22, 95);
            this.cbUseLower.Margin = new System.Windows.Forms.Padding(1);
            this.cbUseLower.Name = "cbUseLower";
            this.cbUseLower.Size = new System.Drawing.Size(116, 16);
            this.cbUseLower.TabIndex = 12;
            this.cbUseLower.Text = "경로 소문자 사용";
            this.cbUseLower.UseVisualStyleBackColor = true;
            // 
            // tbPathDel
            // 
            this.tbPathDel.Location = new System.Drawing.Point(153, 142);
            this.tbPathDel.Name = "tbPathDel";
            this.tbPathDel.Size = new System.Drawing.Size(387, 21);
            this.tbPathDel.TabIndex = 11;
            this.tbPathDel.TextChanged += new System.EventHandler(this.pathWarning);
            // 
            // tbPathHead
            // 
            this.tbPathHead.Location = new System.Drawing.Point(153, 119);
            this.tbPathHead.Name = "tbPathHead";
            this.tbPathHead.Size = new System.Drawing.Size(387, 21);
            this.tbPathHead.TabIndex = 10;
            this.tbPathHead.Text = "저장위치 : \\tffs0\\";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 143);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 12);
            this.label8.TabIndex = 9;
            this.label8.Text = "파일경로 삭제문자열";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(45, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 12);
            this.label7.TabIndex = 8;
            this.label7.Text = "파일경로 접두어";
            // 
            // tbVersion
            // 
            this.tbVersion.Location = new System.Drawing.Point(438, 75);
            this.tbVersion.Name = "tbVersion";
            this.tbVersion.Size = new System.Drawing.Size(100, 21);
            this.tbVersion.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(400, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "버전";
            // 
            // tbLibNumberBase
            // 
            this.tbLibNumberBase.Location = new System.Drawing.Point(440, 44);
            this.tbLibNumberBase.Name = "tbLibNumberBase";
            this.tbLibNumberBase.Size = new System.Drawing.Size(100, 21);
            this.tbLibNumberBase.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(316, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "라이브러리 부품번호";
            // 
            // tbExeNumberbase
            // 
            this.tbExeNumberbase.Location = new System.Drawing.Point(440, 16);
            this.tbExeNumberbase.Name = "tbExeNumberbase";
            this.tbExeNumberbase.Size = new System.Drawing.Size(100, 21);
            this.tbExeNumberbase.TabIndex = 5;
            this.tbExeNumberbase.Tag = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(328, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "실행파일 부품번호";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbSrcTypeExe);
            this.groupBox4.Controls.Add(this.rbSrcTypeSrc);
            this.groupBox4.Location = new System.Drawing.Point(6, 20);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(171, 45);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "소스 타입";
            // 
            // rbSrcTypeExe
            // 
            this.rbSrcTypeExe.AutoSize = true;
            this.rbSrcTypeExe.Location = new System.Drawing.Point(14, 20);
            this.rbSrcTypeExe.Name = "rbSrcTypeExe";
            this.rbSrcTypeExe.Size = new System.Drawing.Size(71, 16);
            this.rbSrcTypeExe.TabIndex = 1;
            this.rbSrcTypeExe.TabStop = true;
            this.rbSrcTypeExe.Text = "실행파일";
            this.rbSrcTypeExe.UseVisualStyleBackColor = true;
            // 
            // rbSrcTypeSrc
            // 
            this.rbSrcTypeSrc.AutoSize = true;
            this.rbSrcTypeSrc.Location = new System.Drawing.Point(91, 20);
            this.rbSrcTypeSrc.Name = "rbSrcTypeSrc";
            this.rbSrcTypeSrc.Size = new System.Drawing.Size(71, 16);
            this.rbSrcTypeSrc.TabIndex = 0;
            this.rbSrcTypeSrc.TabStop = true;
            this.rbSrcTypeSrc.Text = "소스파일";
            this.rbSrcTypeSrc.UseVisualStyleBackColor = true;
            // 
            // cbAutoRun
            // 
            this.cbAutoRun.AutoSize = true;
            this.cbAutoRun.Location = new System.Drawing.Point(272, 569);
            this.cbAutoRun.Margin = new System.Windows.Forms.Padding(1);
            this.cbAutoRun.Name = "cbAutoRun";
            this.cbAutoRun.Size = new System.Drawing.Size(132, 16);
            this.cbAutoRun.TabIndex = 15;
            this.cbAutoRun.Text = "결과 파일 자동 실행";
            this.cbAutoRun.UseVisualStyleBackColor = true;
            // 
            // panelTopic
            // 
            this.panelTopic.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelTopic.Controls.Add(this.label11);
            this.panelTopic.Controls.Add(this.label10);
            this.panelTopic.Controls.Add(this.label9);
            this.panelTopic.Controls.Add(this.pictureBox1);
            this.panelTopic.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopic.Location = new System.Drawing.Point(0, 0);
            this.panelTopic.Margin = new System.Windows.Forms.Padding(2);
            this.panelTopic.Name = "panelTopic";
            this.panelTopic.Size = new System.Drawing.Size(586, 78);
            this.panelTopic.TabIndex = 17;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Malgun Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.Location = new System.Drawing.Point(9, 55);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(382, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "되었으며, LGPL 2.1 라이선스 정책에 따라 공개되는 자유 소프트웨어 입니다.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Malgun Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.Location = new System.Drawing.Point(9, 38);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(432, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "본 SW는 퍼스텍(주)에서 소프트웨어 산출물 명세서 작성의 효율성을 높이기 위해 개발";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Malgun Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(8, 7);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(140, 25);
            this.label9.TabIndex = 1;
            this.label9.Text = "QuickAutoSps";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(469, 39);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(107, 27);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pbProgress
            // 
            this.pbProgress.Image = ((System.Drawing.Image)(resources.GetObject("pbProgress.Image")));
            this.pbProgress.Location = new System.Drawing.Point(13, 455);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(45, 12);
            this.pbProgress.TabIndex = 12;
            this.pbProgress.TabStop = false;
            this.pbProgress.Visible = false;
            // 
            // panelMiddle
            // 
            this.panelMiddle.Controls.Add(this.pbProgress);
            this.panelMiddle.Location = new System.Drawing.Point(0, 83);
            this.panelMiddle.Margin = new System.Windows.Forms.Padding(2);
            this.panelMiddle.Name = "panelMiddle";
            this.panelMiddle.Size = new System.Drawing.Size(586, 477);
            this.panelMiddle.TabIndex = 18;
            // 
            // axHwpCtrl1
            // 
            this.axHwpCtrl1.Enabled = true;
            this.axHwpCtrl1.Location = new System.Drawing.Point(294, 946);
            this.axHwpCtrl1.Margin = new System.Windows.Forms.Padding(1);
            this.axHwpCtrl1.Name = "axHwpCtrl1";
            this.axHwpCtrl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axHwpCtrl1.OcxState")));
            this.axHwpCtrl1.Size = new System.Drawing.Size(100, 50);
            this.axHwpCtrl1.TabIndex = 16;
            this.axHwpCtrl1.Visible = false;
            // 
            // QuickAutoSpsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.close;
            this.ClientSize = new System.Drawing.Size(586, 601);
            this.Controls.Add(this.panelTopic);
            this.Controls.Add(this.cbAutoRun);
            this.Controls.Add(this.axHwpCtrl1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btDisplayResult);
            this.Controls.Add(this.lbFile);
            this.Controls.Add(this.close);
            this.Controls.Add(this.startExtract);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panelMiddle);
            this.MaximizeBox = false;
            this.Name = "QuickAutoSpsForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.QuickAutoSpsForm_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panelTopic.ResumeLayout(false);
            this.panelTopic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).EndInit();
            this.panelMiddle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axHwpCtrl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startExtract;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Button extractDirPath;
        private System.Windows.Forms.Button resultDirPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbExtractPath;
        private System.Windows.Forms.TextBox tbResultPath;
        private System.Windows.Forms.TextBox tbResultName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbFile;
        private System.Windows.Forms.Button btDisplayResult;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rbSrcTypeExe;
        private System.Windows.Forms.RadioButton rbSrcTypeSrc;
        private System.Windows.Forms.TextBox tbLibNumberBase;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbExeNumberbase;
        private System.Windows.Forms.Label label4;
        private AxHWPCONTROLLib.AxHwpCtrl axHwpCtrl1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rbRetTypeHwp;
        private System.Windows.Forms.RadioButton rbRetTypeExl;
        private System.Windows.Forms.TextBox tbVersion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbPathDel;
        private System.Windows.Forms.TextBox tbPathHead;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox cbUseLower;
        private System.Windows.Forms.Label lbDelText;
        private System.Windows.Forms.CheckBox cbTableHeaderSet;
        private System.Windows.Forms.CheckBox cbAutoRun;
        private System.Windows.Forms.Panel panelTopic;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox pbProgress;
        private System.Windows.Forms.Panel panelMiddle;
    }
}

