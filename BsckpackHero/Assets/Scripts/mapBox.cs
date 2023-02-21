using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class mapBox : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isCharacterIn = false;
    public bool isFilled = false;
    public bool canMove = false;
    public int currentPos = 0;
    public int thisPos;
    string[] split_name;

    public int playerPos = 0;

    Vector2 targetPos;

    int test = 0;


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
    }

    // Update is called once per frame
    void Update()
    {
        //박스 안에 다른 오브젝트가 있는지 체크(배틀/이벤트/다음층)
        if (transform.childCount > 0)
        {
            isFilled = true;
        }
        else
        {
            isFilled = false;
        }
        //박스 안에 다른 오브젝트가 있는지 체크(배틀/이벤트/다음층)

        //다른 오브젝트가 있는 박스에 캐릭터가 들어왔을때,
        if (isFilled == true && isCharacterIn == true)
        {
            if (transform.GetChild(0).name == "Chest")
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

                if(BattleManager.Instance.enemyInBattle.Count==0)
                {
                    CharacterManager.Instance.isBattleMode = false;
                    Destroy(transform.GetChild(0).gameObject);
                }
            }
            else if (transform.GetChild(0).name == "NextFloor")
            {

            }
        }
        //다른 오브젝트가 있는 박스에 캐릭터가 들어왔을때





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
    }

    public void OnPointerUp(PointerEventData eventData)
    {

    }



    public void checkMove()
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
