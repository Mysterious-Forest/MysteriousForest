# 모바일 3D 게임 < Mysterious Forest > - 김미소 / 오은주
![image](https://user-images.githubusercontent.com/84313631/120946461-903ec300-c777-11eb-9e0b-cd53dc3c8b2c.png)


# 게임 기획 의도

- '탈출'을 컨셉으로 한 많은 모바일 게임들이 흔히 말하는 '방탈출 게임'과 같은 포맷을 가지고 있다.
- 이러한 이유로 '탈출'이라는 목표 지향적인 게임들 뿐, 스토리 중심적인 게임을 찾기 힘들다.
- 배경 또한 밀폐된 방, 외딴 섬 등 어두운 공간을 주로 사용
 
 => '탈출'을 컵셉으로 하되 유저들의 감성을 자극할 수 있는 스토리와 밝은 분위기를 가진 
    새로운 유형의 게임을 제작해보고자 하였다.
    
    a. 유저들의 감성을 자극하는 스토리를 가진 생존 + 탈출 게임
    b. 귀여운 에셋을 활용해 주요 타겟층인 10~30대 여성을 겨냥한 게임
    c. 풍부한 컨텐츠로 유저들에게 다채로운 즐거움을 주는 게임
    d. 쉬운 조작법으로 접근성이 높은 게임
    
   
# < Mysterious Forest > 게임 시나리오

- 사랑하던 아내를 일찍 떠나보냈지만 그런 아내를 꼭 닮은 딸과 행복하게 살아가던 아빠. 하지만 어느날 딸이 불치병에 걸리고만다. 이 병을 치료할 수 있는 방법은 '신비의 숲'에 있는 '신비의 약물'을 가져오는 것.
하지만 '신비의 숲'은 한번 들어가며 살아나오기 힘든 악명 높은 숲으로 유명하다.
과연 아빠는 소중한 딸을 위해 무사히 '신비의 약물'을 획득할 수 있을까...?


# < Mysterious Forest > 게임 컨셉

- '신비의 숲'에서 생존 &  탈출의 컨셉을 지닌 < Mysterious Forest >는 캐쥬얼 풍의 3D 모바일 게임이다.
   아름다운 강과 나무, 꽃이 있는 '신비의 숲'을 배경으로 플레이어들은 '신비의 약물'을 얻기 위해 사냥과 채집 등 다양한 미션을 수행해야 한다.
   
   
 # < Mysterious Forest > 주요 콘텐츠
   
   a. Survive
   
    - 강 : 미션을 깨기 위해서는 강을 건너야만 한다. 강에 들어가면 강의 색이 변하고, Player의 HP가 깎인다.
    - 무기 : 각 상황별 알맞은 무기를 사용할 수 있다.
      ( ~ : 맨손  /  1 : 칼  /  2 : 방망이  /  3 : 총  /  4 : 곡괭이 )
    - 과일 : 강 건너의 과일나무를 베어 과일을 획득하면 다음 단계로 넘어갈 수 있다.
    - 바위 : 곡괭이로 바위를 부숴 신비의 물약 제조에 필요한 재료를 얻을 수 있다.
    - 꽃 : 일정 개수 이상의 꽃을 획득해 신비의 물약 제조에 필요한 재료를 얻을 수 있다.
    - 여우 : 꽃을 가로막는 여우를 방망이로 죽여야 한다. 닿으면 HP가 깎인다. 
    - 좀비 : 밤이 되면 좀비가 나타난다. 총을 이용해 좀비를 죽여야 한다.
    - 약물 : 미션을 다 완수한 후 신비의 물약을 찾으면 최종 탈출을 할 수 있다.

    
  b. Game
  
    - GUI 버튼 : 씬이 전환될 때, 버튼을 눌러 자연스럽게 게임을 시작할 수 있도록 한다.
    - GUI 박스 : 왼쪽 상단에 위치하여 HP와 획득한 꽃, 과일, 바위의 수를 나타내준다.
    - 레이블 텍스트 : 레이블 텍스트를 통해 유저가 게임을 원활하게 진행하도록 돕는다.
    - 효과음 : 플레이어가 사냥 및 채집을 할 때 효과음이 나온다.
    - 인벤토리 : 과일, 물약, 꽃을 얻으면 인벤토리 안에 저장되고, 획득 개수를 알려준다.
    - 낮과 밤 : 낮에 신비의 물약 제조에 필요한 꽃과 물약을 모두 모으면 밤으로 변한다.
    
    
 # 게임 조작 방법
 
 * 캐릭터 움직임 조절 : A / S / D / W
 * 캐릭터 방향키 조절 : 마우스
 * 달리기 : Shift
 * 점프 : Space
 * 무기 교체 : ~(맨손) / 1(칼) / 2(방망이) / 3(총) / 4(곡괭이)
 * 인벤토리 창 : I
 
# 게임 실제 구현 모습(진행상황)
 
 -> 게임 시작 화면
 ![image](https://user-images.githubusercontent.com/84313631/120945808-62f11580-c775-11eb-8948-818e678d876f.png)


-> 게임 시작 후 첫 화면
![image](https://user-images.githubusercontent.com/84313631/120945851-86b45b80-c775-11eb-8263-172cc73a576a.png)


-> 무기 교체( 칼 / 방망이 / 총 / 곡괭이 )
![image](https://user-images.githubusercontent.com/84313631/120945886-a481c080-c775-11eb-9073-50071ffa0674.png)
![image](https://user-images.githubusercontent.com/84313631/120945891-aba8ce80-c775-11eb-8ee7-8f4c85c85916.png)
![image](https://user-images.githubusercontent.com/84313631/120945896-af3c5580-c775-11eb-8d7e-3608d31c2934.png)
![image](https://user-images.githubusercontent.com/84313631/120948650-a8b1dc00-c77d-11eb-9236-f3338ec57dc9.png)


-> 칼로 나무를 베면 과일이 나타난다. + 과일을 먹으면 HP가 올라간다.
![image](https://user-images.githubusercontent.com/84313631/120945954-d7c44f80-c775-11eb-8a82-9887fe734fed.png)


-> 방망이로 여우를 죽여야 한다. 만약 여우한테 맞으면 HP가 깎인다.  
![image](https://user-images.githubusercontent.com/84313631/120946050-1d811800-c776-11eb-8944-d01f0472b53f.png)


-> 여우한테 닿아 HP가 다 깎이면 게임 오버 씬으로 .
![image](https://user-images.githubusercontent.com/84313631/120946276-e2331900-c776-11eb-8f8b-cbfa52e31d91.png)


-> 일정 개수 이상의 꽃을 구하면 메시지 박스가 뜬다.
![image](https://user-images.githubusercontent.com/84313631/120946070-2a057080-c776-11eb-97a5-c9a2f9a63b4e.png)


-> 꽃을 다 구하면 밤으로 씬 전환 후 좀비가 나타난다.
![image](https://user-images.githubusercontent.com/84313631/120946119-54572e00-c776-11eb-848c-cdd470d0fe24.png)


-> 좀비한테 닿아 HP가 다 깎이면 게임 종료를 알리는 메시지 박스가 뜬다.
![image](https://user-images.githubusercontent.com/84313631/120946150-7650b080-c776-11eb-8c40-e396319f866e.png)


-> 메시지 박스를 클릭한 후 종료화면
![image](https://user-images.githubusercontent.com/84313631/120946162-836d9f80-c776-11eb-96e0-f9e4cbb8d484.png)


-> 일정 수 이상의 좀비를 죽이면 다음 씬 전환을 위한 메시지 박스가 뜬다.
![image](https://user-images.githubusercontent.com/84313631/120946183-98e2c980-c776-11eb-814f-765a2bdd286b.png)


-> 메시지 박스를 클릭한 후 신비의 물약이 있는 씬이 나타난다.
![image](https://user-images.githubusercontent.com/84313631/120946204-ae57f380-c776-11eb-97be-15a9e14caa19.png)


-> 신비의 물약을 획득한 후 종료환면으로 씬전환을 위한 메시지 박스가 뜬다.
![image](https://user-images.githubusercontent.com/84313631/120946236-c465b400-c776-11eb-8194-ac058a258ab2.png)


-> 게임 최종 성공 씬
![image](https://user-images.githubusercontent.com/84313631/120946249-d0ea0c80-c776-11eb-91b4-1433f01bb3ff.png)




