using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintScript : MonoBehaviour
{
    public GameObject image;
    public Text playerScript;
    private DataBaseManager dataBase;

    public static PrintScript instance;
    void Start()
    {
        instance = this;
        dataBase = FindObjectOfType<DataBaseManager>();
    }

    public void InputPlayerScript(int _scriptID)
    {
        for(int i = 0; i <= dataBase.psList.Count; i++)
        {
            if (dataBase.psList[i].scriptID == _scriptID)
            {
                StartCoroutine(PrintPlayerScript(dataBase.psList[i].script));
                return;
            }
        }
    }

    public void InputSystemScript(int _scriptID)
    {
        for (int i = 0; i <= dataBase.ssList.Count; i++)
        {
            if (dataBase.ssList[i].scriptID == _scriptID)
            {
                image.SetActive(true);
                playerScript.text = dataBase.ssList[i].script;
                return;
            }
        }
    }

    IEnumerator PrintPlayerScript(string script)
    {
        image.SetActive(true);
        playerScript.text = "";
        for(int i = 0; i<script.Length; i++)
        {
            playerScript.text += script[i];
            yield return new WaitForFixedUpdate();
        }
    }
}
