using System.Collections;
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
    public Item(int _ItemID, string _itemName, ItemType _ItemType, int _ItemCount = 1)
    {
        itemID = _ItemID;
        itemName = _itemName;
        itemCount = _ItemCount;
        itemType = _ItemType;
        itemIcon = Resources.Load("Item/" + _ItemID.ToString(), typeof(Sprite)) as Sprite;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
