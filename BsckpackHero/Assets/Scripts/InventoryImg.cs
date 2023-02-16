using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryImg : MonoBehaviour
{
    Transform slots;

    Vector2 imgSize;
    Vector2 imgPosition;
    Vector2 childImgSize;

    RectTransform rectTransform;
    RectTransform childRectTransform;


    void Start()
    {
        slots = GameObject.Find("InventorySlots").transform;
        imgSize = gameObject.GetComponent<RectTransform>().sizeDelta;
        imgPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;
        childImgSize = transform.GetChild(0).gameObject.GetComponent<RectTransform>().sizeDelta;

        rectTransform = gameObject.GetComponent<RectTransform>();
        childRectTransform = transform.GetChild(0).gameObject.GetComponent<RectTransform>();

    }
    void Update()
    {

        /* #region expandLeft
        if(InventoryManager.Instance.expandLeft == 0)
        {
            if(GameObject.Find("14").GetComponent<InvenSlot>().isActive == true ||
                GameObject.Find("25").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("36").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("47").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("58").GetComponent<InvenSlot>().isActive == true )
            {
                gameObject.GetComponent<RectTransform>().sizeDelta 
                = new Vector2(gameObject.GetComponent<RectTransform>().sizeDelta.x + 165*0.7f, gameObject.GetComponent<RectTransform>().sizeDelta.y);
                
                GameObject.Find("bagBg").GetComponent<RectTransform>().sizeDelta
                = new Vector2(GameObject.Find("bagBg").GetComponent<RectTransform>().sizeDelta.x +100*0.7f, GameObject.Find("bagBg").GetComponent<RectTransform>().sizeDelta.y);

                gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(gameObject.GetComponent<RectTransform>().anchoredPosition.x-50*0.7f,gameObject.GetComponent<RectTransform>().anchoredPosition.y);
                InventoryManager.Instance.expandLeft ++;
            }
        }
        if(InventoryManager.Instance.expandLeft == 1)
        {
            if(GameObject.Find("13").GetComponent<InvenSlot>().isActive == true ||
                GameObject.Find("24").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("35").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("46").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("57").GetComponent<InvenSlot>().isActive == true )
            {
                gameObject.GetComponent<RectTransform>().sizeDelta 
                = new Vector2(gameObject.GetComponent<RectTransform>().sizeDelta.x + 165*0.7f, gameObject.GetComponent<RectTransform>().sizeDelta.y);
                
                GameObject.Find("bagBg").GetComponent<RectTransform>().sizeDelta
                = new Vector2(GameObject.Find("bagBg").GetComponent<RectTransform>().sizeDelta.x +100*0.7f, GameObject.Find("bagBg").GetComponent<RectTransform>().sizeDelta.y);

                gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(gameObject.GetComponent<RectTransform>().anchoredPosition.x-50*0.7f,gameObject.GetComponent<RectTransform>().anchoredPosition.y);
                InventoryManager.Instance.expandLeft ++;
            }
        }
        if(InventoryManager.Instance.expandLeft == 2)
        {
            if(GameObject.Find("12").GetComponent<InvenSlot>().isActive == true ||
                GameObject.Find("23").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("34").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("45").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("56").GetComponent<InvenSlot>().isActive == true )
            {
                gameObject.GetComponent<RectTransform>().sizeDelta 
                = new Vector2(gameObject.GetComponent<RectTransform>().sizeDelta.x + 165*0.7f, gameObject.GetComponent<RectTransform>().sizeDelta.y);
                
                GameObject.Find("bagBg").GetComponent<RectTransform>().sizeDelta
                = new Vector2(GameObject.Find("bagBg").GetComponent<RectTransform>().sizeDelta.x +100*0.7f, GameObject.Find("bagBg").GetComponent<RectTransform>().sizeDelta.y);

                gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(gameObject.GetComponent<RectTransform>().anchoredPosition.x-50*0.7f,gameObject.GetComponent<RectTransform>().anchoredPosition.y);
                InventoryManager.Instance.expandLeft ++;
            }
        }
        #endregion

        #region expandRight
        if(InventoryManager.Instance.expandRight == 0)
        {
            if(GameObject.Find("18").GetComponent<InvenSlot>().isActive == true ||
                GameObject.Find("29").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("40").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("51").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("62").GetComponent<InvenSlot>().isActive == true )
            {
                gameObject.GetComponent<RectTransform>().sizeDelta 
                = new Vector2(gameObject.GetComponent<RectTransform>().sizeDelta.x + 165*0.7f, gameObject.GetComponent<RectTransform>().sizeDelta.y);
                
                GameObject.Find("bagBg").GetComponent<RectTransform>().sizeDelta
                = new Vector2(GameObject.Find("bagBg").GetComponent<RectTransform>().sizeDelta.x +100*0.7f, GameObject.Find("bagBg").GetComponent<RectTransform>().sizeDelta.y);

                gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(gameObject.GetComponent<RectTransform>().anchoredPosition.x+50*0.7f,gameObject.GetComponent<RectTransform>().anchoredPosition.y);
                InventoryManager.Instance.expandRight ++;
            }
        }
        if(InventoryManager.Instance.expandRight == 1)
        {
            if(GameObject.Find("19").GetComponent<InvenSlot>().isActive == true ||
                GameObject.Find("30").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("41").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("52").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("63").GetComponent<InvenSlot>().isActive == true )
            {
                gameObject.GetComponent<RectTransform>().sizeDelta 
                = new Vector2(gameObject.GetComponent<RectTransform>().sizeDelta.x + 165*0.7f, gameObject.GetComponent<RectTransform>().sizeDelta.y);
                
                GameObject.Find("bagBg").GetComponent<RectTransform>().sizeDelta
                = new Vector2(GameObject.Find("bagBg").GetComponent<RectTransform>().sizeDelta.x +100*0.7f, GameObject.Find("bagBg").GetComponent<RectTransform>().sizeDelta.y);

                gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(gameObject.GetComponent<RectTransform>().anchoredPosition.x+50*0.7f,gameObject.GetComponent<RectTransform>().anchoredPosition.y);
                InventoryManager.Instance.expandRight ++;
            }
        }
        if(InventoryManager.Instance.expandRight == 2)
        {
            if(GameObject.Find("20").GetComponent<InvenSlot>().isActive == true ||
                GameObject.Find("31").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("42").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("53").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("64").GetComponent<InvenSlot>().isActive == true )
            {
                gameObject.GetComponent<RectTransform>().sizeDelta 
                = new Vector2(gameObject.GetComponent<RectTransform>().sizeDelta.x + 165*0.7f, gameObject.GetComponent<RectTransform>().sizeDelta.y);
                
                GameObject.Find("bagBg").GetComponent<RectTransform>().sizeDelta
                = new Vector2(GameObject.Find("bagBg").GetComponent<RectTransform>().sizeDelta.x +100*0.7f, GameObject.Find("bagBg").GetComponent<RectTransform>().sizeDelta.y);

                gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(gameObject.GetComponent<RectTransform>().anchoredPosition.x+50*0.7f,gameObject.GetComponent<RectTransform>().anchoredPosition.y);
                InventoryManager.Instance.expandRight ++;
            }
        }
        #endregion

        #region expandUp
        if(InventoryManager.Instance.expandUp == 0)
        {
            if(GameObject.Find("12").GetComponent<InvenSlot>().isActive == true ||
                GameObject.Find("13").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("14").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("15").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("16").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("17").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("18").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("19").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("20").GetComponent<InvenSlot>().isActive == true )
            {
                gameObject.GetComponent<RectTransform>().sizeDelta 
                = new Vector2(gameObject.GetComponent<RectTransform>().sizeDelta.x, gameObject.GetComponent<RectTransform>().sizeDelta.y + 165*0.5f);
                
                GameObject.Find("bagBg").GetComponent<RectTransform>().sizeDelta
                = new Vector2(GameObject.Find("bagBg").GetComponent<RectTransform>().sizeDelta.x, GameObject.Find("bagBg").GetComponent<RectTransform>().sizeDelta.y +120*0.5f);

                gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(gameObject.GetComponent<RectTransform>().anchoredPosition.x,gameObject.GetComponent<RectTransform>().anchoredPosition.y+50*0.5f);
                InventoryManager.Instance.expandUp ++;
            }
        }
        #endregion

        #region expandDown
        if(InventoryManager.Instance.expandDown == 0)
        {
            if(GameObject.Find("56").GetComponent<InvenSlot>().isActive == true ||
                GameObject.Find("57").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("58").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("59").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("60").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("61").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("62").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("63").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("64").GetComponent<InvenSlot>().isActive == true )
            {
                gameObject.GetComponent<RectTransform>().sizeDelta 
                = new Vector2(gameObject.GetComponent<RectTransform>().sizeDelta.x, gameObject.GetComponent<RectTransform>().sizeDelta.y + 165*0.5f);
                
                GameObject.Find("bagBg").GetComponent<RectTransform>().sizeDelta
                = new Vector2(GameObject.Find("bagBg").GetComponent<RectTransform>().sizeDelta.x, GameObject.Find("bagBg").GetComponent<RectTransform>().sizeDelta.y +130*0.5f);
                
                gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(gameObject.GetComponent<RectTransform>().anchoredPosition.x,gameObject.GetComponent<RectTransform>().anchoredPosition.y-50*0.5f);
                InventoryManager.Instance.expandDown ++;
            }
        }
        #endregion */

        InvenImgExpand();
    }

    public void InvenImgExpand()
    {

        int compareX = 5;
        int minX = 0;
        int maxX = 0;
        int compareY = 3;
        int minY = 0;
        int maxY = 0;


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
        //find min, max

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
            if (minX == 2)
            {
                rectTransform.sizeDelta
                = new Vector2(rectTransform.sizeDelta.x + 165 * 0.7f, rectTransform.sizeDelta.y);

                childRectTransform.sizeDelta
                = new Vector2(childRectTransform.sizeDelta.x + 100 * 0.7f, childRectTransform.sizeDelta.y);

                rectTransform.anchoredPosition = new Vector3(imgPosition.x - 50 * 0.7f, imgPosition.y);
                InventoryManager.Instance.expandLeft++;
            }
        }
        if (InventoryManager.Instance.expandLeft == 2)
        {
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

    }
}
