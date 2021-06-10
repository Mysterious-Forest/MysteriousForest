using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger2 : MonoBehaviour
{
    public string labelText = "우측에 과일나무들이 있다. 들고있는 칼(1번키)로 나무를 베어보자!"; //labelText가 보이도록 설정

    public bool showLoseWindow = false; //처음에는 보이지 않게 설정
    public bool showFlowerWindow = false; //처음에는 보이지 않게 설정
    public bool hungryWindow = true; //처음에 보이게 설정

    private int playerHP = 5; //Player 체력 설정
    public int HP //체력 함수
    {
        get { return playerHP; } //체력 값을 다시 받아온다.
        set
        {
            playerHP = value; //체력 값을 저장한다.

            if (playerHP <= 0) //만약 체력이 0 이면
            {
                showLoseWindow = true; //GUI 버튼이 뜨도록 한다.
            }
        }
    }

    private int MysteriousFlower = 0; //신비의 꽃 갯수 설정
    public int Flower //신비의 꽃 함수
    {
        get { return MysteriousFlower; } //신비의 꽃 값을 다시 받아온다.
        set
        {
            MysteriousFlower = value; //신비의 꽃 값을 저장한다.

            if (MysteriousFlower >= 20) //만약 신비의 꽃을 20개 이상 얻으면
            {
                labelText = ""; //labelText가 보이지 않게 한다.
                showFlowerWindow = true; //GUI 버튼이 뜨도록 한다.
            }
        }
    }

    private int Food = 0; //과일 체력 설정
    public int food //과일 체력 함수
    {
        get { return Food; } //과일 체력 값을 다시 받아온다.
        set
        {
            Food = value; //과일 값을 저장한다.

            if (Food >= 5) //만약 과일을 5개 이상 얻으면
            {
                labelText = "이제 신비의 물약 재료에 필요한 물약 2개를 모으자! 곡괭이(4번키)로 바위를 깨면 물약이 나온다."; //labelText가 보이도록 한다.
            }
        }
    }

    private int Rock = 0; //바위 체력 설정
    public int rock //바위 함수
    {
        get { return Rock; } //바위 체력 값을 다시 받아 온다.
        set
        {
            Rock = value; //바위 값을 저장한다.

            if (Rock >= 2) //바위에서 나온 아이템(물약)이 2개이상이면
            {
                labelText = "마지막으로 신비의 물약을 얻기 위한 재료인 꽃을 20송이 모으자!"; //labelText가 보이도록 한다.
            }
        }
    }

    // Update is called once per frame
    void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 150, 25), "Player HP: " + playerHP); //GUI 박스 위치 및 이름 설정
        GUI.Box(new Rect(20, 50, 150, 25), "Food: " + Food); //GUI 박스 위치 및 이름 설정
        GUI.Box(new Rect(20, 80, 150, 25), "Rock: " + Rock); //GUI 박스 위치 및 이름 설정
        GUI.Box(new Rect(20, 110, 150, 25), "Mysterious Flower: " + MysteriousFlower); //GUI 박스 위치 및 이름 설정
        GUI.Label(new Rect(Screen.width / 3, Screen.height - 40, 600, 100), labelText); //GUI Label 위치 설정

        if (showLoseWindow) //만약 showLoseWindow가 true면
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "DIE")) //GUI Button 위치 및 이름 설정
            {
                SceneManager.LoadScene("OverScene"); //낮 게임 오버 신으로 전환
            }
        }

        if (showFlowerWindow) //만약 showFlowerWindow가 true면
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height /2-50, 495, 50), "신비의 꽃을 다모았군요! 신비의 물약은 다음날 날이 밝으면 완성됩니다!")) //GUI Button 위치 및 이름 설정
            {
                showFlowerWindow = false;
                SceneManager.LoadScene("DemoNight"); //밤 씬으로 전환
            }
        }

        if (hungryWindow) //만약 hungryWindow가 true면
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 50, 300, 50), "우선 과일을 먹어 배를 채우자!")) //GUI Button 위치 및 이름 설정
            {
                hungryWindow = false; //GUI 버튼이 뜨지 않도록 한다.
            }
        }
    }
}
