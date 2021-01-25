# (공개용)VR Practice Kit SDK

VR Practice Kit SDK는 SOFTGROUND Inc의 VR Practice Kit을 Unity에서 사용할 수 있도록 돕는 라이브러리입니다.

## 지원환경
* Unity 2018 버전 이상
* 윈도우 10, IOS, Android

## 설치 방법
### 1. SDK 다운로드
우측의 [Releases](https://github.com/sgkim6326/VR-Practice-Kit-SDK/releases)를 선택합니다.
![설명1](https://user-images.githubusercontent.com/48825287/105766564-43fb9f00-5f9d-11eb-8c40-36fb01dc1997.png)  
VR-Practice-Kit-SDK.unitypackage를 선택하여 SDK를 다운로드 합니다.
![설명2](https://user-images.githubusercontent.com/48825287/105766849-9937b080-5f9d-11eb-959b-9e4f088eaccc.png)  
### 2. 프로젝트 설정
Unity 메뉴 중 Assets > Import package 메뉴를 선택하여 SDK 패키지를 불러옵니다.
Project 창의 Assets > VRKit > VRKitManager 프리팹을 VR Practice Kit를 사용할 Scene의 Hirarchy 창에 드래그합니다.
![설명3](https://user-images.githubusercontent.com/48825287/105768227-6db5c580-5f9f-11eb-965b-c32caa7b3497.png)
Hirarchy 창의 VRKitManager를 선택한 뒤, VR Practice Kit 제품에 포함된 ID를 Inspector 창의 Device Name에 적어줍니다.
![설명4](https://user-images.githubusercontent.com/48825287/105768770-3693e400-5fa0-11eb-83b4-869a3186d4db.png)
프로젝트를 시작하면 VR Practice Kit의 연결 상태에 따른 음성 안내를 확인할 수 있습니다.
## 지원 기능
### 1. 연결 상태 확인 기능
### 2. 조이스틱 기능
### 3. (구현 예정)IMU 기반 회전 기능

## 음성 자료 출처
[Typecast](https://typecast.ai/)
