using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItems : MonoBehaviour
{
    public List<GameObject> inventoryItemsList;
    // Start is called before the first frame update
    void Start()
    {
        ItemManager.Instance.inventoryItems = this.gameObject;
        ItemManager.Instance.inventoryItemsList = inventoryItemsList;
    }

    // Update is called once per frame
    void Update()
    {
        RemoveItem();
    }

    public void RemoveItem()
    {
        if (InventoryManager.Instance.removeItem == true)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (transform.GetChild(i).tag != "GainedItem" )
                {
                    Destroy(transform.GetChild(i).gameObject);
                }
            }
        }
    }
}
