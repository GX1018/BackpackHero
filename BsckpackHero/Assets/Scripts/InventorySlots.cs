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
        /* for (int i = 0; i < 77; i++)
        {
            GameObject invenSlot = Instantiate(slotPrefab, gameObject.transform);
            invenSlot.name = i.ToString();

        } */
        //슬롯 배열에 넣기?
        int count = 0;
        for (int y = 0; y < InventoryManager.Instance.itemSlot2DArray.GetLength(1); y++)  //7
        {
            for (int x = 0; x < InventoryManager.Instance.itemSlot2DArray.GetLength(0); x++)  //11
            {
                GameObject invenSlot = Instantiate(slotPrefab, gameObject.transform);
                invenSlot.name = count.ToString();
                InventoryManager.Instance.itemSlot2DArray[x, y] = invenSlot;
                count++;
            }
        }
        //슬롯 배열에 넣기?
    }

    // Update is called once per frame
    void Update()
    {
        if (InventoryManager.Instance.isLvup == true)
        {
            InventoryManager.Instance.lvUpPoint = 3;
            for (int i = 12; i < 64; i++)
            {
                if (GameObject.Find($"{i + 1}").GetComponent<InvenSlot>().isActive == true && GameObject.Find($"{i}").GetComponent<InvenSlot>().isActive == false)
                {
                    GameObject.Find($"{i}").GetComponent<InvenSlot>().isTemporary = true;
                }
            }
            for (int i = 64; i > 12; i--)
            {
                if (GameObject.Find($"{i - 1}").GetComponent<InvenSlot>().isActive == true && GameObject.Find($"{i}").GetComponent<InvenSlot>().isActive == false)
                {
                    GameObject.Find($"{i}").GetComponent<InvenSlot>().isTemporary = true;
                }
            }
            for (int i = 12; i < 54; i++)
            {
                if (GameObject.Find($"{i + 11}").GetComponent<InvenSlot>().isActive == true && GameObject.Find($"{i}").GetComponent<InvenSlot>().isActive == false)
                {
                    GameObject.Find($"{i}").GetComponent<InvenSlot>().isTemporary = true;
                }
            }
            for (int i = 64; i > 22; i--)
            {
                if (GameObject.Find($"{i - 11}").GetComponent<InvenSlot>().isActive == true && GameObject.Find($"{i}").GetComponent<InvenSlot>().isActive == false)
                {
                    GameObject.Find($"{i}").GetComponent<InvenSlot>().isTemporary = true;
                }
            }

            for (int i = 0; i < 7; i++)
            {
                GameObject.Find($"{i * 11}").GetComponent<InvenSlot>().isTemporary = false;
                GameObject.Find($"{i * 11 + 10}").GetComponent<InvenSlot>().isTemporary = false;
            }


            InventoryManager.Instance.isLvup = false;
        }
    }
}
