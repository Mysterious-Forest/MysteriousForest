using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PineappleDestroy : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player") //만약 충돌대상이 Player라면
        {
            Destroy(gameObject); // 파인애플이 사라진다.

        }
    }
}
