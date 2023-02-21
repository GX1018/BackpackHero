using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Chest : MonoBehaviour, IPointerDownHandler
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Map/pack_1");


        for (int i = 0; i < 3; i++)
        {
            //GameObject.Find("TestCeateItem").GetComponent<TestCreateItem>().CreateItem(i);  //testcreateitem >> itemManager로 이동예정
            ItemManager.Instance.CreateItem(i);  //testcreateitem >> itemManager로 이동예정
        }
        MapManager.Instance.openChest =true;

        MapManager.Instance.findChest =false;
        
        //함수 종료 전에 확인 버튼 생성해주기
        Destroy(this.gameObject);
    }
}
