using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBaseManager : MonoBehaviour
{
    static public DataBaseManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
    }
    public string[] var_name;
    public float[] var;

    public string[] switch_name;
    public bool[] switches;

    public List<Item> itemList = new List<Item>();
    // Start is called before the first frame update
    void Start()
    {
        itemList.Add(new Item(10001, "낮은의자",Item.ItemType.One));
        itemList.Add(new Item(10002, "C형 건전지", Item.ItemType.Stack));
        itemList.Add(new Item(10003, "손전등", Item.ItemType.One));
        itemList.Add(new Item(10004, "AA건전지", Item.ItemType.Stack));
        itemList.Add(new Item(10005, "열쇠", Item.ItemType.One));
        itemList.Add(new Item(10006, "토끼인형", Item.ItemType.One));
    }
}
