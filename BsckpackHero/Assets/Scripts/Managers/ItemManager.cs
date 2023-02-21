using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    private static ItemManager instance;

    public static ItemManager Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        }
    }

    public Item[] itemList;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        if (MapManager.Instance.floor == 0)
        {
            itemList = Resources.LoadAll<Item>("Items/Tutorial_Items");
        }
        else
        {
            itemList = Resources.LoadAll<Item>("Items");
        }
    }

    //{ item 생성 관련 변수
    Item item;

    GameObject itemPrefab;

    List<int> itemSize;

    int sizeX;
    int sizeY;

    int ranNum;

    public int size2D;

    public int cost;
    public int atk;
    public int def;
    //} item 생성 관련 변수

    //{ 아이템 생성 함수
    public void CreateItem(int num)
    {
        if (MapManager.Instance.floor == 0)
        {
            ranNum = num;
        }
        else
        {
            ranNum = Random.Range(0, ItemManager.Instance.itemList.Length);
        }
        item = ItemManager.Instance.itemList[ranNum];

        itemPrefab = Resources.Load<GameObject>("Prefabs/ItemPrefabTest");

        sizeX = item.SizeX;
        sizeY = item.SizeY;
        cost = item.Cost;
        atk = item.Atk;
        def = item.Def;

        GameObject clone = Instantiate(itemPrefab, GameObject.Find("Items").transform);//transform 조정 //test중
        clone.name = item.ItemName;

        clone.AddComponent<ItemTest>(); // 스크립트 삽입// 나중에 개별 스크립트 설정후 변경?
        clone.GetComponent<ItemTest>().isCreated = true;
        clone.GetComponent<ItemTest>().sizeX = sizeX;
        clone.GetComponent<ItemTest>().sizeY = sizeY;
        clone.GetComponent<ItemTest>().cost = cost;
        clone.GetComponent<ItemTest>().def = def;
        clone.GetComponent<ItemTest>().atk = atk;



        switch (sizeX)
        {
            case 1:
                clone.transform.GetChild(0).gameObject.SetActive(false);
                clone.transform.GetChild(2).gameObject.SetActive(false);
                clone.transform.GetChild(3).gameObject.SetActive(false);
                clone.transform.GetChild(5).gameObject.SetActive(false);
                clone.transform.GetChild(6).gameObject.SetActive(false);
                clone.transform.GetChild(8).gameObject.SetActive(false);

                break;

            case 2:
                clone.transform.GetChild(0).gameObject.SetActive(false);
                clone.transform.GetChild(3).gameObject.SetActive(false);
                clone.transform.GetChild(6).gameObject.SetActive(false);
                break;
            case 3:
                break;
        }

        switch (sizeY)
        {
            case 1:
                clone.transform.GetChild(0).gameObject.SetActive(false);
                clone.transform.GetChild(1).gameObject.SetActive(false);
                clone.transform.GetChild(2).gameObject.SetActive(false);
                clone.transform.GetChild(6).gameObject.SetActive(false);
                clone.transform.GetChild(7).gameObject.SetActive(false);
                clone.transform.GetChild(8).gameObject.SetActive(false);
                break;

            case 2:
                clone.transform.GetChild(0).gameObject.SetActive(false);
                clone.transform.GetChild(1).gameObject.SetActive(false);
                clone.transform.GetChild(2).gameObject.SetActive(false);
                break;

            case 3:
                break;
        }

        for (int i = 0; i < clone.transform.childCount; i++)
        {
            if (clone.transform.GetChild(i).gameObject.activeSelf == false)
            {
                Destroy(clone.transform.GetChild(i).gameObject);
            }
        }

        //메인오브젝트 사이즈
        clone.GetComponent<RectTransform>().sizeDelta = new Vector2(70 * sizeX, 70 * sizeY);

        //메인 이미지
        clone.transform.GetChild(10).GetComponent<Image>().sprite = item.ItemImage;
        clone.transform.GetChild(10).GetComponent<RectTransform>().sizeDelta = new Vector2(70 * sizeX, 70 * sizeY);
        //인벤 체크용 이미지
        clone.transform.GetChild(9).GetComponent<Image>().sprite = item.ItemImage;
        clone.transform.GetChild(9).GetComponent<RectTransform>().sizeDelta = new Vector2(70 * sizeX, 70 * sizeY);

        //아이템 블록 위치 조정

        if (sizeX == 2)
        {
            for (int i = 0; i < 9; i++)
            {
                clone.transform.GetChild(i).GetComponent<RectTransform>().anchoredPosition
                = new Vector2(clone.transform.GetChild(i).GetComponent<RectTransform>().anchoredPosition.x - 35, clone.transform.GetChild(i).GetComponent<RectTransform>().anchoredPosition.y);
            }
        }

        if (sizeY == 2)
        {
            for (int i = 0; i < 9; i++)
            {
                clone.transform.GetChild(i).GetComponent<RectTransform>().anchoredPosition
                = new Vector2(clone.transform.GetChild(i).GetComponent<RectTransform>().anchoredPosition.x, clone.transform.GetChild(i).GetComponent<RectTransform>().anchoredPosition.y + 35);
            }
        }


        InventoryManager.Instance.rootItemCheck = true;
    }
    //} 아이템 생성 함수

}
