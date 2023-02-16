using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemTest : MonoBehaviour, IPointerDownHandler,
    IPointerUpHandler, IDragHandler
{
    public bool isClicked = false;
    public bool isCreated = false;

    public bool imageAdjust = false;

    public int sizeX = 0;
    public int sizeY = 0;

    public int size2D;

    public int isReadyCount = 0;


    public int invenSlotisActiveCnt = 0;
    public int invenSlotisEmptyCnt = 0;

    Vector3 itemOriginPos;





    private RectTransform objRect = default;
    // Start is called before the first frame update
    void Start()
    {
        isClicked = false;

        objRect = gameObject.GetComponent<RectTransform>();
        size2D = 6;
        //size2D = GameObject.Find("TestCreateItem").GetComponent<TestCreateItem>().size2D;
        isReadyCount = 0;
        invenSlotisActiveCnt = 0;
        invenSlotisEmptyCnt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (isClicked == true)
            {
                objRect.rotation = Quaternion.Euler(0, 0, objRect.rotation.eulerAngles.z + 90);
            }
            //objRect.rotation = Quaternion.Euler(0, 0, objRect.rotation.eulerAngles.z + 90);
        }

        invenSlotisActiveCnt = 0;

        for (int i = 0; i < transform.childCount - 2; i++)
        {
            if (transform.GetChild(i).GetComponent<itemBlock>().invenSlotisActive == true)
            {
                invenSlotisActiveCnt++;
            }
        }

        invenSlotisEmptyCnt = 0;

        for (int i = 0; i < transform.childCount - 2; i++)
        {
            if (transform.GetChild(i).GetComponent<itemBlock>().invenSlotisEmpty == true)
            {
                invenSlotisEmptyCnt++;
            }
        }

        if (isClicked == true)
        {

            //인벤토리 슬롯 활성화 수에 따른 상태 변경
            if (invenSlotisActiveCnt == 0)
            {
                transform.GetChild(transform.childCount - 2).transform.position
                = transform.GetChild(transform.childCount - 1).transform.position;
                transform.GetChild(transform.childCount - 2).GetComponent<Image>().color = new Color32(255, 255, 255, 100);
            }

            if (invenSlotisActiveCnt > 0 && invenSlotisActiveCnt < transform.childCount - 2)
            {
                transform.GetChild(transform.childCount - 2).transform.position
                = (transform.GetChild(0).GetComponent<itemBlock>().nearestSlot.transform.position
                + transform.GetChild(transform.childCount - 3).GetComponent<itemBlock>().nearestSlot.transform.position) / 2;
                transform.GetChild(transform.childCount - 2).GetComponent<Image>().color = new Color32(255, 0, 0, 100);
            }

            if (invenSlotisActiveCnt == transform.childCount - 2)
            {
                //비어있는 인벤토리 슬롯 수에 따른 상태 변경
                if (invenSlotisEmptyCnt == transform.childCount - 2)
                //비어있는 인벤토리 슬롯 수에 따른 상태 변경
                {
                    transform.GetChild(transform.childCount - 2).transform.position
                    = (transform.GetChild(0).GetComponent<itemBlock>().nearestSlot.transform.position
                    + transform.GetChild(transform.childCount - 3).GetComponent<itemBlock>().nearestSlot.transform.position) / 2;
                    transform.GetChild(transform.childCount - 2).GetComponent<Image>().color = new Color32(255, 255, 255, 100);
                }
                else
                {
                    transform.GetChild(transform.childCount - 2).transform.position
                    = (transform.GetChild(0).GetComponent<itemBlock>().nearestSlot.transform.position
                    + transform.GetChild(transform.childCount - 3).GetComponent<itemBlock>().nearestSlot.transform.position) / 2;
                    transform.GetChild(transform.childCount - 2).GetComponent<Image>().color = new Color32(255, 0, 0, 100);
                }
            }
        }
        //인벤토리 슬롯 활성화 수에 따른 상태 변경
    }


    //test
    public void OnPointerDown(PointerEventData eventData)
    {
        if (this.tag == "GainedItem")
        {
            for (int i = 0; i < transform.childCount - 2; i++)
            {
                transform.GetChild(i).GetComponent<itemBlock>().nearestSlot.GetComponent<InvenSlot>().isEmpty = true;
            }
        }

        transform.Find("Core").gameObject.tag = "SelectedCore";
        this.tag = "SelectedItem";

        //아이템 클릭했을때의 위치 저장
        itemOriginPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                                Input.mousePosition.y, 1));
        //아이템 클릭했을때의 위치 저장

        isClicked = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.Find("Core").gameObject.tag = "Core";
        this.tag = "Item";


        if (invenSlotisActiveCnt == transform.childCount - 2 && invenSlotisEmptyCnt == transform.childCount - 2)
        {
            //아이템을 인벤토리에 넣기
            for (int i = 0; i < transform.childCount - 2; i++)
            {
                transform.GetChild(i).GetComponent<itemBlock>().nearestSlot.GetComponent<InvenSlot>().isEmpty = false;
            }


            transform.GetChild(transform.childCount - 2).transform.position
            = transform.GetChild(transform.childCount - 1).transform.position;
            transform.GetChild(transform.childCount - 2).GetComponent<Image>().color = new Color32(255, 255, 255, 100);

            transform.position = (transform.GetChild(0).GetComponent<itemBlock>().nearestSlot.transform.position
                + transform.GetChild(transform.childCount - 3).GetComponent<itemBlock>().nearestSlot.transform.position) / 2;
            this.tag = "GainedItem";
            //아이템을 인벤토리에 넣기
        }
        else if ((invenSlotisActiveCnt != transform.childCount - 2) || (invenSlotisEmptyCnt != transform.childCount - 2))
        {
            transform.GetChild(transform.childCount - 2).transform.position
            = transform.GetChild(transform.childCount - 1).transform.position;
            /* if()
            {
                transform.position = itemOriginPos;
            } */
        }

        InventoryManager.Instance.addItemAvailable = false;

        isClicked = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isClicked == true)
        {
            gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                Input.mousePosition.y, 1));
        }
    }
    //test


}
