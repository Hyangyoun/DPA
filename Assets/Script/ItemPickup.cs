using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public int itemID;
    ClickEvent clickEvent;
    private AudioManager audio;
    // Start is called before the first frame update
    void Start()
    {
        clickEvent = FindObjectOfType<ClickEvent>();
        audio = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ClickItem();
            }
        }
    }
    void ClickItem()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject == this.gameObject) // 클릭한 오브젝트가 맞는지 감지
            {
                Inventory.instance.GetanItem(itemID); // 인벤토리 클래스로 값 전달
                Destroy(hit.collider.gameObject);
                audio.Play("아이템획득");
            }
        }
    } //아이템 클릭 및 상호작용
}
