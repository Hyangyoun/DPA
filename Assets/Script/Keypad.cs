using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{
    public GameObject gumgo;
    public GameObject open_gumgo;
    public GameObject[] number;
    public Text text;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
            if(hit.collider != null)
            {
                if (hit.collider.gameObject.Equals(number[0]))
                {
                    if (text.text.Length >= 8)
                    {
                        return;
                    }
                    else
                    {
                        text.text += "0";
                    }
                }
                else if (hit.collider.gameObject.Equals(number[1]))
                {
                    if (text.text.Length >= 8)
                    {
                        return;
                    }
                    else
                    {
                        text.text += "1";
                    }
                }
                else if (hit.collider.gameObject.Equals(number[2]))
                {
                    if (text.text.Length >= 8)
                    {
                        return;
                    }
                    else
                    {
                        text.text += "2";
                    }
                }
                else if (hit.collider.gameObject.Equals(number[3]))
                {
                    if (text.text.Length >= 8)
                    {
                        return;
                    }
                    else
                    {
                        text.text += "3";
                    }
                }
                else if (hit.collider.gameObject.Equals(number[4]))
                {
                    if (text.text.Length >= 8)
                    {
                        return;
                    }
                    else
                    {
                        text.text += "4";
                    }
                }
                else if (hit.collider.gameObject.Equals(number[5]))
                {
                    if (text.text.Length >= 8)
                    {
                        return;
                    }
                    else
                    {
                        text.text += "5";
                    }
                }
                else if (hit.collider.gameObject.Equals(number[6]))
                {
                    if (text.text.Length >= 8)
                    {
                        return;
                    }
                    else
                    {
                        text.text += "6";
                    }
                }
                else if (hit.collider.gameObject.Equals(number[7]))
                {
                    if (text.text.Length >= 8)
                    {
                        return;
                    }
                    else
                    {
                        text.text += "7";
                    }
                }
                else if (hit.collider.gameObject.Equals(number[8]))
                {
                    if (text.text.Length >= 8)
                    {
                        return;
                    }
                    else
                    {
                        text.text += "8";
                    }
                }
                else if (hit.collider.gameObject.Equals(number[9]))
                {
                    if (text.text.Length >= 8)
                    {
                        return;
                    }
                    else
                    {
                        text.text += "9";
                    }
                }
                else if (hit.collider.gameObject.Equals(number[10]))
                {
                    text.text = text.text.Substring(0, text.text.Length - 1);
                }
                else if (hit.collider.gameObject.Equals(number[11]))
                {
                    if (text.text.Equals("4131120"))
                    {
                        open_gumgo.SetActive(true);
                        gumgo.SetActive(false);
                        gameManager.click = true;
                        this.gameObject.SetActive(false);
                    }
                    else
                    {
                        text.text = "";
                        return;
                    }
                }

            }
        }
    }
}
