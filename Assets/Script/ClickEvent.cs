using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ObjectData
{
    public GameObject defualtObject;
    public GameObject changeObject;
    public ObjectType objectType;
    public int itemID;
    public int scriptID;
    public int emotionID;
    public int needData;
    public bool Change;
    public bool dataChange;

    public enum ObjectType
    {
        Change,
        Dumy,
        NeedItem,
        NeedDataBase,
        ItemPickup
    }
}

public class ClickEvent : MonoBehaviour
{
    DataBaseManager dataBase;
    Inventory inventory;
    public List<ObjectData> obList = new List<ObjectData>();
    // Start is called before the first frame update
    void Start()
    {
        dataBase = FindObjectOfType<DataBaseManager>();
        inventory = FindObjectOfType<Inventory>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Click();
        }
    }

    void Click()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
        if(hit.collider != null)
        {
            Debug.Log(hit.collider.gameObject);
            for (int i = 0; i < obList.Count; i++)
            {
                if (obList[i].defualtObject == null)
                {

                }
                else if (hit.collider.gameObject == obList[i].defualtObject)
                {
                    switch (obList[i].objectType)
                    {
                        case ObjectData.ObjectType.Change:
                            {
                                obList[i].defualtObject.SetActive(false);
                                obList[i].changeObject.SetActive(true);
                                break;
                            }
                        case ObjectData.ObjectType.Dumy:
                            {
                                PrintScript.instance.InputSystemScript(obList[i].scriptID,obList[i].emotionID);
                                break;
                            }
                        case ObjectData.ObjectType.ItemPickup:
                            {
                                Inventory.instance.GetanItem(obList[i].itemID);
                                Destroy(obList[i].defualtObject);
                                if (obList[i].Change)
                                {
                                    PrintScript.instance.InputPlayerScript(obList[i].scriptID, obList[i].emotionID);
                                }
                                break;
                            }
                        case ObjectData.ObjectType.NeedDataBase:
                            {
                                if (dataBase.switches[obList[i].needData])
                                {
                                    obList[i].defualtObject.SetActive(false);
                                    obList[i].changeObject.SetActive(true);
                                }
                                break;
                            }
                        case ObjectData.ObjectType.NeedItem:
                            {
                                if (inventory.activateItem)
                                {
                                    if (inventory.inventoryItemList[inventory.selectedItem].itemID.Equals( obList[i].itemID))
                                    {
                                        obList[i].changeObject.SetActive(true);
                                        inventory.UseItem();
                                        if (obList[i].Change)
                                        {
                                            obList[i].defualtObject.SetActive(false);
                                        }
                                        if (obList[i].dataChange)
                                        {
                                            dataBase.switches[obList[i].needData] = !dataBase.switches[obList[i].needData];
                                        }
                                    }
                                    else
                                    {
                                        if (obList[i].scriptID != 0)
                                        {
                                            PrintScript.instance.InputPlayerScript(obList[i].scriptID, obList[i].emotionID);
                                        }
                                    }
                                }
                                else
                                {
                                    if (obList[i].scriptID != 0)
                                    {
                                        PrintScript.instance.InputPlayerScript(obList[i].scriptID, obList[i].emotionID);
                                    }
                                }
                                break;
                            }
                    }
                    return;
                }
                Debug.Log("한번 돌았음");
            }
        }
    }
}
