﻿# QuickAutoSps 

QuickAutoSps는 무기체계 소프트웨어 개발 시 요구되는 소프트웨어 산출물 명세서(Software Product Specification, 이하 SPS)를 빠르게 자동으로 완성해주는 솔루션입니다. 


## 문제점

소프트웨어 산출물 명세서란 소프트웨어 개발 결과 산출된 소스파일, 실행 파일, 라이브러리, 이미지, 환경 설정 파일 등 모든 개별적인 파일에에 대한 파일 크기, 생성 일자, 버전, 체크섬 등의 정보를 명시하는 문서입니다. 이를 작성하기 위해서는 사람이 직접 다음 사항을 확인합니다. 

    1. 산출물 파일의 순번을 기록한다. 
    2. 산출물 파일의 이름을 확인하고 기록한다. 
    3. 산출물 파일의 버전을 기록한다. 
    4. 산출물 파일의 크기를 윈도우 속성 메뉴를 통해  확인하고 기록한다.
    5. 산출물 파일의 체크섬 값을 벼로의 프로그램으로 확인하고 기록한다. 
    6. 산출물 파일의 생성일을 윈도우 속성 메뉴를 통해 확인하고 기록한다.
    7. 산출물 파일의 소스 라인수를 소스코드 에디터를 열어 확인하고 기록한다.
    8. 산출물 파일의 기능을 기록한다. 

일반적으로 하나의 프로그램은 수 많은 소스코드와 라이브러리 파일, 이미지 등으로 구성됨으로 각 파일에 대해 위의 절차를 수행하는데 많은 시간이 소요됩니다. 실례를 보면 VxWorks 운영체제/X-Window 그래픽 라이브러리 기반 GUI 소프트웨어는 소프트웨어를 구성하는 산출물 파일이 약 1000개에 달했습니다. 파일 1개에 대해 산출물 명세서를 작성 수작업에 약 1분이 소요되었고, 1000개의 파일을 처리하는데 약 2.08일(하루를 8시간으로 잡았을 경우,1000(개)/(8(시간)*60(분)))이 소요되었습니다. 

이와 같이 소프트웨어 산출물 명세서 작성에는 많은 시간이 소요되고 기계적인 작업이 단순 반복됨으로 일반적으로 개발자의 사기를 저하시킵니다. 뿐만 아니라 단순 반복 작업이 오랜 시간 지속되면 개발자의 집중력이 저하되고 작업자의 실수로 이어지는 경우가 많습니다. 나아가 이런 실수는 사람이 식별해 내기 매우 어려우며 이런 오류는 실제 그대로 릴리즈 되는 경우가 많습니다. 

정리하면 소프트웨어 산출물 명세서를 수 작업을 통해 작성하게 되면 지나치게 많은 시간이 소요되고, 단순 반복적인 작업으로 개발자의 사기를 저하시키며, 수작업으로 인한 실수를 유발하는 문제점을 가지고 있습니다. 


## 프로젝트의 목표 

QuickAutoSps 프로젝트는 다음과 같은 목표를 가지고 개발됩니다. 

- 개발자의 시간과 에너지 절약하여 보다 의미 있는 곳에 활용할 수 있도록 한다. 
  
- 단순 반복 작업에서 오는 정신적 스트레스

- 수작업에서 오는 사용자 실수 제거하여 산출물의 질을 향상 시킨다. 

## 결과
- 수정1.
- 수정2.
- 수정3.


## 기능 명세 

## 시험 

## 프로그램 설치 방법

## 프로그램 사용 방법

## 개발 환경 설정 방법 

## 디렉토리 구성 
    - doc : 사용자 메뉴얼 등의 문서를 포함한다. 
    - release: 릴리즈된 설치 파일 및 릴리즈 노트를 포함한다. 
    - src : 프로젝트 소스코드 및 프로젝트 파일을 포함한다. 
    - test : 시험을 위한 절차서, 결과보고서, 시험 샘플 등을 포함한다. 

## 주요 소스 코드 구성

## 주요 환경 파일 구성

## 라이선스 

## 릴리즈 버전 관리 
우리는 릴리즈 버전 관리를 위해  [Semantic Versioning 2.0.0](<https://semver.org/>) 문서를 참조하여 사용합니다. 

## 컨트리뷰션 가이드 

## 개발자 
- 한주승
- 강민우 
