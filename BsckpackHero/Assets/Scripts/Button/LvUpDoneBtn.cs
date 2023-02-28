using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LvUpDoneBtn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Start is called before the first frame update
    void Start()
    {
        ButtonManager.Instance.lvUpDoneBtn = this.gameObject;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }



    public void OnPointerDown(PointerEventData eventData)
    {
        InventoryManager.Instance.moveCheckInt = 2;
        InventoryManager.Instance.isExpand =false;
        InventoryManager.Instance.isLvup = false;

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //인벤토리 하이라키 원래대로
        GameObject.Find("Inventory&Map").transform.SetSiblingIndex(1);
        
        GameObject.Find("OnOffUi").transform.GetChild(1).gameObject.SetActive(false);
        gameObject.SetActive(false);

    }
}
