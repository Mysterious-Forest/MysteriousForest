using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static bool inventoryActivated = false; //시작할 때 인벤토리 창이 뜨지 않도록 한다.

    // 필요한 컴포넌트
    [SerializeField]
    private GameObject go_InventoryBase; //인벤토리 창 오브젝트를 넣어줄 함수 정의
    [SerializeField]
    private GameObject go_SlotsParent; //슬롯 오브젝트를 넣어줄 함수 정의

    private Slot[] slots; //슬롯들

    // Start is called before the first frame update
    void Start()
    {
        slots = go_SlotsParent.GetComponentsInChildren<Slot>(); //부모 슬롯에 있는 자식 슬롯을 불러온다.
    }

    // Update is called once per frame
    void Update()
    {
        TryOpenInventory();
    }
    private void TryOpenInventory()
    {
        if (Input.GetKeyDown(KeyCode.I)) //만약 I키를 누르면
        {
            inventoryActivated = !inventoryActivated;

            if (inventoryActivated)
                OpenInventory(); //인벤토리 열기
            else
                CloseInventory(); //인벤토리 닫기
        }
    }
    private void OpenInventory()
    {
        go_InventoryBase.SetActive(true); //인벤토리 보이게 하기
    }

    private void CloseInventory()
    {
        go_InventoryBase.SetActive(false); //인벤토리 보이지 않게 하기
    }
    public void AcquireItem(Item _item, int _count = 1) //아이템을 불러온다.
    {
        for (int i = 0; i < slots.Length; i++) //아이템을 먹으면 슬롯에 계속해서 추가한다. 
        {
            if (slots[i].item != null) //만약 아이템의 슬롯이 비었으면
            {
                if (slots[i].item.itemName == _item.itemName) //만약 아이템의 이름 슬롯이 비었으면
                {
                    slots[i].SetSlotCount(_count); //슬롯에 나타나는 아이템 갯수를 증가하거나 감소시켜준다.
                    return;
                }
            }
        }

        for (int i = 0; i < slots.Length; i++) //아이템을 먹으면 슬롯에 계속해서 추가한다. 
        {
            if (slots[i].item == null) //만약 아이템의 슬롯이 비었으면
            {
                slots[i].AddItem(_item, _count); //슬롯에 나타나는 아이템 이미지를 증가하거나 감소시켜준다.
                return; //값을 되돌린다.
            }
        }
    }




}
