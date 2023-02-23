using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryImg : MonoBehaviour
{
    Transform slots;

    RectTransform rectTransform;
    RectTransform childRectTransform;

    //
    int compareX;
    int minX;
    int maxX;
    int compareY;
    int minY;
    int maxY;
    //

    //
    Vector2 originSize;
    Vector2 childOriginSize;
    Vector2 originPos;

    //

    


    void Start()
    {
        slots = GameObject.Find("InventorySlots").transform;

        rectTransform = gameObject.GetComponent<RectTransform>();
        childRectTransform = transform.GetChild(0).gameObject.GetComponent<RectTransform>();
        //
        originSize = rectTransform.sizeDelta;
        childOriginSize = childRectTransform.sizeDelta;
        originPos = rectTransform.anchoredPosition;
    }
    void Update()
    {
        FindMinMax();
        InvenImgExpand();

        
    }

    public void FindMinMax()
    {
        compareX = 5;
        minX = 0;
        maxX = 0;
        compareY = 3;
        minY = 0;
        maxY = 0;


        for (int i = 0; i < slots.childCount; i++)
        {
            if (slots.GetChild(i).GetComponent<InvenSlot>().isActive == true)
            {
                if (compareX > slots.GetChild(i).GetComponent<InvenSlot>().xInArray)
                {
                    compareX = slots.GetChild(i).GetComponent<InvenSlot>().xInArray;
                    minX = compareX;
                }
                if (compareY > slots.GetChild(i).GetComponent<InvenSlot>().yInArray)
                {
                    compareY = slots.GetChild(i).GetComponent<InvenSlot>().yInArray;
                    minY = compareY;
                }
            }
        }

        for (int i = 0; i < slots.childCount; i++)
        {
            if (slots.GetChild(i).GetComponent<InvenSlot>().isActive == true)
            {
                if (compareX < slots.GetChild(i).GetComponent<InvenSlot>().xInArray)
                {
                    compareX = slots.GetChild(i).GetComponent<InvenSlot>().xInArray;
                    maxX = compareX;
                }
                if (compareY < slots.GetChild(i).GetComponent<InvenSlot>().yInArray)
                {
                    compareY = slots.GetChild(i).GetComponent<InvenSlot>().yInArray;
                    maxY = compareY;
                }
            }
        }
    }

    public void InvenImgExpand()
    {
        

        if (InventoryManager.Instance.expandLeft == 0)
        {
            if (minX == 3)
            {
                rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x + 165 * 0.7f, rectTransform.sizeDelta.y);

                childRectTransform.sizeDelta
                = new Vector2(childRectTransform.sizeDelta.x + 100 * 0.7f, childRectTransform.sizeDelta.y);

                rectTransform.anchoredPosition
                = new Vector3(rectTransform.anchoredPosition.x - 50 * 0.7f, rectTransform.anchoredPosition.y);
                InventoryManager.Instance.expandLeft++;
            }
        }

        if (InventoryManager.Instance.expandLeft == 1)
        {
            if (minX == 4)
            {
                rectTransform.sizeDelta
                = new Vector2(rectTransform.sizeDelta.x - 165 * 0.7f, rectTransform.sizeDelta.y);

                childRectTransform.sizeDelta
                = new Vector2(childRectTransform.sizeDelta.x - 100 * 0.7f, childRectTransform.sizeDelta.y);

                rectTransform.anchoredPosition
                = new Vector3(rectTransform.anchoredPosition.x + 50 * 0.7f, rectTransform.anchoredPosition.y);
                InventoryManager.Instance.expandLeft--;
            }
            
            if (minX == 2)
            {
                rectTransform.sizeDelta
                = new Vector2(rectTransform.sizeDelta.x + 165 * 0.7f, rectTransform.sizeDelta.y);

                childRectTransform.sizeDelta
                = new Vector2(childRectTransform.sizeDelta.x + 100 * 0.7f, childRectTransform.sizeDelta.y);

                rectTransform.anchoredPosition
                = new Vector3(rectTransform.anchoredPosition.x - 50 * 0.7f, rectTransform.anchoredPosition.y);
                InventoryManager.Instance.expandLeft++;
            }
        }
        if (InventoryManager.Instance.expandLeft == 2)
        {
            if (minX == 3)
            {
                rectTransform.sizeDelta
                = new Vector2(rectTransform.sizeDelta.x - 165 * 0.7f, rectTransform.sizeDelta.y);

                childRectTransform.sizeDelta
                = new Vector2(childRectTransform.sizeDelta.x - 100 * 0.7f, childRectTransform.sizeDelta.y);

                rectTransform.anchoredPosition
                = new Vector3(rectTransform.anchoredPosition.x + 50 * 0.7f, rectTransform.anchoredPosition.y);
                InventoryManager.Instance.expandLeft--;
            }
            
            if (minX == 1)
            {
                rectTransform.sizeDelta
                = new Vector2(rectTransform.sizeDelta.x + 165 * 0.7f, rectTransform.sizeDelta.y);

                childRectTransform.sizeDelta
                = new Vector2(childRectTransform.sizeDelta.x + 100 * 0.7f, childRectTransform.sizeDelta.y);

                rectTransform.anchoredPosition
                = new Vector3(rectTransform.anchoredPosition.x - 50 * 0.7f, rectTransform.anchoredPosition.y);

                InventoryManager.Instance.expandLeft++;
            }
        }

        if (InventoryManager.Instance.expandRight == 0)
        {
            if (maxX == 7)
            {
                rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x + 165 * 0.7f, rectTransform.sizeDelta.y);

                childRectTransform.sizeDelta
                = new Vector2(childRectTransform.sizeDelta.x + 100 * 0.7f, childRectTransform.sizeDelta.y);

                rectTransform.anchoredPosition
                = new Vector3(rectTransform.anchoredPosition.x + 50 * 0.7f, rectTransform.anchoredPosition.y);
                InventoryManager.Instance.expandRight++;
            }
        }

        if (InventoryManager.Instance.expandRight == 1)
        {
            if (maxX == 6)
            {
                rectTransform.sizeDelta
                = new Vector2(rectTransform.sizeDelta.x - 165 * 0.7f, rectTransform.sizeDelta.y);

                childRectTransform.sizeDelta
                = new Vector2(childRectTransform.sizeDelta.x - 100 * 0.7f, childRectTransform.sizeDelta.y);

                rectTransform.anchoredPosition
                = new Vector3(rectTransform.anchoredPosition.x - 50 * 0.7f, rectTransform.anchoredPosition.y);
                InventoryManager.Instance.expandRight--;
            }
            
            if (maxX == 8)
            {
                rectTransform.sizeDelta
                = new Vector2(rectTransform.sizeDelta.x + 165 * 0.7f, rectTransform.sizeDelta.y);

                childRectTransform.sizeDelta
                = new Vector2(childRectTransform.sizeDelta.x + 100 * 0.7f, childRectTransform.sizeDelta.y);

                rectTransform.anchoredPosition
                = new Vector3(rectTransform.anchoredPosition.x + 50 * 0.7f, rectTransform.anchoredPosition.y);
                InventoryManager.Instance.expandRight++;
            }
        }
        if (InventoryManager.Instance.expandRight == 2)
        {
            if (maxX == 7)
            {
                rectTransform.sizeDelta
                = new Vector2(rectTransform.sizeDelta.x - 165 * 0.7f, rectTransform.sizeDelta.y);

                childRectTransform.sizeDelta
                = new Vector2(childRectTransform.sizeDelta.x - 100 * 0.7f, childRectTransform.sizeDelta.y);

                rectTransform.anchoredPosition
                = new Vector3(rectTransform.anchoredPosition.x - 50 * 0.7f, rectTransform.anchoredPosition.y);
                InventoryManager.Instance.expandRight--;
            }
            
            if (maxX == 9)
            {
                rectTransform.sizeDelta
                = new Vector2(rectTransform.sizeDelta.x + 165 * 0.7f, rectTransform.sizeDelta.y);

                childRectTransform.sizeDelta
                = new Vector2(childRectTransform.sizeDelta.x + 100 * 0.7f, childRectTransform.sizeDelta.y);

                rectTransform.anchoredPosition
                = new Vector3(rectTransform.anchoredPosition.x + 50 * 0.7f, rectTransform.anchoredPosition.y);

                InventoryManager.Instance.expandRight++;
            }
        }

        //
        if (InventoryManager.Instance.expandUp == 0)
        {
            if (minY == 1)
            {
                rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, rectTransform.sizeDelta.y + 165 * 0.5f);

                childRectTransform.sizeDelta
                = new Vector2(childRectTransform.sizeDelta.x, childRectTransform.sizeDelta.y + 130 * 0.5f);

                rectTransform.anchoredPosition
                = new Vector3(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y + 50 * 0.5f);
                InventoryManager.Instance.expandUp++;
            }
        }

        if (InventoryManager.Instance.expandUp == 1)
        {
            if (minY == 2)
            {
                rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, rectTransform.sizeDelta.y - 165 * 0.5f);

                childRectTransform.sizeDelta
                = new Vector2(childRectTransform.sizeDelta.x, childRectTransform.sizeDelta.y - 130 * 0.5f);

                rectTransform.anchoredPosition
                = new Vector3(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y - 50 * 0.5f);
                InventoryManager.Instance.expandUp--;
            }
        }
        //

        if (InventoryManager.Instance.expandDown == 0)
        {
            if (maxY == 5)
            {
                rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, rectTransform.sizeDelta.y + 165 * 0.5f);

                childRectTransform.sizeDelta
                = new Vector2(childRectTransform.sizeDelta.x, childRectTransform.sizeDelta.y + 130 * 0.5f);

                rectTransform.anchoredPosition
                = new Vector3(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y - 50 * 0.5f);
                InventoryManager.Instance.expandDown++;
            }
        }

        if (InventoryManager.Instance.expandDown == 1)
        {
            if (maxY == 4)
            {
                rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, rectTransform.sizeDelta.y - 165 * 0.5f);

                childRectTransform.sizeDelta
                = new Vector2(childRectTransform.sizeDelta.x, childRectTransform.sizeDelta.y - 130 * 0.5f);

                rectTransform.anchoredPosition
                = new Vector3(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y + 50 * 0.5f);
                InventoryManager.Instance.expandDown--;
            }
        }

    }

    

}
