using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour, IPointerDownHandler, 
    IPointerUpHandler, IDragHandler
{
    public bool isClicked = false;
    private RectTransform objRect = default;
    // Start is called before the first frame update
    void Start()
    {
        isClicked = false;
        objRect = gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            objRect.rotation = Quaternion.Euler(0, 0, objRect.rotation.eulerAngles.z+90);
        }

    }


    //test
    public void OnPointerDown(PointerEventData eventData)
    {
        isClicked = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isClicked = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(isClicked == true)
        {
            gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 
				Input.mousePosition.y, 1));
        }
    }
    //test

    
}
