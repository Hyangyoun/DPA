using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
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
    public RaycastHit2D hit;
    public bool click = true;
    public bool unActive = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("StartFadeIn");
        camera_pos.position = scene1.position;
        camera_pos.Translate(0, 0, -10);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (click)
            {
                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                hit = Physics2D.Raycast(pos, Vector2.zero);
                unActive = true;
                if(hit.collider != null)
                Debug.Log(hit.collider.name);
            }
        }
    }

    public void ClickOption()
    {
        option.SetActive(true);
        click = false;
    }
    public void ClickOptionClose()
    {
        option.SetActive(false);
        click = true;
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
        Animator anim = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Animator>();
        anim.SetTrigger("ClickButton");
    }
    //페이드아웃효과 개발때문에 잠시 주석처리(주석 풀어야됨)
    IEnumerator StartFadeIn()
    {
        while (fadeIn.color.a >= 0.0001)
        {
            fadeIn.color = new Color(0, 0, 0, Mathf.Lerp(fadeIn.color.a, 0, Time.deltaTime*3));
            yield return new WaitForFixedUpdate();
        }
        fadeIn.gameObject.SetActive(false);
    }
}
