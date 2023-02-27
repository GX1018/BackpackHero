using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCharacter : MonoBehaviour
{
    GameObject nearestMapBox;

    int playerPos;

    int nextPos;

    int moveDistance;
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

        //0227+
        //moveDistance = targetPos - playerPos;
        //int waypoint = 0;
        //0227+

        if (MapManager.Instance.moveCharacter == true)
        {
            //test용
            //transform.position = transform.parent.GetChild(targetPos).position;

            //test!!
            CharacterManager.Instance.isWalk = true;
            //transform.position = Vector3.MoveTowards(transform.position, transform.parent.GetChild(targetPos).position, 1f * Time.deltaTime);

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

            else if(playerPos > targetPos)
            {
                for (int i = playerPos; i > targetPos; i--)
                {
                    transform.position = Vector3.MoveTowards(transform.position, transform.parent.GetChild(playerPos - 1).position, 1f * Time.deltaTime);
                    if (transform.position == transform.parent.GetChild(playerPos - 1).position)
                    {
                        playerPos--;
                    }
                }
            }


            if (transform.position == transform.parent.GetChild(targetPos).position)
            {
                CharacterManager.Instance.isWalk = false;

                MapManager.Instance.moveCharacter = false;
            }
            //
            //test용


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
