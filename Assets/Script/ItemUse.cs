using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUse : MonoBehaviour
{
    public int useID;
    private Inventory inventory;
    private DataBaseManager database;
    public GameObject chair;
    // Start is called before the first frame update
    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        database = FindObjectOfType<DataBaseManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TouchObject();
        }
    }
    void TouchObject()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D ray = Physics2D.Raycast(pos, Vector2.zero);
        if(ray.collider != null)
        {
            if (ray.collider.gameObject == this.gameObject)
            {
                switch (useID)
                {
                    case 1001:
                        if (inventory.activateItem)
                        {
                            if (inventory.inventoryItemList[inventory.selectedItem].itemID == 10001)
                            {
                                chair.SetActive(true);
                                database.switches[0] = true;
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        break;
                    case 1002:
                        if (inventory.activateItem)
                        {
                            if (inventory.inventoryItemList[inventory.selectedItem].itemID == 10002)
                            {
                                if (database.var[0] < 2)
                                {

                                }
                                else if(database.var[0] < 3)
                                {
                                    database.switches[1] = true;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                        break;
                    case 1003:
                        if (inventory.activateItem)
                        {
                            if (inventory.inventoryItemList[inventory.selectedItem].itemID == 10001)
                            {
                                chair.SetActive(true);
                                database.switches[0] = true;
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        break;
                    case 1004:
                        if (inventory.activateItem)
                        {
                            if (inventory.inventoryItemList[inventory.selectedItem].itemID == 10001)
                            {
                                chair.SetActive(true);
                                database.switches[0] = true;
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        break;
                }
                Inventory.instance.UseItem(useID);
            }
        } // 미완성코드
    }
}
