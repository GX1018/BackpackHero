using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    private static InventoryManager instance;

    public static InventoryManager Instance
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

        inventory = GameObject.Find("Inventory");
        inventoryDefaultIndex = inventory.transform.GetSiblingIndex();


        //
        inventoryDefaultPos = new Vector3(inventory.transform.position.x - 17.78f, inventory.transform.position.y, inventory.transform.position.z);
        inventoryTargetPos = new Vector3(inventoryDefaultPos.x, inventoryDefaultPos.y - 0.69f, inventoryDefaultPos.z);


    }

    private void Update()
    {
        if (rootItemCheck == true)
        {
            ItemRootConfirm();
        }
        //레벨업했을때만 이동
        InventoryMove();
        //레벨업했을때만 이동

    }

    public bool isExpand;

    // inventoryImg에서 인벤 이미지 확장할때 사용
    public int expandRight = 0;
    public int expandLeft = 0;
    public int expandUp = 0;
    public int expandDown = 0;
    //

    //inventoryslots의 레벨업 관련 변수
    public bool isLvup = false;
    public int lvUpPoint = 0;
    //

    //inventoryslot
    public bool addItemAvailable = false;

    //

    public GameObject[,] itemSlot2DArray = new GameObject[11, 7];
    public List<GameObject> activeSlot;


    public bool rootItemCheck = false;

    public bool isBattleMode = false;
    public bool removeItem = false;


    public void ItemRootConfirm()
    {

        rootItemCheck = false;
    }

    public GameObject inventory;

    public Vector3 inventoryDefaultPos;
    public Vector3 inventoryTargetPos;

    public int inventoryDefaultIndex;

    public int moveCheckInt = 0;


    //레벨업 시 인벤 위치 이동 관련


    public void InventoryMove()
    {
        if (moveCheckInt == 1)
        {
            inventory.transform.position = Vector3.MoveTowards(inventory.transform.position, inventoryTargetPos, 1 * Time.deltaTime);
        }

        if (moveCheckInt == 2)
        {
            inventory.transform.position = Vector3.MoveTowards(inventory.transform.position, inventoryDefaultPos, 1 * Time.deltaTime);
            if (inventory.transform.position == inventoryDefaultPos)
            {
                moveCheckInt = 0;
            }
        }
    }


    public List<GameObject> itemInInventory;


}
