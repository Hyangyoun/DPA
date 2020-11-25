using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPicup : MonoBehaviour
{

    [Header("아이템ID")]
    public int itemID;
    public int itemCount;

    [Header("오브젝트 처리 여부")]
    public bool destroy;

    [Header("스크립트 출력 설정")]
    public bool printScript;
    public int scriptID;
    public int emotionID;
    public ScriptType scriptType;

    [Header("줌인화면 설정")]
    public bool zoomIn;
    public int zoomInID;

    [Header("오디오 설정")]
    public bool audioSet;
    public string audioName;

    private Inventory inventory;
    private PrintScript script;
    private GameManager gameManager;
    private ZoomIn zoom;
    private AudioManager audioManager;

    public enum ScriptType
    {
        PlayerScript,
        SystemScript
    }
    // Start is called before the first frame update
    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        script = FindObjectOfType<PrintScript>();
        gameManager = FindObjectOfType<GameManager>();
        zoom = FindObjectOfType<ZoomIn>();
        audioManager = FindObjectOfType<AudioManager>();
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
                    if(itemCount > 1)
                    {
                        for(int i = 0;i<itemCount; i++)
                        {
                            inventory.GetanItem(itemID);
                        }
                    }
                    else
                    {
                        inventory.GetanItem(itemID, itemCount);
                    }
                    audioManager.Play(audioName);
                    if (printScript && scriptType.Equals(ScriptType.PlayerScript))
                    {
                        script.InputPlayerScript(scriptID, emotionID);
                        gameManager.unActive = false;
                    }
                    else if (printScript && scriptType.Equals(ScriptType.SystemScript))
                    {
                        script.InputSystemScript(scriptID);
                        if (zoomIn)
                        {
                            zoom.Zoom(zoomInID);
                        }
                        gameManager.unActive = false;
                    }
                    if (destroy)
                    {
                        this.gameObject.SetActive(false);
                    }
                    gameManager.unActive = false;
                    GetComponent<ItemPicup>().enabled = false;
                }
            }
        }
    }
}
