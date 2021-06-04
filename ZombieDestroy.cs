using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDestroy : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player") //충돌한 대상이 player라면
        {
            Destroy(gameObject); //좀비는 사라진다.
        }
    }

}
