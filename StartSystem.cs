using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSystem : MonoBehaviour
{
    public void OnClickGame()
    {
        SceneManager.LoadScene("DemoDay"); //���� ��ư�� ������ ���Ӿ����� ����.
    }
    // Start is called before the first frame update
}