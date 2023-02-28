using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class mapBox : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isActive = false;

    public bool isCharacterIn = false;
    public bool isFilled = false;
    public bool isPassable = false;
    public bool canMove = false;
    public int currentPos = 0;
    public int thisPos;
    string[] split_name;

    public int playerPos = 0;

    Vector2 targetPos;

    int test = 0;
    //
    public bool mainSteet;
    public bool subSteet;
    //

    public int thisCrossroad;
    public int thisSub_1;
    public int thisSubEnd = default;

    bool positionCheck;




    // Start is called before the first frame update
    void Start()
    {
        thisPos = MapManager.Instance.mapBoxArray.IndexOf(this.gameObject);


        //시작시 캐릭터 위치를 box0의 위치로 설정
        GameObject.Find("MapCharacter").transform.position = transform.parent.GetChild(0).position;

        if (thisPos == 0)
        {
            isCharacterIn = true;
            canMove = true;
        }
        else
        {
            isCharacterIn = false;
        }


        //상점은 이동 가능하게 설정
        if (transform.childCount > 0)
        {
            if (transform.GetChild(0).name == "Store")
            {
                isPassable = true;
            }
        }

        if (subSteet)
        {
            split_name = this.name.Split("_");
            for (int i = 0; i < MapManager.Instance.mapBoxArray.Count; i++)
            {
                if (MapManager.Instance.mapBoxArray[i].name == split_name[0])
                {
                    thisCrossroad = i;
                }
                if (MapManager.Instance.mapBoxArray[i].name == split_name[0] + "_1")
                {
                    thisSub_1 = i;
                }
                if (MapManager.Instance.mapBoxArray[i].name == split_name[0] + "_End")
                {
                    thisSubEnd = i;
                }
            }
            if (thisSubEnd == default)
            {
                thisSubEnd = thisSub_1;
            }
        }
        positionCheck = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!positionCheck)
        {
            thisPos = MapManager.Instance.mapBoxArray.IndexOf(this.gameObject);

            if (subSteet)
            {
                split_name = this.name.Split("_");
                for (int i = 0; i < MapManager.Instance.mapBoxArray.Count; i++)
                {
                    if (MapManager.Instance.mapBoxArray[i].name == split_name[0])
                    {
                        thisCrossroad = i;
                    }
                    if (MapManager.Instance.mapBoxArray[i].name == split_name[0] + "_1")
                    {
                        thisSub_1 = i;
                    }
                    if (MapManager.Instance.mapBoxArray[i].name == split_name[0] + "_End")
                    {
                        thisSubEnd = i;
                    }
                }
                if (thisSubEnd == default)
                {
                    thisSubEnd = thisSub_1;
                }
            }

            //시작시 캐릭터 위치를 box0의 위치로 설정
            GameObject.Find("MapCharacter").transform.position = transform.parent.GetChild(0).position;

            if (thisPos == 0)
            {
                isCharacterIn = true;
                canMove = true;
            }
            else
            {
                isCharacterIn = false;
            }


            //상점은 이동 가능하게 설정
            if (transform.childCount > 0)
            {
                if (transform.GetChild(0).name == "Store")
                {
                    isPassable = true;
                }
            }

            positionCheck = true;
        }



        //박스 안에 다른 오브젝트가 있는지 체크(배틀/이벤트/다음층)
        if (isPassable == true)
        {
            isFilled = false;
        }
        else if (transform.childCount > 0)
        {
            isFilled = true;
        }
        else
        {
            isFilled = false;
        }
        //박스 안에 다른 오브젝트가 있는지 체크(배틀/이벤트/다음층)

        //다른 오브젝트가 있는 박스에 캐릭터가 들어왔을때,
        if ((isFilled == true || isPassable == true) && isCharacterIn == true)
        {
            if (transform.GetChild(0).name == "MapChest")
            {
                MapManager.Instance.findChest = true;
                if (MapManager.Instance.openChest == true)
                {

                    MapManager.Instance.findChest = false;

                    MapManager.Instance.openChest = false;

                    Destroy(transform.GetChild(0).gameObject);
                }
            }
            else if (transform.GetChild(0).name == "MapEnemy")
            {
                if (CharacterManager.Instance.isBattleMode == false)
                {
                    CharacterManager.Instance.isBattleMode = true;
                }
                transform.GetChild(0).gameObject.GetComponent<MapEnemy>().BattleStart();

                if (BattleManager.Instance.enemyInBattle.Count == 0)
                {
                    GameObject.Find("OnOffUi").transform.GetChild(0).gameObject.SetActive(true);
                    BattleManager.Instance.isWin = true;
                    CharacterManager.Instance.actionPoint = 3;
                    CharacterManager.Instance.isBattleMode = false;
                    MapManager.Instance.createEnd = false;
                    Destroy(transform.GetChild(0).gameObject);
                }
            }
            else if (transform.GetChild(0).name == "NextFloor")
            {
                MapManager.Instance.findDoor = true;
            }
            else if (transform.GetChild(0).name == "Store")
            {
                MapManager.Instance.inStore = true;
            }

        }
        //다른 오브젝트가 있는 박스에 캐릭터가 들어왔을때


        if (isCharacterIn == true)
        {
            if (transform.childCount > 0)
            {
                if (transform.GetChild(0).name != "NextFloor")
                {
                    MapManager.Instance.findDoor = false;
                }
                if (transform.GetChild(0).name != "Store")
                {
                    MapManager.Instance.inStore = false;
                }
            }
            else if (transform.childCount == 0)
            {
                MapManager.Instance.findDoor = false;
                MapManager.Instance.inStore = false;

            }
        }

        //캐릭터와 가장 가까운 박스가 현재 박스이면
        if (MapManager.Instance.nearestMapBox == this.gameObject)
        {
            isCharacterIn = true;
        }
        else
        {
            isCharacterIn = false;
        }


        //캐릭터가 현재 박스까지 이동할 수 있는지 여부 체크
        checkMove();






        //이동 관련
        if (test == 1)
        {
            if (canMove == true)
            {
                MapManager.Instance.targetPos = thisPos;
                MapManager.Instance.moveCharacter = true;
            }

            test = 0;
        }




    }

    public void OnPointerDown(PointerEventData eventData)
    {
        MapManager.Instance.targetPos = thisPos;
        if (subSteet)
        {
            MapManager.Instance.thisCrossroad = thisCrossroad;
            MapManager.Instance.thisSub_1 = thisSub_1;
            MapManager.Instance.thisSubEnd = thisSubEnd;
        }

        test = 1;

        InventoryManager.Instance.removeItem = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        InventoryManager.Instance.removeItem = false;

    }



    public void checkMove()
    {
        if (subSteet)
        {
            for (int i = 0; i < thisCrossroad; i++)
            {
                if (MapManager.Instance.mapBoxArray[i].GetComponent<mapBox>().isFilled == true)
                {
                    canMove = false;
                    break;
                }
                else if (MapManager.Instance.mapBoxArray[i].GetComponent<mapBox>().isFilled == false)
                {
                    for (int j = thisSub_1; j <= thisPos; j++)
                    {

                        if (MapManager.Instance.mapBoxArray[j].GetComponent<mapBox>().isFilled == true)
                        {
                            if (j == thisPos)
                            {
                                canMove = true;
                            }
                            else
                            {
                                canMove = false;
                                break;

                            }
                        }
                        else if (MapManager.Instance.mapBoxArray[j].GetComponent<mapBox>().isFilled == false)
                        {
                            canMove = true;
                        }
                    }
                }
            }
        }

        else if (mainSteet)
        {
            for (int i = 0; i < thisPos; i++)
            {
                if (transform.parent.GetChild(i).GetComponent<mapBox>().isFilled == true)
                {
                    canMove = false;
                    break;
                }
                else if (transform.parent.GetChild(i).GetComponent<mapBox>().isFilled == false)
                {
                    canMove = true;
                }
            }
        }
    }
}
