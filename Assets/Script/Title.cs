using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public GameObject text;
    private Animator anim;
    bool touch = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(TouchStart());
    }

    // Update is called once per frame
    void Update()
    {
        if (touch&&Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Goto");
            StartCoroutine(GotoPrologue());
        }
    }

    IEnumerator TouchStart()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("맞나?");
        text.SetActive(true);
        touch = true;
    }
    IEnumerator GotoPrologue()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Prologue");
    }
}
