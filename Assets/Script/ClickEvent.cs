using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ObjectData
{
    public GameObject defualtObject;
    public GameObject changeObject;
    public ObjectType objectType;

    public enum ObjectType
    {
        Change,
        Dumy,
        NeedItem,
        NeedDataBase
    }
}

public class ClickEvent : MonoBehaviour
{
    DataBaseManager dataBase;
    public List<ObjectData> obList = new List<ObjectData>();
    // Start is called before the first frame update
    void Start()
    {
        dataBase = FindObjectOfType<DataBaseManager>();
    }
}
