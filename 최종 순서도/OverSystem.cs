using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverSystem : MonoBehaviour
{
    public void OnClickGame()
    {
        SceneManager.LoadScene("StartScenes"); //��ư�� ������ ���� ���� ������ ����.
    }
}
