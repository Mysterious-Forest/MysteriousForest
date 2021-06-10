using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowTreeDestroy : MonoBehaviour
{
    public ParticleSystem yellowtree; //나무가 없어질 때, 이펙트 정보를 저장하는 변수를 설정한다.
    public GameObject PineApple; //나무가 없어지면 설정한 파인애플이 나오도록 하는 변수 설정
    public Transform TreePost; //나무가 없어진 위치에 파인애플이 나오도록하는 변수 설정

    int YellowTreeHp = 3; //나무의 체력변수 설정한다.

    [SerializeField]
    private Inventory theInventory; //인벤토리에 습득한 아이템을 저장할 수 있도록 하는 변수 설정

    void OnCollisionEnter(Collision col) //Collider간 발생한 충돌을 감지하는 함수 설정
    {
        if (col.gameObject.name == "w_sword_B") //만약 충돌하는 물체가 칼이라면
        {
            YellowTreeHp -= 1; //나무의 체력이 1 줄어든다.
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (YellowTreeHp == 0) //만약 나무의 체력이 0이라면
        {
            ParticleSystem fire = Instantiate(yellowtree, transform.position, Quaternion.identity); //폭파 이펙트 함수 호출한다.
            fire.Play();
            theInventory.AcquireItem(GetComponent<ItemPickUp>().item); // ItemPickUp안에 item를 인벤토리에 저장한다.
             Destroy(gameObject); //나무는 사라진다.
            Instantiate(PineApple, TreePost.position, TreePost.rotation); //나무가 없어진 자리에 파인애플이 뜨는 함수 코드
        }
    }
}
