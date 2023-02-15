using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemTest : MonoBehaviour, IPointerDownHandler, 
    IPointerUpHandler, IDragHandler
{
    public bool isClicked = false;

    public int sizeX = 2;//변경 1->2 테스트후 다시 1로 변경요망
    public int sizeY = 3;
    public int _Rotation = 0;

    public int size2D;

    public int isReadyCount = 0;


    private RectTransform objRect = default;
    // Start is called before the first frame update
    void Start()
    {
        isClicked = false;
        objRect = gameObject.GetComponent<RectTransform>();
        size2D = 6;
        //size2D = GameObject.Find("TestCreateItem").GetComponent<TestCreateItem>().size2D;
        isReadyCount = 0;
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
