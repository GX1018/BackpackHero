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
    GameObject[] target;
    //test


    // Start is called before the first frame update
    void Start()
    {
        if (this.name == "12"||this.name=="13"||this.name=="14"||this.name=="21"||this.name=="22"||this.name=="23"
        ||this.name=="30"||this.name=="31"||this.name=="32")
        {
            isActive = true;
        }
        target = GameObject.FindGameObjectsWithTag("ItemBlock");

    }

    // Update is called once per frame
    void Update()
    {
        if(isActive ==true)
        {
            gameObject.GetComponent<Image>().enabled =true;
        }
        
        else if(isTemporary ==true&&gameObject.transform.parent.gameObject.GetComponent<InventorySlots>().lvUpPoint>0)
        {
            gameObject.GetComponent<Image>().enabled = true;
            gameObject.GetComponent<Image>().color = new Color(1,1,1,0.5f);
        }
        else if(gameObject.transform.parent.gameObject.GetComponent<InventorySlots>().lvUpPoint<=0)
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
        




        /* if (GameObject.Find("item").GetComponent<Item>().isClicked ==true&& isActive == true&& target[0].GetComponent<itemSize>().inInventory == false)
        {
            
            Dist =Vector2.Distance(transform.position, target[0].transform.position);
            Debug.Log(this.name);
            Debug.Log(Dist);

            if(Dist < 1.8f)
            {
                target[0].transform.position = this.gameObject.transform.position;
                target[0].GetComponent<itemSize>().inInventory = true;
                //GameObject.Find("item").GetComponent<Item>().isClicked = false;
            }
        } */

        //test

    }

    private void OnMouseDown() {
        Debug.Log(this.name);
        if(isTemporary == true)
        {
            isActive = true;
            gameObject.GetComponent<Image>().color = new Color(1,1,1,1);
            transform.parent.gameObject.GetComponent<InventorySlots>().lvUpPoint --;
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
