using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    public string labelText = "낮이 되기 전까지 좀비를 20마리 죽이세요!";
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
                labelText = ""; //처음에 설정한 labelText 안보이게 설정
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

            if (playerScore >= 15) //스코어가 15이상이면
            {
                winWindow = true; //설정한 GUI 창이 나온다.
                labelText = ""; //처음에 설정한 labelText 안보이게 설정
            }
        }
    }


    // Update is called once per frame

    void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 150, 25), "Player HP: " + playerHP); //playerHP를 상단바에 노출
        GUI.Box(new Rect(500, 20, 150, 25), "Score: " + playerScore); //Score를 상단바에 노출
        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 350, 50), labelText); //labelText 위치 설정

        if (dieWindow)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "좀비의 습격으로 죽었습니당"))
            {
                SceneManager.LoadScene("StartScenes"); //밤을 배경으로 하는 게임오버씬으로 바꿀 예정
            }
        }

        if (winWindow)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "곧 날이 밝아옵니다!"))
            {
                SceneManager.LoadScene("DemoDay"); //게임 성공 씬으로 바꿀 예정 
            }
        }
    }
}
