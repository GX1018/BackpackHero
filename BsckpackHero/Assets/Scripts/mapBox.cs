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

    //갈림길 indext
    int crossroads;

    //갈림길에서 subSteet로 가는 첫번째 index
    int firstSubRoad;
    int lastSubRoad;



    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < transform.parent.childCount; i++)
        {
            if (transform.parent.GetChild(i).gameObject == this.gameObject)
            {
                thisPos = i;
            }
        }


        if (thisPos == 0)
        {
            isCharacterIn = true;
            canMove = true;
        }
        else
        {
            isCharacterIn = false;
        }


        GameObject.Find("MapCharacter").transform.position = transform.parent.GetChild(0).position;

        if (transform.childCount > 0)
        {
            if (transform.GetChild(0).name == "Store")
            {
                isPassable = true;
            }
        }

        //stage1_1
        for (int i = 0; i < transform.parent.childCount; i++)
        {
            if (i <= 14)
            {
                transform.parent.GetChild(i).GetComponent<mapBox>().mainSteet = true;
            }
            else if (i > 14)
            {
                transform.parent.GetChild(i).GetComponent<mapBox>().subSteet = true;
            }
        }
        //stage1_1
    }

    // Update is called once per frame
    void Update()
    {
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
                    CharacterManager.Instance.actionPoint = 3;
                    CharacterManager.Instance.isBattleMode = false;
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






        if (MapManager.Instance.nearestMapBox == this.gameObject)
        {
            isCharacterIn = true;
        }
        else
        {
            isCharacterIn = false;
        }


        checkMove();







        if (test == 1)
        {

            if (canMove == true)
            {
                MapManager.Instance.targetPos = thisPos;
                MapManager.Instance.moveCharacter = true;
            }

            test = 0;
            /* for (int i = 0; i < thisPos; i++)
            {
            //transform.parent.GetChild(transform.parent.childCount - 1).position = Vector3.MoveTowards(new Vector3(transform.parent.GetChild(transform.parent.childCount - 1).position.x,transform.parent.GetChild(transform.parent.childCount - 1).position.y,100), new Vector3(targetPos.x,targetPos.y,100), 1f * Time.deltaTime);
                transform.parent.GetChild(transform.parent.childCount - 1).position = Vector3.MoveTowards(new Vector3(transform.parent.GetChild(transform.parent.childCount - 1).position.x, transform.parent.GetChild(transform.parent.childCount - 1).position.y, 100),
            new Vector3(transform.parent.GetChild(i).position.x, transform.parent.GetChild(i).position.y, 100), 1f * Time.deltaTime);
            } */

        }




    }

    public void OnPointerDown(PointerEventData eventData)
    {

        for (int i = 0; i < transform.parent.childCount; i++)
        {
            if (transform.parent.GetChild(i).gameObject == this.gameObject)
            {
                MapManager.Instance.targetPos = i;
            }
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
            //갈림길을 찾고
            string[] findCrossraods = this.name.Split('_');

            for (int i = 0; i < transform.parent.childCount; i++)
            {
                if (transform.parent.GetChild(i).name == findCrossraods[0])
                {
                    crossroads = i;
                }
                if (transform.parent.GetChild(i).name == findCrossraods[0] + "_1")
                {
                    firstSubRoad = i;
                }
                if (transform.parent.GetChild(i).name == findCrossraods[0] + "_End")
                {
                    lastSubRoad = i;
                }
            }
            MapManager.Instance.crossroads = crossroads;
            MapManager.Instance.firstSubRoad = firstSubRoad;
            MapManager.Instance.lastSubRoad = lastSubRoad;
            //



            for (int i = 0; i < crossroads; i++)
            {
                if (transform.parent.GetChild(i).GetComponent<mapBox>().isFilled == true)
                {
                    canMove = false;
                    break;
                }
                else if (transform.parent.GetChild(i).GetComponent<mapBox>().isFilled == false)
                {
                    for (int j = firstSubRoad; j <= thisPos; j++)
                    {

                        if (transform.parent.GetChild(j).GetComponent<mapBox>().isFilled == true)
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
                        else if (transform.parent.GetChild(j).GetComponent<mapBox>().isFilled == false)
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
