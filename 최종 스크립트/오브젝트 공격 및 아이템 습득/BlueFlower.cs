using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BlueFlower : MonoBehaviour
{
    [SerializeField]
    private Inventory theInventory;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player") //만약 충돌대상이 Player라면
        {
            theInventory.AcquireItem(GetComponent<ItemPickUp>().item); // ItemPickUp안에 item를 인벤토리에 저장한다.
            Destroy(gameObject); //꽃은 사라진다.
        }
    }
}
