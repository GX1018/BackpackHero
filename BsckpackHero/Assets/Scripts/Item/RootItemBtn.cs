using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootItemBtn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RootItem()
    {
        InventoryManager.Instance.removeItem = true;
        InventoryManager.Instance.rootItemCheck = false;
        

    }
}
