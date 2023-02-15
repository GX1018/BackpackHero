using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TestCreateItem : MonoBehaviour
{
    GameObject item;
    
    GameObject itemPrefab;
    int sizeX;
    int sizeY;
    
    // Start is called before the first frame update
    void Start()
    {
        item = Resources.Load<GameObject>("Prefabs/item");
        itemPrefab = Resources.Load<GameObject>("Prefabs/ItemPrefabTest");

        sizeX = item.GetComponent<ItemTest>().sizeX;
        sizeY = item.GetComponent<ItemTest>().sizeY;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateItem()
    {
        //아이템 이름 item.GetComponent<ItemTest>().name
        //가로 사이즈 item.GetComponent<ItemTest>().sizeX
        //세로 사이즈 item.GetComponent<ItemTest>().sizeY

        GameObject clone = Instantiate(itemPrefab, GameObject.Find("GameObjs").transform);//transform 조정
        clone.name = item.GetComponent<ItemTest>().name;




        clone.AddComponent<ItemTest>(); // 스크립트 삽입// 나중에 개별 스크립트 설정후 변경?

        
        switch(sizeX)
        {
            case 1 :
                clone.transform.GetChild(0).gameObject.SetActive(false);
                clone.transform.GetChild(2).gameObject.SetActive(false);
                clone.transform.GetChild(3).gameObject.SetActive(false);
                clone.transform.GetChild(5).gameObject.SetActive(false);
                clone.transform.GetChild(6).gameObject.SetActive(false);
                clone.transform.GetChild(8).gameObject.SetActive(false);

                break;

            case 2 :
                clone.transform.GetChild(0).gameObject.SetActive(false);
                clone.transform.GetChild(3).gameObject.SetActive(false);
                clone.transform.GetChild(6).gameObject.SetActive(false);
                break;
            case 3 :
            break;
        }
        
        switch(sizeY)
        {
            case 1 :
                clone.transform.GetChild(0).gameObject.SetActive(false);
                clone.transform.GetChild(1).gameObject.SetActive(false);
                clone.transform.GetChild(2).gameObject.SetActive(false);
                clone.transform.GetChild(6).gameObject.SetActive(false);
                clone.transform.GetChild(7).gameObject.SetActive(false);
                clone.transform.GetChild(8).gameObject.SetActive(false);
                break;

            case 2 :
                clone.transform.GetChild(0).gameObject.SetActive(false);
                clone.transform.GetChild(1).gameObject.SetActive(false);
                clone.transform.GetChild(2).gameObject.SetActive(false);
                break;

            case 3 :
            break;
        }


        //이미지
        clone.GetComponent<RectTransform>().sizeDelta = new Vector2(70*sizeX, 70*sizeY);
        clone.GetComponent<Image>().sprite = item.GetComponent<Image>().sprite;

        clone.transform.GetChild(9).GetComponent<Image>().sprite = item.GetComponent<Image>().sprite;
        clone.transform.GetChild(9).GetComponent<RectTransform>().sizeDelta = new Vector2(70*sizeX, 70*sizeY);

        


    }
}
