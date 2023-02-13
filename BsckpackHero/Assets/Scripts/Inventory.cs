using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    
    public GameObject slotPrefab;
    // Start is called before the first frame update
    void Start()
    {
        slotPrefab = Resources.Load<GameObject>("Prefabs/InvenSlot");
        for(int i = 0; i <45; i++)
        {
            GameObject invenSlot = Instantiate(slotPrefab, gameObject.transform);
            invenSlot.name = i.ToString();
            
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
