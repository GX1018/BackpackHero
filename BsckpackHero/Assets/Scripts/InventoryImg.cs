using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryImg : MonoBehaviour
{
    public int expandRight =0;
    public int expandLeft =0;
    public int expandUp =0;
    public int expandDown =0;

    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        #region expandLeft
        if(expandLeft == 0)
        {
            if(GameObject.Find("2").GetComponent<InvenSlot>().isActive == true ||
                GameObject.Find("11").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("20").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("29").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("38").GetComponent<InvenSlot>().isActive == true )
            {
                gameObject.GetComponent<RectTransform>().sizeDelta 
                = new Vector2(gameObject.GetComponent<RectTransform>().sizeDelta.x + 165, gameObject.GetComponent<RectTransform>().sizeDelta.y);
                
                GameObject.Find("bagBg").GetComponent<RectTransform>().sizeDelta
                = new Vector2(GameObject.Find("bagBg").GetComponent<RectTransform>().sizeDelta.x +100, GameObject.Find("bagBg").GetComponent<RectTransform>().sizeDelta.y);

                gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(gameObject.GetComponent<RectTransform>().anchoredPosition.x-50,gameObject.GetComponent<RectTransform>().anchoredPosition.y);
                expandLeft ++;
            }
        }
        if(expandLeft == 1)
        {
            if(GameObject.Find("1").GetComponent<InvenSlot>().isActive == true ||
                GameObject.Find("10").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("19").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("28").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("37").GetComponent<InvenSlot>().isActive == true )
            {
                gameObject.GetComponent<RectTransform>().sizeDelta 
                = new Vector2(gameObject.GetComponent<RectTransform>().sizeDelta.x + 165, gameObject.GetComponent<RectTransform>().sizeDelta.y);
                
                GameObject.Find("bagBg").GetComponent<RectTransform>().sizeDelta
                = new Vector2(GameObject.Find("bagBg").GetComponent<RectTransform>().sizeDelta.x +100, GameObject.Find("bagBg").GetComponent<RectTransform>().sizeDelta.y);

                gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(gameObject.GetComponent<RectTransform>().anchoredPosition.x-50,gameObject.GetComponent<RectTransform>().anchoredPosition.y);
                expandLeft ++;
            }
        }
        if(expandLeft == 2)
        {
            if(GameObject.Find("0").GetComponent<InvenSlot>().isActive == true ||
                GameObject.Find("9").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("18").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("27").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("36").GetComponent<InvenSlot>().isActive == true )
            {
                gameObject.GetComponent<RectTransform>().sizeDelta 
                = new Vector2(gameObject.GetComponent<RectTransform>().sizeDelta.x + 165, gameObject.GetComponent<RectTransform>().sizeDelta.y);
                
                GameObject.Find("bagBg").GetComponent<RectTransform>().sizeDelta
                = new Vector2(GameObject.Find("bagBg").GetComponent<RectTransform>().sizeDelta.x +100, GameObject.Find("bagBg").GetComponent<RectTransform>().sizeDelta.y);

                gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(gameObject.GetComponent<RectTransform>().anchoredPosition.x-50,gameObject.GetComponent<RectTransform>().anchoredPosition.y);
                expandLeft ++;
            }
        }
        #endregion

        #region expandRight
        if(expandRight == 0)
        {
            if(GameObject.Find("6").GetComponent<InvenSlot>().isActive == true ||
                GameObject.Find("15").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("24").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("33").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("42").GetComponent<InvenSlot>().isActive == true )
            {
                gameObject.GetComponent<RectTransform>().sizeDelta 
                = new Vector2(gameObject.GetComponent<RectTransform>().sizeDelta.x + 165, gameObject.GetComponent<RectTransform>().sizeDelta.y);
                
                GameObject.Find("bagBg").GetComponent<RectTransform>().sizeDelta
                = new Vector2(GameObject.Find("bagBg").GetComponent<RectTransform>().sizeDelta.x +100, GameObject.Find("bagBg").GetComponent<RectTransform>().sizeDelta.y);

                gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(gameObject.GetComponent<RectTransform>().anchoredPosition.x+50,gameObject.GetComponent<RectTransform>().anchoredPosition.y);
                expandRight ++;
            }
        }
        if(expandRight == 1)
        {
            if(GameObject.Find("7").GetComponent<InvenSlot>().isActive == true ||
                GameObject.Find("16").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("25").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("34").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("43").GetComponent<InvenSlot>().isActive == true )
            {
                gameObject.GetComponent<RectTransform>().sizeDelta 
                = new Vector2(gameObject.GetComponent<RectTransform>().sizeDelta.x + 165, gameObject.GetComponent<RectTransform>().sizeDelta.y);
                
                GameObject.Find("bagBg").GetComponent<RectTransform>().sizeDelta
                = new Vector2(GameObject.Find("bagBg").GetComponent<RectTransform>().sizeDelta.x +100, GameObject.Find("bagBg").GetComponent<RectTransform>().sizeDelta.y);

                gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(gameObject.GetComponent<RectTransform>().anchoredPosition.x+50,gameObject.GetComponent<RectTransform>().anchoredPosition.y);
                expandRight ++;
            }
        }
        if(expandRight == 2)
        {
            if(GameObject.Find("8").GetComponent<InvenSlot>().isActive == true ||
                GameObject.Find("17").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("26").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("35").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("44").GetComponent<InvenSlot>().isActive == true )
            {
                gameObject.GetComponent<RectTransform>().sizeDelta 
                = new Vector2(gameObject.GetComponent<RectTransform>().sizeDelta.x + 165, gameObject.GetComponent<RectTransform>().sizeDelta.y);
                
                GameObject.Find("bagBg").GetComponent<RectTransform>().sizeDelta
                = new Vector2(GameObject.Find("bagBg").GetComponent<RectTransform>().sizeDelta.x +100, GameObject.Find("bagBg").GetComponent<RectTransform>().sizeDelta.y);

                gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(gameObject.GetComponent<RectTransform>().anchoredPosition.x+50,gameObject.GetComponent<RectTransform>().anchoredPosition.y);
                expandRight ++;
            }
        }
        #endregion

        #region expandUp
        if(expandUp == 0)
        {
            if(GameObject.Find("0").GetComponent<InvenSlot>().isActive == true ||
                GameObject.Find("1").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("2").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("3").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("4").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("5").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("6").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("7").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("8").GetComponent<InvenSlot>().isActive == true )
            {
                gameObject.GetComponent<RectTransform>().sizeDelta 
                = new Vector2(gameObject.GetComponent<RectTransform>().sizeDelta.x, gameObject.GetComponent<RectTransform>().sizeDelta.y + 165);
                
                GameObject.Find("bagBg").GetComponent<RectTransform>().sizeDelta
                = new Vector2(GameObject.Find("bagBg").GetComponent<RectTransform>().sizeDelta.x, GameObject.Find("bagBg").GetComponent<RectTransform>().sizeDelta.y +120);

                gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(gameObject.GetComponent<RectTransform>().anchoredPosition.x,gameObject.GetComponent<RectTransform>().anchoredPosition.y+50);
                expandUp ++;
            }
        }
        #endregion

        #region expandDown
        if(expandDown == 0)
        {
            if(GameObject.Find("36").GetComponent<InvenSlot>().isActive == true ||
                GameObject.Find("37").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("38").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("39").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("40").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("41").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("42").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("43").GetComponent<InvenSlot>().isActive == true||
                GameObject.Find("44").GetComponent<InvenSlot>().isActive == true )
            {
                gameObject.GetComponent<RectTransform>().sizeDelta 
                = new Vector2(gameObject.GetComponent<RectTransform>().sizeDelta.x, gameObject.GetComponent<RectTransform>().sizeDelta.y + 165);
                
                GameObject.Find("bagBg").GetComponent<RectTransform>().sizeDelta
                = new Vector2(GameObject.Find("bagBg").GetComponent<RectTransform>().sizeDelta.x, GameObject.Find("bagBg").GetComponent<RectTransform>().sizeDelta.y +130);
                
                gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(gameObject.GetComponent<RectTransform>().anchoredPosition.x,gameObject.GetComponent<RectTransform>().anchoredPosition.y-50);
                expandDown ++;
            }
        }
        #endregion


    }
}
