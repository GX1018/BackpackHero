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
            InventoryExpand();
            /* 
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


            InventoryManager.Instance.isLvup = false; */
        }

    }
    private void InventoryExpand()
    {
        //이건 이미지 확장할때
        /* int compareX = 5;
        int minX = 0;
        int maxX = 0;
        int compareY = 3;
        int minY = 0;
        int maxY = 0;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<InvenSlot>().isActive == true)
            {
                if (compareX > transform.GetChild(i).GetComponent<InvenSlot>().xInArray)
                {
                    compareX = transform.GetChild(i).GetComponent<InvenSlot>().xInArray;
                    minX = compareX;
                }
                if (compareY > transform.GetChild(i).GetComponent<InvenSlot>().yInArray)
                {
                    compareY = transform.GetChild(i).GetComponent<InvenSlot>().yInArray;
                    minY = compareY;
                }
            }
        }

        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<InvenSlot>().isActive == true)
            {
                if (compareX < transform.GetChild(i).GetComponent<InvenSlot>().xInArray)
                {
                    compareX = transform.GetChild(i).GetComponent<InvenSlot>().xInArray;
                    maxX = compareX;
                }
                if (compareY < transform.GetChild(i).GetComponent<InvenSlot>().yInArray)
                {
                    compareY = transform.GetChild(i).GetComponent<InvenSlot>().yInArray;
                    maxY = compareY;
                }
            }
        }
        Debug.Log(minX);
        Debug.Log(minY);
        Debug.Log(maxX);
        Debug.Log(maxY); */
        //이미지 확장할때




        InventoryManager.Instance.lvUpPoint = 3;

        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<InvenSlot>().isActive == true && transform.GetChild(i).GetComponent<InvenSlot>().xInArray > 1
            && transform.GetChild(i).GetComponent<InvenSlot>().xInArray < 9 && transform.GetChild(i).GetComponent<InvenSlot>().yInArray > 1
            && transform.GetChild(i).GetComponent<InvenSlot>().yInArray < 5)
            {
                if (InventoryManager.Instance.itemSlot2DArray[transform.GetChild(i).GetComponent<InvenSlot>().xInArray - 1, transform.GetChild(i).GetComponent<InvenSlot>().yInArray].GetComponent<InvenSlot>().isActive == false)
                {
                    InventoryManager.Instance.itemSlot2DArray[transform.GetChild(i).GetComponent<InvenSlot>().xInArray - 1, transform.GetChild(i).GetComponent<InvenSlot>().yInArray].GetComponent<InvenSlot>().isTemporary = true;
                }

                if (InventoryManager.Instance.itemSlot2DArray[transform.GetChild(i).GetComponent<InvenSlot>().xInArray + 1, transform.GetChild(i).GetComponent<InvenSlot>().yInArray].GetComponent<InvenSlot>().isActive == false)
                {
                    InventoryManager.Instance.itemSlot2DArray[transform.GetChild(i).GetComponent<InvenSlot>().xInArray + 1, transform.GetChild(i).GetComponent<InvenSlot>().yInArray].GetComponent<InvenSlot>().isTemporary = true;
                }

                if (InventoryManager.Instance.itemSlot2DArray[transform.GetChild(i).GetComponent<InvenSlot>().xInArray, transform.GetChild(i).GetComponent<InvenSlot>().yInArray - 1].GetComponent<InvenSlot>().isActive == false)
                {
                    InventoryManager.Instance.itemSlot2DArray[transform.GetChild(i).GetComponent<InvenSlot>().xInArray, transform.GetChild(i).GetComponent<InvenSlot>().yInArray - 1].GetComponent<InvenSlot>().isTemporary = true;
                }

                if (InventoryManager.Instance.itemSlot2DArray[transform.GetChild(i).GetComponent<InvenSlot>().xInArray, transform.GetChild(i).GetComponent<InvenSlot>().yInArray + 1].GetComponent<InvenSlot>().isActive == false)
                {
                    InventoryManager.Instance.itemSlot2DArray[transform.GetChild(i).GetComponent<InvenSlot>().xInArray, transform.GetChild(i).GetComponent<InvenSlot>().yInArray + 1].GetComponent<InvenSlot>().isTemporary = true;
                }
            }
        }
        InventoryManager.Instance.isLvup = false;
    }


}

