using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemTest : MonoBehaviour, IPointerDownHandler, 
    IPointerUpHandler, IDragHandler
{
    public bool isClicked = false;

    public int sizeX = 1;
    public int sizeY = 3;
    public int _Rotation = 0;

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
            _Rotation++;
        }

    }


    //test
    public void OnPointerDown(PointerEventData eventData)
    {
        //test
        transform.Find("Core").gameObject.tag = "SelectedCore";
        this.tag = "SelectedItem";
        //
        isClicked = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.Find("Core").gameObject.tag = "Core";
        this.tag = "Item";
        
        Vector3 targetPos = new Vector3(GameObject.Find("itemImg").transform.position.x,GameObject.Find("itemImg").transform.position.y,1);
        GameObject.Find("item").transform.position = targetPos;
        GameObject.Find("itemImg").transform.position = GameObject.Find("item").transform.position;

        //GameObject.Find("item").transform.position = GameObject.Find("itemImg").transform.position;
        InventoryManager.Instance.addItemAvailable = false;

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
