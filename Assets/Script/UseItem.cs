using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    [Header("바꿀 오브젝트")]
    public GameObject changeObject;

    [Header("아이템ID")]
    public int itemID;

    [Header("복수아이템 필요시")]
    public bool needStack;
    public int needItemStack;

    [Header("데이타베이스 필요시")]
    public bool needData;
    public bool needSwitchData;
    public int needDataID;
    public int needSwitchDataID;

    [Header("오브젝트 처리 여부")]
    public bool change;
    public bool destroy;

    [Header("스크립트 출력 설정")]
    public bool printScript;
    public int scriptID;
    public int emotionID;
    public ScriptType scriptType;
    [Space]
    public int noItemScriptID;
    public int noItemEmotionID;
    public ScriptType _scriptType;

    [Header("오디오 설정")]
    public bool audioSet;
    public string audioName;
    [Space]
    public string noItemAudioName;

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
        inventory = FindObjectOfType<Inventory>();
        dataBase = FindObjectOfType<DataBaseManager>();
        script = FindObjectOfType<PrintScript>();
        gameManager = FindObjectOfType<GameManager>();
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
                                if (audioSet)
                                {
                                    audioManager.Play(audioName);
                                }
                                if (change)
                                {
                                    changeObject.SetActive(true);
                                    this.gameObject.SetActive(false);
                                }
                                else if (destroy)
                                {
                                    this.gameObject.SetActive(false);
                                }
                                gameManager.unActive = false;
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
                                    if (audioSet)
                                    {
                                        audioManager.Play(audioName);
                                    }
                                    if (change)
                                    {
                                        changeObject.SetActive(true);
                                        this.gameObject.SetActive(false);
                                    }
                                    else if (destroy)
                                    {
                                        this.gameObject.SetActive(false);
                                    }
                                }
                                gameManager.unActive = false;
                            }
                        }
                        else if (change)
                        {
                            if (printScript && scriptType.Equals(ScriptType.PlayerScript))
                            {
                                script.InputPlayerScript(scriptID, emotionID);
                            }
                            else if (printScript && scriptType.Equals(ScriptType.SystemScript))
                            {
                                script.InputSystemScript(scriptID);
                            }
                            if (audioSet)
                            {
                                audioManager.Play(audioName);
                            }
                            if (needSwitchData)
                            {
                                dataBase.switches[needSwitchDataID] = true;
                            }
                            inventory.UseItem(inventory.inventoryItemList[inventory.selectedItem].itemCount);
                            gameManager.unActive = false;
                            changeObject.SetActive(true);
                            this.gameObject.SetActive(false);
                        }
                        else if (destroy)
                        {
                            if (printScript && scriptType.Equals(ScriptType.PlayerScript))
                            {
                                script.InputPlayerScript(scriptID, emotionID);
                            }
                            else if (printScript && scriptType.Equals(ScriptType.SystemScript))
                            {
                                script.InputSystemScript(scriptID);
                            }
                            if (audioSet)
                            {
                                audioManager.Play(audioName);
                            }
                            if (needSwitchData)
                            {
                                dataBase.switches[needSwitchDataID] = true;
                            }
                            gameManager.unActive = false;
                            inventory.UseItem(inventory.inventoryItemList[inventory.selectedItem].itemCount);
                            this.gameObject.SetActive(false);
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
                            if (audioSet)
                            {
                                audioManager.Play(audioName);
                            }
                            if (needSwitchData)
                            {
                                dataBase.switches[needSwitchDataID] = true;
                            }
                            gameManager.unActive = false;
                            inventory.UseItem(inventory.inventoryItemList[inventory.selectedItem].itemCount);
                        }
                    }
                    else
                    {
                        if (printScript && _scriptType.Equals(ScriptType.PlayerScript))
                        {
                            script.InputPlayerScript(noItemScriptID,noItemEmotionID);
                        }
                        else if (printScript && scriptType.Equals(ScriptType.SystemScript))
                        {
                            script.InputSystemScript(noItemScriptID);
                        }
                        if (audioSet)
                        {
                            audioManager.Play(noItemAudioName);
                        }
                        gameManager.unActive = false;
                    }
                }
            }
        }
    }
}
