using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_Slot : MonoBehaviour
{
    public Image icon;
    public Text itemName;
    public Text itemCount;
    public GameObject selected_Item;

    public void Additem(Item _item) //넘어온 데이터의 아이템 값
    {
        itemName.text = _item.itemName;
        icon.sprite = _item.itemIcon;
        if (Item.ItemType.Stack == _item.itemType)
        {
            if (_item.itemCount > 1)
                itemCount.text = "x " + _item.itemCount.ToString();
            else
                itemCount.text = "";
        }
    }

    public void RemoveItem() //아이템 초기화
    {
        itemName.text = "";
        itemCount.text = "";
        icon.sprite = null;
    }
}
