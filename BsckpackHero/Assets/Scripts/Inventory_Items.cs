using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Items : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ItemManager.Instance.inventoryItems = this.gameObject;
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
                if (transform.GetChild(i).GetComponent<ItemTest>().itemProperty != "player")
                {
                    Destroy(transform.GetChild(i).gameObject);
                }
            }
            InventoryManager.Instance.removeItem = false;
        }
    }
}
