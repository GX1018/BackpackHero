using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeBtn : MonoBehaviour
{
    
    GameObject invenAndMap;
    /* Vector3 targetPosition1;
    Vector3 targetPosition2; */

    public bool isClickInventoryBtn = false;
    public bool isClickMapBtn = true;

    public Sprite imageBag;
    public Sprite imageMap;
    
    
    // Start is called before the first frame update
    void Start()
    {
        invenAndMap = GameObject.Find("Inventory&Map");
        ButtonManager.Instance.changeBtn = this.gameObject;
        /* targetPosition1 = GameObject.Find("UiMoveTarget1").transform.position;
        targetPosition2 = GameObject.Find("UiMoveTarget2").transform.position; */
    }

    // Update is called once per frame
    void Update()
    {
        /* Debug.Log(targetPosition1);
        Debug.Log(targetPosition2); */

        if(isClickInventoryBtn==true)
        {
            invenAndMap.transform.position = Vector3.MoveTowards(invenAndMap.transform.position, new Vector3(-8.89f, 2.22f, 100), 100f*Time.deltaTime);
        }
        else if(isClickMapBtn == true)
        {
            invenAndMap.transform.position = Vector3.MoveTowards(invenAndMap.transform.position, new Vector3(8.89f, 2.22f, 100), 100f*Time.deltaTime);
        }

        if( (MapManager.Instance.findChest == true || CharacterManager.Instance.isBattleMode == true) && isClickMapBtn == true)
        {
            isClickInventoryBtn = true;
            this.gameObject.GetComponent<Image>().sprite = imageMap;
            isClickMapBtn=false;
        }
    }

    public void changeBtnClick(){
        if(isClickMapBtn == true)
        {
            isClickInventoryBtn = true;
            this.gameObject.GetComponent<Image>().sprite = imageMap;
            isClickMapBtn=false;
        }

        else if(isClickInventoryBtn == true)
        {
            isClickMapBtn = true;
            this.gameObject.GetComponent<Image>().sprite = imageBag;

            isClickInventoryBtn=false;
        }
        
        
        //invenAndMap.transform.position = Vector3.MoveTowards(invenAndMap.transform.position, targetPosition, 1f*Time.deltaTime);
    }
}
