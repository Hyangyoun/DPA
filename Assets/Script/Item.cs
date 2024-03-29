﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public int itemID;
    public string itemName;
    public Sprite itemIcon;
    public int itemCount;
    public ItemType itemType;

    public enum ItemType
    {
        One,
        Stack
    }
    public Item(int _ItemID, string _itemName, ItemType _ItemType, int _ItemCount = 1) //생성자로 아이템의 데이터베이스 구성 설정
    {
        itemID = _ItemID;
        itemName = _itemName;
        itemCount = _ItemCount;
        itemType = _ItemType;
        itemIcon = Resources.Load("Item/" + _ItemID.ToString(), typeof(Sprite)) as Sprite;
    }
}
