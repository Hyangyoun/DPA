using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change : MonoBehaviour
{
    [Header("바꿀 오브젝트")]
    public GameObject changeObject;

    [Header("데이타베이스 필요시")]
    public bool needData;
    public int needDataID;

    [Header("스크립트 출력 설정")]
    public bool printScript;
    public int scriptID;
    public int emotionID;
    public ScriptType scriptType;

    private DataBaseManager dataBase;
    private PrintScript script;
    private GameManager gameManager;
    public enum ScriptType
    {
        PlayerScript,
        SystemScript
    }
    // Start is called before the first frame update
    void Start()
    {
        dataBase = FindObjectOfType<DataBaseManager>();
        script = FindObjectOfType<PrintScript>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.unActive)
        {
            if (gameManager.hit.collider != null)
            {
                if (gameManager.hit.collider.gameObject.Equals(this.gameObject))
                {
                    if (needData)
                    {
                        if (dataBase.switches[needDataID])
                        {
                            if (printScript && scriptType.Equals(ScriptType.PlayerScript))
                            {
                                script.InputPlayerScript(scriptID, emotionID);
                            }
                            else if (printScript && scriptType.Equals(ScriptType.SystemScript))
                            {
                                script.InputSystemScript(scriptID);
                            }
                            changeObject.SetActive(true);
                            this.gameObject.SetActive(false);
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (printScript && scriptType.Equals(ScriptType.PlayerScript))
                        {
                            script.InputPlayerScript(scriptID, emotionID);
                        }
                        else if (printScript && scriptType.Equals(ScriptType.SystemScript))
                        {
                            script.InputSystemScript(scriptID);
                        }
                        changeObject.SetActive(true);
                        this.gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}
