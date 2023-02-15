using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvenSlot : MonoBehaviour
{
    public bool isActive = false;
    public bool isTemporary = false;



    //{ 아이템을 인벤토리에 넣기위한 변수들
    public bool isFilled = false;
    public bool readyToFill = false;

    private ItemTest item_Drag;
    private GameObject selectedItem;

    // { 슬롯 변수화
    public InvenSlot slot0;    // 좌측 한칸 위
    public InvenSlot slot1;    // 한칸 위의 슬롯
    public InvenSlot slot2;    // 우측 한칸 위
    public InvenSlot slot3;    // 좌측 슬롯
    public InvenSlot slot4;    // 우측 슬롯
    public InvenSlot slot5;    // 좌측 한칸 아래
    public InvenSlot slot6;    // 한칸 아래의 슬롯
    public InvenSlot slot7;    // 우측 한칸 아래
    // }




    //} 아이템을 인벤토리에 넣기위한 변수들

    //test
    private float Dist;
    GameObject target;
    //test


    // Start is called before the first frame update
    void Start()
    {

        if (this.name == "26" || this.name == "27" || this.name == "28" || this.name == "37" || this.name == "38" || this.name == "39"
        || this.name == "48" || this.name == "49" || this.name == "50")
        {
            isActive = true;
        }

        slot0 = GameObject.Find($"{(int.Parse(this.name) - 12)}").GetComponent<InvenSlot>();
        slot1 = GameObject.Find($"{(int.Parse(this.name) - 11)}").GetComponent<InvenSlot>();
        slot2 = GameObject.Find($"{(int.Parse(this.name) - 10)}").GetComponent<InvenSlot>();
        slot3 = GameObject.Find($"{(int.Parse(this.name) - 1)}").GetComponent<InvenSlot>();
        slot4 = GameObject.Find($"{(int.Parse(this.name) + 1)}").GetComponent<InvenSlot>();
        slot5 = GameObject.Find($"{(int.Parse(this.name) + 10)}").GetComponent<InvenSlot>();
        slot6 = GameObject.Find($"{(int.Parse(this.name) + 11)}").GetComponent<InvenSlot>();
        slot7 = GameObject.Find($"{(int.Parse(this.name) + 12)}").GetComponent<InvenSlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive == true)
        {
            gameObject.GetComponent<Image>().enabled = true;
        }

        else if (isTemporary == true && InventoryManager.Instance.lvUpPoint > 0)
        {
            gameObject.GetComponent<Image>().enabled = true;
            gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        }
        else if (InventoryManager.Instance.lvUpPoint <= 0)
        {
            gameObject.GetComponent<Image>().enabled = false;
            isTemporary = false;
        }

        else if (isActive == false && isTemporary == false)
        {
            gameObject.GetComponent<Image>().enabled = false;
            //gameObject.GetComponent<BoxCollider2D>().enabled =false;
        }


        //test 테스트  테스트  테스트  // 아이템 기본 칼



        //Debug.Log("부모");
        //Debug.Log(GameObject.Find("item").transform.position);
        //Debug.Log("자식");
        //Debug.Log(GameObject.Find("itemImg").transform.position);

        target = GameObject.FindWithTag("SelectedCore");
        #region legacy
        /* if (GameObject.FindWithTag("SelectedItem").GetComponent<ItemTest>().isClicked == true && isActive == false)//&& target.GetComponent<itemSize>().CheckStart == false)
        {
            //target = GameObject.FindWithTag("SelectedCore");
            Dist = Vector2.Distance(transform.position, target.transform.position);
            if (Dist < 0.5f)
            {
                InventoryManager.Instance.addItemAvailable = false;
                GameObject.Find("itemImg").transform.position = GameObject.FindWithTag("SelectedItem").transform.position;
                GameObject.Find("itemImg").GetComponent<Image>().color = new Color32(255, 255, 255, 100);
            }
        }

        if (GameObject.FindWithTag("SelectedItem").GetComponent<ItemTest>().isClicked == true && isActive == true)//&& target.GetComponent<itemSize>().CheckStart == false)
        {
            //target = GameObject.FindWithTag("SelectedCore");
            Dist = Vector2.Distance(transform.position, target.transform.position);
            if (Dist < 0.5f)
            {
                //target.transform.position = this.gameObject.transform.position;
                target.GetComponent<itemSize>().CheckStart = true;
                //Debug.Log(target.GetComponent<itemSize>().CheckStart);
                //GameObject.Find("item").GetComponent<Item>().isClicked = false;
            }
            else if (Dist > 0.5f)
            {
                target.GetComponent<itemSize>().CheckStart = false;
                //Debug.Log(target.GetComponent<itemSize>().CheckStart);
            }
        }

        if (GameObject.FindWithTag("SelectedItem").GetComponent<ItemTest>()._Rotation % 2 == 0)
        {
            if (GameObject.FindWithTag("SelectedItem").GetComponent<ItemTest>().isClicked == true && target.GetComponent<itemSize>().CheckStart == true)
            {
                //test-> sizeX=1, sizeY=3
                if (GameObject.Find($"{(int.Parse(this.name) - 9)}").GetComponent<InvenSlot>().isFilled == false)
                //&& GameObject.Find($"{(int.Parse(this.name)-9)}").GetComponent<InvenSlot>().isActive == true)
                {
                    GameObject.Find("Block1").GetComponent<itemSize>().isReady = true;
                }

                if (GameObject.Find($"{this.name}").GetComponent<InvenSlot>().isFilled == false)
                //&& GameObject.Find($"{this.name}").GetComponent<InvenSlot>().isActive ==true)
                {
                    GameObject.Find("Core").GetComponent<itemSize>().isReady = true;
                }
                if (GameObject.Find($"{(int.Parse(this.name) + 9)}").GetComponent<InvenSlot>().isFilled == false)
                //&& GameObject.Find($"{(int.Parse(this.name)+9)}").GetComponent<InvenSlot>().isActive == true)
                {
                    GameObject.Find("Block2").GetComponent<itemSize>().isReady = true;
                }
            }

            if (GameObject.Find("Block1").GetComponent<itemSize>().isReady == true &&
            GameObject.Find("Block2").GetComponent<itemSize>().isReady == true &&
            GameObject.Find("Core").GetComponent<itemSize>().isReady == true)
            {
                if (GameObject.Find($"{(int.Parse(this.name) - 9)}").GetComponent<InvenSlot>().isActive == true &&
                GameObject.Find($"{this.name}").GetComponent<InvenSlot>().isActive == true &&
                GameObject.Find($"{(int.Parse(this.name) + 9)}").GetComponent<InvenSlot>().isActive == true)
                {
                    InventoryManager.Instance.addItemAvailable = true;
                    GameObject.Find("itemImg").transform.position = this.gameObject.transform.position;
                    GameObject.Find("itemImg").GetComponent<Image>().color = new Color32(255, 255, 255, 100);
                    target.GetComponent<itemSize>().CheckStart = false;
                }
                //GameObject.Find("item").transform.position = this.gameObject.transform.position;
                else if (GameObject.Find($"{(int.Parse(this.name) - 9)}").GetComponent<InvenSlot>().isActive == false ||
                GameObject.Find($"{this.name}").GetComponent<InvenSlot>().isActive == false ||
                GameObject.Find($"{(int.Parse(this.name) + 9)}").GetComponent<InvenSlot>().isActive == false)
                {
                    InventoryManager.Instance.addItemAvailable = false;
                    GameObject.Find("itemImg").transform.position = this.gameObject.transform.position;
                    GameObject.Find("itemImg").GetComponent<Image>().color = new Color32(255, 0, 0, 100);
                    target.GetComponent<itemSize>().CheckStart = false;
                }

            }
        }

        if (GameObject.FindWithTag("SelectedItem").GetComponent<ItemTest>()._Rotation % 2 == 1)
        {
            if (GameObject.FindWithTag("SelectedItem").GetComponent<ItemTest>().isClicked == true && target.GetComponent<itemSize>().CheckStart == true)
            {
                //test-> sizeX=3, sizeY=1
                if (GameObject.Find($"{(int.Parse(this.name) - 1)}").GetComponent<InvenSlot>().isFilled == false)
                //&& GameObject.Find($"{(int.Parse(this.name)-9)}").GetComponent<InvenSlot>().isActive == true)
                {
                    GameObject.Find("Block1").GetComponent<itemSize>().isReady = true;
                }

                if (GameObject.Find($"{this.name}").GetComponent<InvenSlot>().isFilled == false)
                //&& GameObject.Find($"{this.name}").GetComponent<InvenSlot>().isActive ==true)
                {
                    GameObject.Find("Core").GetComponent<itemSize>().isReady = true;
                }
                if (GameObject.Find($"{(int.Parse(this.name) + 1)}").GetComponent<InvenSlot>().isFilled == false)
                //&& GameObject.Find($"{(int.Parse(this.name)+9)}").GetComponent<InvenSlot>().isActive == true)
                {
                    GameObject.Find("Block2").GetComponent<itemSize>().isReady = true;
                }
            }

            if (GameObject.Find("Block1").GetComponent<itemSize>().isReady == true &&
            GameObject.Find("Block2").GetComponent<itemSize>().isReady == true &&
            GameObject.Find("Core").GetComponent<itemSize>().isReady == true)
            {
                if (GameObject.Find($"{(int.Parse(this.name) - 1)}").GetComponent<InvenSlot>().isActive == true &&
                GameObject.Find($"{this.name}").GetComponent<InvenSlot>().isActive == true &&
                GameObject.Find($"{(int.Parse(this.name) + 1)}").GetComponent<InvenSlot>().isActive == true)
                {
                    InventoryManager.Instance.addItemAvailable = true;
                    GameObject.Find("itemImg").transform.position = this.gameObject.transform.position;
                    GameObject.Find("itemImg").GetComponent<Image>().color = new Color32(255, 255, 255, 100);
                    target.GetComponent<itemSize>().CheckStart = false;
                }
                //GameObject.Find("item").transform.position = this.gameObject.transform.position;
                else if (GameObject.Find($"{(int.Parse(this.name) - 1)}").GetComponent<InvenSlot>().isActive == false ||
                GameObject.Find($"{this.name}").GetComponent<InvenSlot>().isActive == false ||
                GameObject.Find($"{(int.Parse(this.name) + 1)}").GetComponent<InvenSlot>().isActive == false)
                {
                    InventoryManager.Instance.addItemAvailable = false;
                    GameObject.Find("itemImg").transform.position = this.gameObject.transform.position;
                    GameObject.Find("itemImg").GetComponent<Image>().color = new Color32(255, 0, 0, 100);
                    target.GetComponent<itemSize>().CheckStart = false;
                }

            }
        }


        if (GameObject.FindWithTag("SelectedItem").GetComponent<ItemTest>().isClicked == true && target.GetComponent<itemSize>().CheckStart == false)
        {
            GameObject.Find("Block1").GetComponent<itemSize>().isReady = false;
            GameObject.Find("Block2").GetComponent<itemSize>().isReady = false;
            GameObject.Find("Core").GetComponent<itemSize>().isReady = false;//?

        } */
        #endregion legacy

        //Debug.Log(Vector2.Distance(GameObject.Find("itemImg").transform.position, GameObject.Find("item").transform.position));
        /* if(Vector2.Distance(GameObject.Find("itemImg").transform.position, GameObject.Find("item").transform.position)>0.4)
        {
            GameObject.Find("itemImg").transform.position = GameObject.Find("item").transform.position;
            GameObject.Find("itemImg").GetComponent<Image>().color = new Color32(255, 255, 255, 100);

        } */



        //Debug.Log("1");

        ItemInsert();


        //test

    }

    private void OnMouseDown()
    {
        Debug.Log(this.name);
        if (isTemporary == true)
        {
            isActive = true;
            gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            InventoryManager.Instance.lvUpPoint--;
            isTemporary = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        readyToFill = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        readyToFill = false;
    }

    public void ItemInsert()
    {
        //Debug.Log(GameObject.FindWithTag("SelectedItem").GetComponent<ItemTest>());

        //GameObject.FindWithTag("SelectedItem").GetComponent<ItemTest>()를 item_Drag 로 변경
        item_Drag = GameObject.FindWithTag("SelectedItem").GetComponent<ItemTest>();
        selectedItem = GameObject.FindWithTag("SelectedItem");

        //{ 활성화된 인벤토리 이외의 위치에 있을때 itemcheckImg 위치 초기화
        if (item_Drag.isClicked == true && isActive == false)
        {
            Dist = Vector2.Distance(transform.position, target.transform.position);
            
            if (Dist < 0.5f)
            {
                InventoryManager.Instance.addItemAvailable = false;
                GameObject.FindWithTag("ItemImgSub").transform.position = GameObject.FindWithTag("ItemImgMain").transform.position;
                GameObject.FindWithTag("ItemImgSub").GetComponent<Image>().color = new Color32(255, 255, 255, 100);
            }
        }
        //} 활성화된 인벤토리 이외의 위치에 있을때 itemcheckImg 위치 초기화

        //{ 아이템 드래그 중이고, 활성화된 인벤토리 안의 위치에 있들때
        if (item_Drag.isClicked == true && isActive == true)
        {
            Dist = Vector2.Distance(transform.position, target.transform.position);
            

            //아이템 슬롯과 일정거리 이내에 접근하면 CheckStart변수를 true로 변경
            if (Dist < 0.5f)
            {
                target.GetComponent<itemSize>().CheckStart = true;
                
            }
            else if (Dist > 0.5f)
            {
                target.GetComponent<itemSize>().CheckStart = false;
            }
        }
        //} 아이템 드래그 중이고, 활성화된 인벤토리 안의 위치에 있들때


        //{ 드래그 중인 아이템의 회전 상태가 짝수일때
        if (item_Drag._Rotation % 2 == 0)
        {
            if (item_Drag.isClicked == true && target.GetComponent<itemSize>().CheckStart == true)
            {
                //Debug.Log("1");
                //아이템사이즈 1(1x1),2(1x2),3(1x3),4(2x2),6(2x3)
                int isReadyCount = 0;
                int isActiveCount = 0;
                switch (item_Drag.size2D)
                {
                    case 1:
                        if (isFilled == false && isActive == true)
                        {
                            selectedItem.transform.GetChild(0).GetComponent<itemSize>().isReady = true;
                        }
                        break;
                    case 2:
                        if (isFilled == false && isActive == true)
                        {
                            selectedItem.transform.GetChild(0).GetComponent<itemSize>().isReady = true;
                        }
                        if (slot6.isFilled == false && slot6.isActive == true)
                        {
                            selectedItem.transform.GetChild(1).GetComponent<itemSize>().isReady = true;
                        }
                        break;

                    case 3:
                        if (slot2.isFilled == false && slot2.isActive ==true)
                        {
                            selectedItem.transform.GetChild(0).GetComponent<itemSize>().isReady = true;
                        }
                        if (isFilled == false && isActive == true)
                        {
                            selectedItem.transform.GetChild(1).GetComponent<itemSize>().isReady = true;
                        }
                        if (slot6.isFilled == false && slot6.isActive == true)
                        {
                            selectedItem.transform.GetChild(2).GetComponent<itemSize>().isReady = true;
                        }
                        break;
                    case 4:
                        if (isFilled == false && isActive == true)
                        {
                            selectedItem.transform.GetChild(0).GetComponent<itemSize>().isReady = true;
                        }
                        if (slot4.isFilled == false && slot4.isActive == true)
                        {
                            selectedItem.transform.GetChild(1).GetComponent<itemSize>().isReady = true;
                        }
                        if (slot6.isFilled == false && slot6.isActive == true)
                        {
                            selectedItem.transform.GetChild(2).GetComponent<itemSize>().isReady = true;
                        }
                        if (slot7.isFilled == false && slot7.isActive == true)
                        {
                            selectedItem.transform.GetChild(2).GetComponent<itemSize>().isReady = true;
                        }

                        break;
                    case 6:
                        Debug.Log(slot1);
                        if (slot1.isFilled == false && slot1.isActive == true)
                        {
                            selectedItem.transform.GetChild(0).GetComponent<itemSize>().isReady = true;
                        }
                        if (slot2.isFilled == false && slot2.isActive == true)
                        {
                            selectedItem.transform.GetChild(1).GetComponent<itemSize>().isReady = true;
                        }
                        if (isFilled == false && isActive == true)
                        {
                            selectedItem.transform.GetChild(2).GetComponent<itemSize>().isReady = true;
                        }
                        if (slot4.isFilled == false && slot4.isActive == true)
                        {
                            selectedItem.transform.GetChild(3).GetComponent<itemSize>().isReady = true;
                        }
                        if (slot6.isFilled == false && slot6.isActive == true)
                        {
                            selectedItem.transform.GetChild(4).GetComponent<itemSize>().isReady = true;
                        }
                        if (slot7.isFilled == false && slot7.isActive == true)
                        {
                            selectedItem.transform.GetChild(5).GetComponent<itemSize>().isReady = true;
                        }
                        //포문으로 안됨?

                        //아이템 슬롯의 isReady 상태 체크
                        for (int i = 0; i < selectedItem.transform.childCount - 2; i++)
                        {
                            if (selectedItem.transform.GetChild(i).GetComponent<itemSize>().isReady == true)
                            {
                                isReadyCount++;
                            }
                        }
                        Debug.Log(isReadyCount);

                        //모든 아이템 슬롯의 isReady가 true일때
                        if (isReadyCount == selectedItem.transform.childCount - 2)
                        {
                            if (slot1.isActive == true && slot2.isActive == true && isActive == true && slot4.isActive == true
                            && slot6.isActive == true && slot7.isActive == true)
                            {
                                InventoryManager.Instance.addItemAvailable = true;
                                selectedItem.transform.GetChild(7).transform.position = transform.position; //this.gameObject.transform.position; legacy(transform.position)
                                selectedItem.transform.GetChild(7).GetComponent<Image>().color = new Color32(255, 255, 255, 100);
                                target.GetComponent<itemSize>().CheckStart = false;
                            }
                            else if (slot1.isActive == false || slot2.isActive == false || isActive == false || slot4.isActive == false ||
                            slot6.isActive == false || slot7.isActive == false)
                            {
                                InventoryManager.Instance.addItemAvailable = false;
                                selectedItem.transform.GetChild(7).transform.position = transform.position;
                                selectedItem.transform.GetChild(7).GetComponent<Image>().color = new Color32(255, 0, 0, 100);
                                target.GetComponent<itemSize>().CheckStart = false;
                            }

                        }
                        break;
                }
                //} 드래그 중인 아이템의 회전 상태가 짝수일때

            }
        }
    }
}
