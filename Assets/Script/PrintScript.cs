using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintScript : MonoBehaviour
{
    public GameObject scriptImage;
    public Image emotion;
    public Text playerScript;
    private DataBaseManager dataBase;
    private ClickEvent gamemanager;
    private AudioManager audio;

    public static PrintScript instance;
    void Start()
    {
        instance = this;
        dataBase = FindObjectOfType<DataBaseManager>();
        gamemanager = FindObjectOfType<ClickEvent>();
        audio = FindObjectOfType<AudioManager>();
    }

    public void InputPlayerScript(int _scriptID,int _emotionID)
    {
        for(int i = 0; i <= dataBase.psList.Count; i++)
        {
            if (dataBase.psList[i].scriptID == _scriptID)
            {
                emotion.sprite = Resources.Load("UI/" + _emotionID.ToString(), typeof(Sprite)) as Sprite;
                StartCoroutine(PrintPlayerScript(dataBase.psList[i].script));
                return;
            }
        }
    }

    public void InputSystemScript(int _scriptID, int _emotionID)
    {
        for (int i = 0; i <= dataBase.ssList.Count; i++)
        {
            if (dataBase.ssList[i].scriptID == _scriptID)
            {
                scriptImage.SetActive(true);
                playerScript.text = dataBase.ssList[i].script;
                return;
            }
        }
    }

    IEnumerator PrintPlayerScript(string script)
    {
        scriptImage.SetActive(true);
        gamemanager.enabled = false;
        playerScript.text = "";
        for(int i = 0; i<script.Length; i++)
        {
            playerScript.text += script[i];
            audio.Play("키보드소리");
            yield return new WaitForSeconds(0.05f);
        }
    }
    public void HideScript()
    {
        scriptImage.SetActive(false);
        gamemanager.enabled = true;
    }
}
