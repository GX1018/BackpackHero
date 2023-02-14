using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlots : MonoBehaviour
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
        if(InventoryManager.Instance.isLvup == true)
        {
            InventoryManager.Instance.lvUpPoint = 3;
            for(int i = 0; i<44; i++)
            {
                if(GameObject.Find($"{i+1}").GetComponent<InvenSlot>().isActive ==true&&GameObject.Find($"{i}").GetComponent<InvenSlot>().isActive==false)
                {
                    GameObject.Find($"{i}").GetComponent<InvenSlot>().isTemporary = true;
                }
            }
            for(int i =44; i>0; i--)
            {
                if(GameObject.Find($"{i-1}").GetComponent<InvenSlot>().isActive ==true&&GameObject.Find($"{i}").GetComponent<InvenSlot>().isActive==false)
                {
                    GameObject.Find($"{i}").GetComponent<InvenSlot>().isTemporary = true;
                }
            }
            for(int i = 0; i<36; i++)
            {
                if(GameObject.Find($"{i+9}").GetComponent<InvenSlot>().isActive ==true&&GameObject.Find($"{i}").GetComponent<InvenSlot>().isActive==false)
                {
                    GameObject.Find($"{i}").GetComponent<InvenSlot>().isTemporary = true;
                }
            }
            for(int i =44; i>8; i--)
            {
                if(GameObject.Find($"{i-9}").GetComponent<InvenSlot>().isActive ==true&&GameObject.Find($"{i}").GetComponent<InvenSlot>().isActive==false)
                {
                    GameObject.Find($"{i}").GetComponent<InvenSlot>().isTemporary = true;
                }
            }
            InventoryManager.Instance.isLvup = false;
        }
    }
}
