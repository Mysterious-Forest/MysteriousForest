using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlueFlower : MonoBehaviour
{

    // Start is called before the first frame update

    // Update is called once per frame

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player") //만약 충돌대상이 Player라면
        {
            Destroy(gameObject); //꽃은 사라진다.
        }
    }
}
