using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSystem : MonoBehaviour
{
    public void OnClickGame()
    {
        SceneManager.LoadScene("DemoDay"); //시작 버튼을 누를시 게임씬으로 간다.
    }
    // Start is called before the first frame update
}
