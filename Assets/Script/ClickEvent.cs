using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEvent : MonoBehaviour
{
    public static ClickEvent instans;
    [SerializeField] private GameObject[] newObject;
    public GameObject[] gameObjects;
    public bool click;
    DataBaseManager dataBase;
    // Start is called before the first frame update
    void Start()
    {
        dataBase = FindObjectOfType<DataBaseManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!click)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _ClickEvent();
            }
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
                    switch (i)
                    {
                        case 2:
                            if (dataBase.switches[0])
                            {
                                Destroy(gameObjects[i]);
                                newObject[i].SetActive(true);
                                click = true;
                                StartCoroutine(ClickDelay());
                            }
                            break;
                        default:
                            Destroy(gameObjects[i]);
                            newObject[i].SetActive(true);
                            click = true;
                            StartCoroutine(ClickDelay());
                            break;
                    }
                }
            }
        }
    }
    IEnumerator ClickDelay()
    {
        yield return new WaitForSeconds(0.3f);
        click = false;
    }
}
