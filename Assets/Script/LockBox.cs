using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockBox : MonoBehaviour
{
    [Header("바꿀 오브젝트")]
    public GameObject changeObject;

    [Header("아이템ID")]
    public int itemID;

    [Header("복수사이템 필요시")]
    public bool needStack;
    public int needItemStack;

    [Header("데이타베이스 필요시")]
    public bool needData;
    public int needDataID;

    [Header("스크립트 출력 설정")]
    public bool printScript;
    public int scriptID;
    public int emotionID;
    public ScriptType scriptType;
    [Space]
    public int noItemScriptID;
    public int noItemEmotionID;
    public ScriptType _scriptType;

    private Inventory inventory;
    private DataBaseManager dataBase;
    private PrintScript script;
    private GameManager gameManager;
    private AudioManager audioManager;

    public enum ScriptType
    {
        PlayerScript,
        SystemScript
    }
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        dataBase = FindObjectOfType<DataBaseManager>();
        script = FindObjectOfType<PrintScript>();
        inventory = FindObjectOfType<Inventory>();
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
                    if (inventory.activateItem && inventory.inventoryItemList[inventory.selectedItem].itemID.Equals(itemID))
                    {
                        if (needStack)
                        {
                            if (needData && inventory.inventoryItemList[inventory.selectedItem].itemCount >= needItemStack)
                            {
                                inventory.UseItem(inventory.inventoryItemList[inventory.selectedItem].itemCount);
                                if (printScript && scriptType.Equals(ScriptType.PlayerScript))
                                {
                                    script.InputPlayerScript(scriptID, emotionID);
                                }
                                else if (printScript && scriptType.Equals(ScriptType.SystemScript))
                                {
                                    script.InputSystemScript(scriptID);
                                }
                                gameManager.unActive = false;
                                changeObject.SetActive(true);
                                audioManager.Play("금고활성화");
                                dataBase.switches[2] = true;
                                gameManager.click = false;
                            }
                            else if (needData && inventory.inventoryItemList[inventory.selectedItem].itemCount < needItemStack)
                            {
                                dataBase.var[needDataID] += inventory.inventoryItemList[inventory.selectedItem].itemCount;
                                inventory.UseItem(inventory.inventoryItemList[inventory.selectedItem].itemCount);
                                if (printScript && scriptType.Equals(ScriptType.PlayerScript))
                                {
                                    script.InputPlayerScript(scriptID, emotionID);
                                }
                                else if (printScript && scriptType.Equals(ScriptType.SystemScript))
                                {
                                    script.InputSystemScript(scriptID);
                                }
                                if (dataBase.var[needDataID] >= needItemStack)
                                {
                                    changeObject.SetActive(true);
                                    audioManager.Play("금고활성화");
                                    dataBase.switches[2] = true;
                                    gameManager.click = false;
                                }
                                gameManager.unActive = false;
                            }
                        }
                    }
                    else if (dataBase.switches[2])
                    {
                        changeObject.SetActive(true);
                        audioManager.Play("금고활성화");
                        gameManager.click = false;
                        gameManager.unActive = false;
                    }
                    else
                    {
                        script.InputSystemScript(noItemScriptID);
                        gameManager.unActive = false;
                    }
                }
            }
        }
    }
}
