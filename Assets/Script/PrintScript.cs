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
    private GameManager gameManager;
    private AudioManager audio;
    private ZoomIn zoomIn;

    public static PrintScript instance;
    void Start()
    {
        instance = this;
        dataBase = FindObjectOfType<DataBaseManager>();
        audio = FindObjectOfType<AudioManager>();
        zoomIn = FindObjectOfType<ZoomIn>();
        gameManager = FindObjectOfType<GameManager>();
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

    public void InputSystemScript(int _scriptID, int _emotionID = 304)
    {
        for (int i = 0; i <= dataBase.ssList.Count; i++)
        {
            if (dataBase.ssList[i].scriptID == _scriptID)
            {
                emotion.sprite = Resources.Load("UI/" + _emotionID.ToString(), typeof(Sprite)) as Sprite;
                scriptImage.SetActive(true);
                playerScript.text = dataBase.ssList[i].script;
                return;
            }
        }
    }

    IEnumerator PrintPlayerScript(string script)
    {
        scriptImage.SetActive(true);
        gameManager.click = false;
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
        gameManager.click = true;
        zoomIn.zoomBack.SetActive(false);
    }
}
