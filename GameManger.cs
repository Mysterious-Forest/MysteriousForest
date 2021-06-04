using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    public string labelText = "���� �Ǳ� ������ ���� 20���� ���̼���!";
    private int playerHP = 10; //Player ü�� ����
    public bool dieWindow = false; //ó������ ������ �ʰ� ����
    public bool winWindow = false; //ó������ ������ �ʰ� ����

    public int HP //ü�� �Լ�
    {
        get { return playerHP; } //Player ü�°� �ٽ� �ݺ�
        set
        {
            playerHP = value; //playerü�� �� ����

            if (playerHP <= 0) //player ü���� 0�̸�
            {
                dieWindow = true; //������ GUI â�� ���´�.
                labelText = ""; //ó���� ������ labelText �Ⱥ��̰� ����
            }
        }
    }

    private int playerScore = 0; //player�� ���� ���̸� ���ھ �ö󰡴� �Լ�
    public int Score //���ھ� �Լ�
    {
        get { return playerScore; } //���ھ� �� �ٽ� �ݺ�
        set
        {
            playerScore = value; //���ھ� �Լ� �� ����

            if (playerScore >= 15) //���ھ 15�̻��̸�
            {
                winWindow = true; //������ GUI â�� ���´�.
                labelText = ""; //ó���� ������ labelText �Ⱥ��̰� ����
            }
        }
    }


    // Update is called once per frame

    void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 150, 25), "Player HP: " + playerHP); //playerHP�� ��ܹٿ� ����
        GUI.Box(new Rect(500, 20, 150, 25), "Score: " + playerScore); //Score�� ��ܹٿ� ����
        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 350, 50), labelText); //labelText ��ġ ����

        if (dieWindow)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "������ �������� �׾����ϴ�"))
            {
                SceneManager.LoadScene("StartScenes"); //���� ������� �ϴ� ���ӿ��������� �ٲ� ����
            }
        }

        if (winWindow)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "�� ���� ��ƿɴϴ�!"))
            {
                SceneManager.LoadScene("DemoDay"); //���� ���� ������ �ٲ� ���� 
            }
        }
    }
}
