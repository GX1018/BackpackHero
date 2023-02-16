using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlots : MonoBehaviour
{
    public GameObject slotPrefab;
    GameObject[,] itemSlot2DArray;


    // Start is called before the first frame update
    void Start()
    {
        slotPrefab = Resources.Load<GameObject>("Prefabs/InvenSlot");

        itemSlot2DArray = InventoryManager.Instance.itemSlot2DArray;

        int count = 0;
        for (int y = 0; y < itemSlot2DArray.GetLength(1); y++)  //7
        {
            for (int x = 0; x < itemSlot2DArray.GetLength(0); x++)  //11
            {
                GameObject invenSlot = Instantiate(slotPrefab, gameObject.transform);
                invenSlot.name = count.ToString();
                itemSlot2DArray[x, y] = invenSlot;
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
            InventoryExpand();
        }

    }
    private void InventoryExpand()
    {
        InventoryManager.Instance.lvUpPoint = 3;

        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<InvenSlot>().isActive == true && transform.GetChild(i).GetComponent<InvenSlot>().xInArray > 1
            && transform.GetChild(i).GetComponent<InvenSlot>().xInArray < 9 && transform.GetChild(i).GetComponent<InvenSlot>().yInArray > 1
            && transform.GetChild(i).GetComponent<InvenSlot>().yInArray < 5)
            {
                if (itemSlot2DArray[transform.GetChild(i).GetComponent<InvenSlot>().xInArray - 1, transform.GetChild(i).GetComponent<InvenSlot>().yInArray].GetComponent<InvenSlot>().isActive == false)
                {
                    itemSlot2DArray[transform.GetChild(i).GetComponent<InvenSlot>().xInArray - 1, transform.GetChild(i).GetComponent<InvenSlot>().yInArray].GetComponent<InvenSlot>().isTemporary = true;
                }

                if (itemSlot2DArray[transform.GetChild(i).GetComponent<InvenSlot>().xInArray + 1, transform.GetChild(i).GetComponent<InvenSlot>().yInArray].GetComponent<InvenSlot>().isActive == false)
                {
                    itemSlot2DArray[transform.GetChild(i).GetComponent<InvenSlot>().xInArray + 1, transform.GetChild(i).GetComponent<InvenSlot>().yInArray].GetComponent<InvenSlot>().isTemporary = true;
                }

                if (itemSlot2DArray[transform.GetChild(i).GetComponent<InvenSlot>().xInArray, transform.GetChild(i).GetComponent<InvenSlot>().yInArray - 1].GetComponent<InvenSlot>().isActive == false)
                {
                    itemSlot2DArray[transform.GetChild(i).GetComponent<InvenSlot>().xInArray, transform.GetChild(i).GetComponent<InvenSlot>().yInArray - 1].GetComponent<InvenSlot>().isTemporary = true;
                }

                if (itemSlot2DArray[transform.GetChild(i).GetComponent<InvenSlot>().xInArray, transform.GetChild(i).GetComponent<InvenSlot>().yInArray + 1].GetComponent<InvenSlot>().isActive == false)
                {
                    itemSlot2DArray[transform.GetChild(i).GetComponent<InvenSlot>().xInArray, transform.GetChild(i).GetComponent<InvenSlot>().yInArray + 1].GetComponent<InvenSlot>().isTemporary = true;
                }
            }
        }
        InventoryManager.Instance.isLvup = false;
    }


}

