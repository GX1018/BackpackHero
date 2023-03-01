using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemRootBtn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    GameObject fieldItems;
    GameObject inventoryItems;
    List<GameObject> inventoryItemsList;
    bool activeCheck;

    // Start is called before the first frame update

    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (activeCheck)
        {
            fieldItems = ItemManager.Instance.fieldItems;
            inventoryItems = ItemManager.Instance.inventoryItems;
            inventoryItemsList = ItemManager.Instance.inventoryItemsList;
            activeCheck = false;
        }
    }

    private void OnEnable()
    {
        activeCheck = true;
    }



    public void OnPointerDown(PointerEventData eventData)
    {
        for (int i = 0; i < fieldItems.transform.childCount; i++)
        {
            if (fieldItems.transform.GetChild(i).tag == "GainedItem")
            {
                inventoryItemsList.Add(fieldItems.transform.GetChild(i).gameObject);
                //fieldItems.GetChild(i).transform.parent = inventoryItems;
            }

        }

        InventoryManager.Instance.removeItem = true;

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        InventoryManager.Instance.removeItem = false;
        gameObject.SetActive(false);

    }
}
