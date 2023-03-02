using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemTitle : MonoBehaviour, IPointerDownHandler,
    IPointerUpHandler, IDragHandler
{
    bool isClicked = false;

    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        

    }


    //아이템을 클릭했을때
    public void OnPointerDown(PointerEventData eventData)
    {
        //마우스 왼쪽 버튼 클릭
        if (Input.GetMouseButtonDown(0))
        {
            isClicked = true;

        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (Input.GetMouseButtonUp(0))
        {
            isClicked = false;
        }



    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isClicked == true)
        {
            gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                Input.mousePosition.y, 100));
        }
    }
}