using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDestroy : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player") //�浹�� ����� player���
        {
            Destroy(gameObject); //����� �������.
        }
    }

}
