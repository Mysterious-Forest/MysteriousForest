using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RookDestroy : MonoBehaviour
{
    public GameObject Potion; //바위가 없어지면 설정한 물약이 나오도록 하는 변수 설정
    public Transform RockPost; //바위가 없어진 위치에 물약이 나오도록하는 변수 설정

    int Rock = 5; //바위의 체력변수 설정한다.

    [SerializeField]
    private Inventory theInventory; //인벤토리에 습득한 아이템을 저장할 수 있도록 하는 변수 설정

    void OnCollisionEnter(Collision col) //Collider간 발생한 충돌을 감지하는 함수 설정
    {
        if (col.gameObject.name == "Pickaxe") //만약 충돌하는 물체가 곡괭이라면
        {
            Rock -= 1; //바위의 체력이 -1 깎인다.
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Rock == 0) //만약 바위의 체력이 0이라면
        {
            theInventory.AcquireItem(GetComponent<ItemPickUp>().item); //ItemPickUp안에 item를 인벤토리에 저장한다. 
            Destroy(gameObject); //바위는 사라진다.
            Instantiate(Potion, RockPost.position, RockPost.rotation); //바위가 없어진 자리에 물약이 뜨는 함수 코드
        }
    }
}
