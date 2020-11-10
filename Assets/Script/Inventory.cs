using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    private DataBaseManager theDataBase;

    private Inventory_Slot[] slots;

    private List<Item> inventoryItemList;

    public Transform tf;

    private int selectedItem;
    private bool activateItem = false;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        theDataBase = FindObjectOfType<DataBaseManager>();
        inventoryItemList = new List<Item>();
        slots = tf.GetComponentsInChildren<Inventory_Slot>();
    }

    public void GetanItem(int _ItemID,int _Count = 1) 
    {
        for(int i = 0; i < theDataBase.itemList.Count; i++) //데이터베이스 아이템 검색
        {
            if(_ItemID == theDataBase.itemList[i].itemID) //데이터 베이스에 아이템 발견
            {
                for (int j = 0; j > inventoryItemList.Count; j++) //중복아이템 섬사
                {
                    inventoryItemList[j].itemCount += _Count;
                    return;
                }
                inventoryItemList.Add(theDataBase.itemList[i]); //해당아이템 추가
                return;
            } 
        }
        Debug.LogError("데이터베이스에 해당 ID값을 가진 아이템이 존재하지 않습니다.");
    } //아이템 습득 함수

    public void RemoveSlot()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            slots[i].RemoveItem();
            slots[i].gameObject.SetActive(false);
        }
    } //슬롯 초기화 함수
    public void ShowItem()
    {
        RemoveSlot();
        for (int i = 0; i < inventoryItemList.Count; i++)
        {
            slots[i].gameObject.SetActive(true);
            slots[i].Additem(inventoryItemList[i]);
        }
    } //슬롯 아이템 지정 함수
    public void SelectedItem()
    {
        StopAllCoroutines();
        Color color = slots[0].selected_Item.GetComponent<Image>().color;
        color.a = 0f;
        for (int i = 0; i < inventoryItemList.Count; i++)
        {
            slots[i].selected_Item.GetComponent<Image>().color = color;
        }

        if(activateItem)
        {
            slots[selectedItem].selected_Item.GetComponent<Image>().color = new Color(255f, 255f, 255f, 255f);
        }
        else
        {
            return;
        }
    } //아이템 선택 함수
    public void SelectedNum(int i)
    {
        if(selectedItem == i)
        {
            activateItem = !activateItem;
        }
        else
        {
            selectedItem = i;
            activateItem = true;
        }
    } //아이템 선택상태,활성화 설정 함수
    // Update is called once per frame
    void Update()
    {
        ShowItem();
        SelectedItem();
    }
}
