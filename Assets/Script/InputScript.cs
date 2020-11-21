using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputScript : MonoBehaviour
{
    int scriptid = 105;

    public void Click()
    {
        PrintScript.instance.InputPlayerScript(scriptid);
    }
}
