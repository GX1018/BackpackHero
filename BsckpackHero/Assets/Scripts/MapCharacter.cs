using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCharacter : MonoBehaviour
{
    GameObject nearestMapBox;

    int playerPos;

    int nextPos;

    int moveDistance;

    public bool inCrossroads = false;
    // Start is called before the first frame update
    void Start()
    {
        playerPos = MapManager.Instance.playerPos;

    }

    // Update is called once per frame
    void Update()
    {
        FindNearestMapBox();


        int targetPos = MapManager.Instance.targetPos;

        if (MapManager.Instance.moveCharacter == true)
        {
            CharacterManager.Instance.isWalk = true;
            //타겟 - 메인
            if (transform.parent.GetChild(targetPos).GetComponent<mapBox>().mainSteet)
            {
                if (playerPos <= targetPos)
                {
                    for (int i = playerPos; i < targetPos; i++)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, transform.parent.GetChild(playerPos + 1).position, 1f * Time.deltaTime);
                        if (transform.position == transform.parent.GetChild(playerPos + 1).position)
                        {
                            playerPos++;
                        }
                    }
                }

                else if (playerPos > targetPos)
                {
                    for (int i = playerPos; i > targetPos; i--)
                    {
                        //playerPos~ firstSubRoad까지 i--, playerPos == firstSubRoad
                        
                        transform.position = Vector3.MoveTowards(transform.position, transform.parent.GetChild(playerPos - 1).position, 1f * Time.deltaTime);
                        if (transform.position == transform.parent.GetChild(playerPos - 1).position)
                        {
                            playerPos--;
                        }
                    }

                }
                
            }
            //타겟 - 서브
            else if (transform.parent.GetChild(targetPos).GetComponent<mapBox>().subSteet)
            {

                //갈림길 도착까지
                if (playerPos <= MapManager.Instance.crossroads)
                {
                    for (int i = playerPos; i < MapManager.Instance.crossroads; i++)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, transform.parent.GetChild(playerPos + 1).position, 1f * Time.deltaTime);
                        if (transform.position == transform.parent.GetChild(playerPos + 1).position)
                        {
                            playerPos++;
                        }
                    }
                    if (transform.position == transform.parent.GetChild(MapManager.Instance.crossroads).position)
                    {
                        inCrossroads = true;
                    }
                    if (inCrossroads == true)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, transform.parent.GetChild(MapManager.Instance.firstSubRoad).position, 1f * Time.deltaTime);
                        if (transform.position == transform.parent.GetChild(MapManager.Instance.firstSubRoad).position)
                        {
                            playerPos = MapManager.Instance.firstSubRoad;
                            //inCrossroads = false;
                            Debug.Log(playerPos);
                        }
                    }
                }
                //갈림길 이후
                if (playerPos >= MapManager.Instance.firstSubRoad && playerPos <= MapManager.Instance.lastSubRoad)
                {
                    if (targetPos > playerPos)
                    {
                        for (int i = playerPos; i < MapManager.Instance.lastSubRoad; i++)
                        {
                            transform.position = Vector3.MoveTowards(transform.position, transform.parent.GetChild(playerPos + 1).position, 1f * Time.deltaTime);
                            if (transform.position == transform.parent.GetChild(playerPos + 1).position)
                            {
                                playerPos++;
                            }
                        }
                    }
                    else if (targetPos < playerPos)
                    {
                        for (int i = playerPos; i > MapManager.Instance.firstSubRoad; i--)
                        {
                            transform.position = Vector3.MoveTowards(transform.position, transform.parent.GetChild(playerPos - 1).position, 1f * Time.deltaTime);
                            if (transform.position == transform.parent.GetChild(playerPos - 1).position)
                            {
                                playerPos--;
                            }
                        }
                    }


                }
            }



            if (transform.position == transform.parent.GetChild(targetPos).position)
            {
                CharacterManager.Instance.isWalk = false;

                MapManager.Instance.moveCharacter = false;
            }
        }

    }

    public void FindNearestMapBox()
    {
        float minDistance = 10;
        for (int i = 0; i < transform.parent.childCount - 1; i++)
        {

            if (minDistance > Vector2.Distance(transform.position, transform.parent.GetChild(i).position))
            {
                MapManager.Instance.nearestMapBox = transform.parent.GetChild(i).gameObject;
                MapManager.Instance.playerPos = i;
                minDistance = Vector2.Distance(transform.position, transform.parent.GetChild(i).position);
            }
        }
    }

    public void MoveCharacter()
    {

    }


}
