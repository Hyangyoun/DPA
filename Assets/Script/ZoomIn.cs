using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomIn : MonoBehaviour
{
    public GameObject zoomBack;
    public Image zoomImage;
    public void Zoom(int _imageID)
    {
        zoomImage.sprite = Resources.Load("Zoomin/" + _imageID.ToString(), typeof(Sprite)) as Sprite;
        zoomBack.gameObject.SetActive(true);
    }
}
