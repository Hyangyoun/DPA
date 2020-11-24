using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyItem : MonoBehaviour
{
    [Header("스크립트 설정")]
    public int scriptID;
    public int emotionID;
    public ScriptType scriptType;

    [Header("데이터베이스")]
    public bool needDatabase;
    public int needDatabaseID;

    [Header("줌인 설정")]
    public bool zoomIn;
    public int zoomInID;

    private PrintScript script;
    private GameManager gameManager;
    private ZoomIn zoom;
    private DataBaseManager dataBase;

    public enum ScriptType
    {
        PlayerScript,
        SystemScript
    }
    // S
    // Start is called before the first frame update
    void Start()
    {
        script = FindObjectOfType<PrintScript>();
        gameManager = FindObjectOfType<GameManager>();
        zoom = FindObjectOfType<ZoomIn>();
        dataBase = FindObjectOfType<DataBaseManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.unActive)
        {
            if(gameManager.hit.collider != null)
            {
                if (gameManager.hit.collider.gameObject.Equals(this.gameObject))
                {
                    if (needDatabase)
                    {
                        if (dataBase.switches[needDatabaseID])
                        {
                            if (scriptType.Equals(ScriptType.PlayerScript))
                            {
                                script.InputPlayerScript(scriptID, emotionID);
                            }
                            else if (scriptType.Equals(ScriptType.SystemScript))
                            {
                                script.InputSystemScript(scriptID);
                            }
                            if (zoomIn)
                            {
                                zoom.Zoom(zoomInID);
                            }
                            gameManager.unActive = false;
                        }
                        return;
                    }
                    else
                    {
                        if (scriptType.Equals(ScriptType.PlayerScript))
                        {
                            script.InputPlayerScript(scriptID, emotionID);
                        }
                        else if (scriptType.Equals(ScriptType.SystemScript))
                        {
                            script.InputSystemScript(scriptID);
                        }
                        if (zoomIn)
                        {
                            zoom.Zoom(zoomInID);
                        }
                    }
                    gameManager.unActive = false;
                }
            }
        }
    }
}
