using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverSystem : MonoBehaviour
{
    public void OnClickGame()
    {
        SceneManager.LoadScene("StartScenes"); //버튼을 누를시 게임 시작 씬으로 간다.
    }
}
