using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    public string labelText = "낮이 되기 전까지 좀비를 10마리 죽이자!"; //labelText가 보이도록 설정
    private int playerHP = 10; //Player 체력 설정
    public bool dieWindow = false; //처음에는 보이지 않게 설정
    public bool winWindow = false; //처음에는 보이지 않게 설정

    public int HP //체력 함수
    {
        get { return playerHP; } //Player 체력값 다시 반복
        set
        {
            playerHP = value; //player체력 값 저장

            if (playerHP <= 0) //player 체력이 0이면
            {
                dieWindow = true; //설정한 GUI 창이 나온다.
                labelText = ""; //labelText가 보이지 않게 한다.
            }
        }
    }

    private int playerScore = 0; //player가 좀비를 죽이면 스코어가 올라가는 함수
    public int Score //스코어 함수
    {
        get { return playerScore; } //스코어 값 다시 반복
        set
        {
            playerScore = value; //스코어 함수 값 저장

            if (playerScore >= 7) //스코어가 10이상이면
            {
                winWindow = true; //설정한 GUI 창이 나온다.
                labelText = ""; //처음에 설정한 labelText 안보이게 설정
            }
        }
    }


    // Update is called once per frame

    void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 150, 25), "Player HP: " + playerHP); //GUI 박스 위치 및 이름 설정
        GUI.Box(new Rect(700, 20, 150, 25), "Score: " + playerScore); //GUI 박스 위치 및 이름 설정
        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 350, 50), labelText); //GUI 박스 위치 및 이름 설정

        if (dieWindow) //만약 dieWindow가 true면
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "DIE")) //GUI Button 위치 및 이름 설정
            {
                SceneManager.LoadScene("OverNightScene"); //밤을 배경으로 하는 게임오버씬으로 전환
            }
        }

        if (winWindow) //만약 winWindow가 true면
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "곧 날이 밝아옵니다!")) //GUI Button 위치 및 이름 설정
            {
                SceneManager.LoadScene("PortionScene"); //물약씬으로 전환
            }
        }
    }
}
