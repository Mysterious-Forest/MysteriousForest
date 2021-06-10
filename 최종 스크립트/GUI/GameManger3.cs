using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger3 : MonoBehaviour
{
    public string labelText = "신비의 물약이 완성되었다!"; //labelText가 보이도록 설정

    public bool showWinWindow = false; //처음에는 보이지 않게 설정

    private int Mysteriouspotion = 0; //신비의 물약 값 설정
    public int _Mysteriouspotion //신비의 물약 값 함수
    {
        get { return Mysteriouspotion; } //신비의 물약 값을 다시 불러온다.
        set
        {
            Mysteriouspotion = value; //신비의 물약 값을 저장한다.

            if (Mysteriouspotion >= 1) //만약 신비의 물약을 획득했을 경우
            {
                labelText = ""; //labelText가 보이지 않게 한다.
                showWinWindow = true; //GUI 버튼이 뜨도록 한다.
            }
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 350, 50), labelText); //GUI Label 위치 설정

        if (showWinWindow)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 380, 100), "신비한 물약을 획득했습니다. 서둘러 딸에게 돌아가세요!")) //GUI Button 위치 및 이름 설정
            {
                SceneManager.LoadScene("Win Scene"); //게임 성공 씬으로 전환
            }
        }

    }
}
