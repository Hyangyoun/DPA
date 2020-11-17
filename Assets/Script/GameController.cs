using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject option;
    [SerializeField] private Transform scene1;
    [SerializeField] private Transform scene2;
    [SerializeField] private Transform scene3;
    [SerializeField] private Transform scene4;
    [SerializeField] private Transform camera_pos;
    [SerializeField] private RectTransform inven;
    public Image fadeIn;
    public int thisscene = 1;
    bool inventrue = false;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine("StartFadeIn");
        camera_pos.position = scene1.position;
        camera_pos.Translate(0, 0, -10);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ClickOption()
    {
        option.SetActive(true);
    }
    public void ClickOptionClose()
    {
        option.SetActive(false);
    }
    public void Right()
    {
        if (thisscene <= 1)
        {
            Scene2();
            thisscene++;
        }
        else if (thisscene == 2)
        {
            Scene3();
            thisscene++;
        }
        else if (thisscene == 3)
        {
            Scene4();
            thisscene++;
        }
        else if (thisscene >= 4)
        {
            Scene1();
            thisscene = 1;
        }
    }
    public void Left()
    {
        if (thisscene <= 1)
        {
            Scene4();
            thisscene = 4;
        }
        else if (thisscene == 2)
        {
            Scene1();
            thisscene--;
        }
        else if (thisscene == 3)
        {
            Scene2();
            thisscene--;
        }
        else if (thisscene >= 4)
        {
            Scene3();
            thisscene--;
        }
    }
    void Scene1()
    {
        camera_pos.position = scene1.position;
        camera_pos.Translate(0, 0, -10);
    }
    void Scene2()
    {
        camera_pos.position = scene2.position;
        camera_pos.Translate(0, 0, -10);
    }
    void Scene3()
    {
        camera_pos.position = scene3.position;
        camera_pos.Translate(0, 0, -10);
    }
    void Scene4()
    {
        camera_pos.position = scene4.position;
        camera_pos.Translate(0, 0, -10);
    }
    public void Inventory()
    {
        StartCoroutine("Inventory_ctrl");
    }
    IEnumerator Inventory_ctrl()
    {
        Vector2 openPos = new Vector2(0, 71);
        Vector2 closePos = new Vector2(0, -54);
        while (true)
        {
            if (inventrue)
            {
                inven.anchoredPosition = Vector2.Lerp(inven.anchoredPosition, closePos, Time.deltaTime*3);
                if (inven.anchoredPosition.y <= -53.998)
                {
                    inventrue = false;
                    yield break;
                }
            }
            else if (!inventrue)
            {
                inven.anchoredPosition = Vector2.Lerp(inven.anchoredPosition, openPos, Time.deltaTime*3);
                if (inven.anchoredPosition.y >= 70.998)
                {
                    inventrue = true;
                    yield break;
                }
            }
            yield return new WaitForFixedUpdate();
        }
    }

    //페이드아웃효과 개발때문에 잠시 주석처리(주석 풀어야됨)
    /*IEnumerator StartFadeIn()
    {
        while (fadeIn.color.a >= 0.0001)
        {
            fadeIn.color = new Color(0, 0, 0, Mathf.Lerp(fadeIn.color.a, 0, Time.deltaTime*3));
            yield return new WaitForFixedUpdate();
        }
        GameObject.Find("Fade").SetActive(false);
    }*/
}
