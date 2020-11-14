using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEvent : MonoBehaviour
{
    [SerializeField] private GameObject[] newObject;
    [SerializeField] private GameObject[] gameObjects;
    private DataBaseManager dataBase;
    public int dataBaseNumber;
    // Start is called before the first frame update
    void Start()
    {
        dataBase = FindObjectOfType<DataBaseManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _ClickEvent();
        }
    }
    void _ClickEvent()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D ray = Physics2D.Raycast(pos, Vector2.zero);
        if (ray.collider != null)
        {
            for(int i =0;i < gameObjects.Length; i++)
            {
                if(ray.collider.gameObject == gameObjects[i])
                {
                    if (dataBase.switches[dataBaseNumber])
                    {
                        Destroy(gameObjects[i]);
                        newObject[i].SetActive(true);
                    }
                }
            }
        }
    }
}
