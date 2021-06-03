using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxDestroy : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "w_baseballbat 1 1")
        {
            Destroy(gameObject);
        }
    }
}
