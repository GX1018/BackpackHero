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

    //} 아이템을 인벤토리에 넣기위한 변수들

    //test
    private float Dist;
    GameObject target;
    //test


    // Start is called before the first frame update
    void Start()
    {
        if (this.name == "12"||this.name=="13"||this.name=="14"||this.name=="21"||this.name=="22"||this.name=="23"
        ||this.name=="30"||this.name=="31"||this.name=="32")
        {
            isActive = true;
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        if(isActive ==true)
        {
            gameObject.GetComponent<Image>().enabled =true;
        }
        
        else if(isTemporary ==true&&InventoryManager.Instance.lvUpPoint>0)
        {
            gameObject.GetComponent<Image>().enabled = true;
            gameObject.GetComponent<Image>().color = new Color(1,1,1,0.5f);
        }
        else if(InventoryManager.Instance.lvUpPoint<=0)
        {
            gameObject.GetComponent<Image>().enabled = false;
            isTemporary =false;
        }
        
        else if(isActive == false && isTemporary ==false)
        {
            gameObject.GetComponent<Image>().enabled = false;
            //gameObject.GetComponent<BoxCollider2D>().enabled =false;
        }


        //test 테스트  테스트  테스트  // 아이템 기본 칼
        


        Debug.Log("부모");
        Debug.Log(GameObject.Find("item").transform.position);
        Debug.Log("자식");
        Debug.Log(GameObject.Find("itemImg").transform.position);

        target = GameObject.FindWithTag("SelectedCore");


        if (GameObject.Find("item").GetComponent<ItemTest>().isClicked ==true&& isActive == false)//&& target.GetComponent<itemSize>().CheckStart == false)
        {
            //target = GameObject.FindWithTag("SelectedCore");
                Dist =Vector2.Distance(transform.position, target.transform.position);
                if(Dist < 0.5f)
                {
                    InventoryManager.Instance.addItemAvailable = false;
                    GameObject.Find("itemImg").transform.position = GameObject.Find("item").transform.position;
                    GameObject.Find("itemImg").GetComponent<Image>().color = new Color32(255, 255, 255, 100);
                }
        }

        if (GameObject.Find("item").GetComponent<ItemTest>().isClicked ==true&& isActive == true)//&& target.GetComponent<itemSize>().CheckStart == false)
        {
            //target = GameObject.FindWithTag("SelectedCore");
                Dist =Vector2.Distance(transform.position, target.transform.position);
                if(Dist < 0.5f)
                {
                    //target.transform.position = this.gameObject.transform.position;
                    target.GetComponent<itemSize>().CheckStart = true;
                    //Debug.Log(target.GetComponent<itemSize>().CheckStart);
                    //GameObject.Find("item").GetComponent<Item>().isClicked = false;
                }
                else if(Dist > 0.5f)
                {
                    target.GetComponent<itemSize>().CheckStart = false;
                    //Debug.Log(target.GetComponent<itemSize>().CheckStart);
                }
        }
        if(GameObject.Find("item").GetComponent<ItemTest>()._Rotation%2==0)
        {
            if(GameObject.Find("item").GetComponent<ItemTest>().isClicked ==true&&target.GetComponent<itemSize>().CheckStart == true)
            {
                //test-> sizeX=1, sizeY=3
                if(GameObject.Find($"{(int.Parse(this.name)-9)}").GetComponent<InvenSlot>().isFilled == false)
                    //&& GameObject.Find($"{(int.Parse(this.name)-9)}").GetComponent<InvenSlot>().isActive == true)
                {
                    GameObject.Find("Block1").GetComponent<itemSize>().isReady = true;
                }

                if(GameObject.Find($"{this.name}").GetComponent<InvenSlot>().isFilled == false)
                    //&& GameObject.Find($"{this.name}").GetComponent<InvenSlot>().isActive ==true)
                {
                    GameObject.Find("Core").GetComponent<itemSize>().isReady = true;
                }
                if(GameObject.Find($"{(int.Parse(this.name)+9)}").GetComponent<InvenSlot>().isFilled == false)
                    //&& GameObject.Find($"{(int.Parse(this.name)+9)}").GetComponent<InvenSlot>().isActive == true)
                {
                    GameObject.Find("Block2").GetComponent<itemSize>().isReady = true;
                }
            }

            if(GameObject.Find("Block1").GetComponent<itemSize>().isReady == true &&
            GameObject.Find("Block2").GetComponent<itemSize>().isReady == true &&
            GameObject.Find("Core").GetComponent<itemSize>().isReady == true)
            {
                if(GameObject.Find($"{(int.Parse(this.name)-9)}").GetComponent<InvenSlot>().isActive == true &&
                GameObject.Find($"{this.name}").GetComponent<InvenSlot>().isActive ==true &&
                GameObject.Find($"{(int.Parse(this.name)+9)}").GetComponent<InvenSlot>().isActive == true)
                {
                    InventoryManager.Instance.addItemAvailable = true;
                    GameObject.Find("itemImg").transform.position = this.gameObject.transform.position;
                    GameObject.Find("itemImg").GetComponent<Image>().color = new Color32(255, 255, 255, 100);
                    target.GetComponent<itemSize>().CheckStart = false;
                }
                //GameObject.Find("item").transform.position = this.gameObject.transform.position;
                else if(GameObject.Find($"{(int.Parse(this.name)-9)}").GetComponent<InvenSlot>().isActive == false ||
                GameObject.Find($"{this.name}").GetComponent<InvenSlot>().isActive ==false ||
                GameObject.Find($"{(int.Parse(this.name)+9)}").GetComponent<InvenSlot>().isActive == false)
                {
                    InventoryManager.Instance.addItemAvailable = false;
                    GameObject.Find("itemImg").transform.position = this.gameObject.transform.position;
                    GameObject.Find("itemImg").GetComponent<Image>().color = new Color32(255, 0, 0, 100);
                    target.GetComponent<itemSize>().CheckStart = false;
                }

            }
        }

        if(GameObject.Find("item").GetComponent<ItemTest>()._Rotation%2==1)
        {
            if(GameObject.Find("item").GetComponent<ItemTest>().isClicked ==true&&target.GetComponent<itemSize>().CheckStart == true)
            {
                //test-> sizeX=3, sizeY=1
                if(GameObject.Find($"{(int.Parse(this.name)-1)}").GetComponent<InvenSlot>().isFilled == false)
                    //&& GameObject.Find($"{(int.Parse(this.name)-9)}").GetComponent<InvenSlot>().isActive == true)
                {
                    GameObject.Find("Block1").GetComponent<itemSize>().isReady = true;
                }

                if(GameObject.Find($"{this.name}").GetComponent<InvenSlot>().isFilled == false)
                    //&& GameObject.Find($"{this.name}").GetComponent<InvenSlot>().isActive ==true)
                {
                    GameObject.Find("Core").GetComponent<itemSize>().isReady = true;
                }
                if(GameObject.Find($"{(int.Parse(this.name)+1)}").GetComponent<InvenSlot>().isFilled == false)
                    //&& GameObject.Find($"{(int.Parse(this.name)+9)}").GetComponent<InvenSlot>().isActive == true)
                {
                    GameObject.Find("Block2").GetComponent<itemSize>().isReady = true;
                }
            }

            if(GameObject.Find("Block1").GetComponent<itemSize>().isReady == true &&
            GameObject.Find("Block2").GetComponent<itemSize>().isReady == true &&
            GameObject.Find("Core").GetComponent<itemSize>().isReady == true)
            {
                if(GameObject.Find($"{(int.Parse(this.name)-1)}").GetComponent<InvenSlot>().isActive == true &&
                GameObject.Find($"{this.name}").GetComponent<InvenSlot>().isActive ==true &&
                GameObject.Find($"{(int.Parse(this.name)+1)}").GetComponent<InvenSlot>().isActive == true)
                {
                    InventoryManager.Instance.addItemAvailable = true;
                    GameObject.Find("itemImg").transform.position = this.gameObject.transform.position;
                    GameObject.Find("itemImg").GetComponent<Image>().color = new Color32(255, 255, 255, 100);
                    target.GetComponent<itemSize>().CheckStart = false;
                }
                //GameObject.Find("item").transform.position = this.gameObject.transform.position;
                else if(GameObject.Find($"{(int.Parse(this.name)-1)}").GetComponent<InvenSlot>().isActive == false ||
                GameObject.Find($"{this.name}").GetComponent<InvenSlot>().isActive ==false ||
                GameObject.Find($"{(int.Parse(this.name)+1)}").GetComponent<InvenSlot>().isActive == false)
                {
                    InventoryManager.Instance.addItemAvailable = false;
                    GameObject.Find("itemImg").transform.position = this.gameObject.transform.position;
                    GameObject.Find("itemImg").GetComponent<Image>().color = new Color32(255, 0, 0, 100);
                    target.GetComponent<itemSize>().CheckStart = false;
                }

            }
        }
        

        if(GameObject.Find("item").GetComponent<ItemTest>().isClicked ==true&&target.GetComponent<itemSize>().CheckStart == false)
        {
                GameObject.Find("Block1").GetComponent<itemSize>().isReady = false;
                GameObject.Find("Block2").GetComponent<itemSize>().isReady = false;
                GameObject.Find("Core").GetComponent<itemSize>().isReady =false;//?
                
        }

        //Debug.Log(Vector2.Distance(GameObject.Find("itemImg").transform.position, GameObject.Find("item").transform.position));
        /* if(Vector2.Distance(GameObject.Find("itemImg").transform.position, GameObject.Find("item").transform.position)>0.4)
        {
            GameObject.Find("itemImg").transform.position = GameObject.Find("item").transform.position;
            GameObject.Find("itemImg").GetComponent<Image>().color = new Color32(255, 255, 255, 100);

        } */




        //test

    }

    private void OnMouseDown() {
        Debug.Log(this.name);
        if(isTemporary == true)
        {
            isActive = true;
            gameObject.GetComponent<Image>().color = new Color(1,1,1,1);
            InventoryManager.Instance.lvUpPoint --;
            isTemporary = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        readyToFill = true;
    }

    private void OnCollisionExit2D(Collision2D other) {
        readyToFill = false;
    }


}
