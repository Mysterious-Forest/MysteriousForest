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
        if (collision.gameObject.name == "Player") //���� �浹����� Player���
        {
            Destroy(gameObject); //���� �������.
        }
    }
}
