using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    private static ItemManager instance;

    public GameObject fieldItems;
    public GameObject inventoryItems;
    public List<GameObject> inventoryItemsList;

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

        /* if (MapManager.Instance.floor == 0 && MapManager.Instance.inStore == false)
        {
            itemList = Resources.LoadAll<Item>("Items/Tutorial_Items");
        }
        else
        {
            itemList = Resources.LoadAll<Item>("Items");
        } */

        itemList = Resources.LoadAll<Item>("Items");
    }

    private void Update()
    {
        //{ 소모 아이템 사용시 애니메이션 처리
        if (useItemWaypoint == 1)
        {
            time += Time.deltaTime;
            if (time >= 0.5f)
            {
                CharacterManager.Instance.animator.SetTrigger("UseItemEnd");
                useItemWaypoint = 0;
                time = 0;
            }
        }
        //} 소모 아이템 사용시 애니메이션 처리
    }


    //{ 소모 아이템 사용시 애니메이션 처리를 위한 변수
    public int useItemWaypoint;
    private float time = 0;
    //} 소모 아이템 사용시 애니메이션 처리를 위한 변수

    //{ item 생성 관련 변수
    public Item[] itemList;
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

    //소모템용
    public int heal;
    public int consumableCount;
    public bool consumable;



    //이미지 변환용
    public bool isImageChange;
    public Sprite itemImage2;
    public int chageTiming;

    GameObject clone;

    //} item 생성 관련 변수

    //{ 아이템 생성 함수
    public void CreateItem(int num)
    {

        

        if (MapManager.Instance.isTutorial && MapManager.Instance.inStore == false)
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

        //
        heal = item.Heal;
        consumableCount = item.ConsumableCount;
        consumable = item.Consumable;

        //
        isImageChange = item.IsImageChange;
        if (MapManager.Instance.inStore == false)
        {
            clone = Instantiate(itemPrefab, fieldItems.transform);//transform 조정 //test중
        }
        else if (MapManager.Instance.inStore == true)
        {
            clone = Instantiate(itemPrefab, GameObject.Find("Merchant").transform);//transform 조정 //test중
        }
        clone.name = item.ItemName;

        clone.AddComponent<ItemTest>(); // 스크립트 삽입// 나중에 개별 스크립트 설정후 변경?
        clone.GetComponent<ItemTest>().isCreated = true;
        clone.GetComponent<ItemTest>().sizeX = sizeX;
        clone.GetComponent<ItemTest>().sizeY = sizeY;
        clone.GetComponent<ItemTest>().cost = cost;
        clone.GetComponent<ItemTest>().def = def;
        clone.GetComponent<ItemTest>().atk = atk;

        clone.GetComponent<ItemTest>().heal = heal;
        clone.GetComponent<ItemTest>().consumableCount = consumableCount;
        clone.GetComponent<ItemTest>().consumable = consumable;

        clone.GetComponent<ItemTest>().isImageChange = item.IsImageChange;
        clone.GetComponent<ItemTest>().itemImage2 = item.ItemImage2;
        clone.GetComponent<ItemTest>().chageTiming = item.ChageTiming;

        //
        float ranPosX = Random.Range(-7.5f, 7.5f);
        float ranPosY = Random.Range(-1f, -4.5f);
        clone.transform.position = new Vector3(ranPosX, ranPosY, 100);
        //





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
        clone.transform.GetChild(10).GetComponent<Image>().sprite = item.ItemImage1;
        clone.transform.GetChild(10).GetComponent<RectTransform>().sizeDelta = new Vector2(70 * sizeX, 70 * sizeY);
        //인벤 체크용 이미지
        clone.transform.GetChild(9).GetComponent<Image>().sprite = item.ItemImage1;
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
