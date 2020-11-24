using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GotoEnding : MonoBehaviour
{
    public GameObject fade_;
    public Image fade;
    private DataBaseManager dataBase;
    public bool callone = true;
    // Start is called before the first frame update
    void Start()
    {
        dataBase = FindObjectOfType<DataBaseManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (callone)
        {
            if (dataBase.switches[1])
            {
                fade_.SetActive(true);
                fade.color = new Color(0, 0, 0, Mathf.Lerp(fade.color.a, 1, 3*Time.deltaTime));
                if(fade.color.a >= 0.9999f)
                {
                    SceneManager.LoadScene("Epilogue");
                    callone = false;
                }
            }
        }
    }
}
