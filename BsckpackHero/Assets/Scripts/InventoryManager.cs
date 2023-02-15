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
            if(instance == null)
            {
                return null;
            }
            return instance;
        }
    }
    
    private void Awake() {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

    }

    // inventoryImg에서 인벤 이미지 확장할때 사용
    public int expandRight = 0;
    public int expandLeft = 0;
    public int expandUp = 0;
    public int expandDown = 0;
    //

    //inventoryslots의 레벨업 관련 변수(나중에 캐릭터 생성시 이동 예정)
    public bool isLvup = false;
    public int lvUpPoint = 0;
    //

    //inventoryslot
    public bool addItemAvailable =false;
    //

    public GameObject[,] itemSlot2DArray = new GameObject[11,7]; 

}
