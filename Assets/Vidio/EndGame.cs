using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public Image fade;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("StartGame");
    }

    IEnumerator StartGame()
    {

        yield return new WaitForSeconds(20f);
        while (fade.color.a <= 0.9999f)
        {
            fade.color = new Color(0, 0, 0, Mathf.Lerp(fade.color.a, 1, Time.deltaTime * 3));
            yield return new WaitForFixedUpdate();
        }
        Application.Quit();
    }
}