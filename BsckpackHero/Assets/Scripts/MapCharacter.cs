using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCharacter : MonoBehaviour
{
    GameObject nearestMapBox;

    int playerPos;
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
            //test용
            //transform.position = transform.parent.GetChild(targetPos).position;

            //test!!
            CharacterManager.Instance.isWalk = true;
            transform.position = Vector3.MoveTowards(transform.position, transform.parent.GetChild(targetPos).position, 1f * Time.deltaTime);


            if (transform.position == transform.parent.GetChild(targetPos).position)
            {
                CharacterManager.Instance.isWalk = false;

                MapManager.Instance.moveCharacter = false;
            }
            //
            //test용


            //기본값 저장
            /* Debug.Log(playerPos);
            Debug.Log(targetPos);

            for (int i = playerPos; i < targetPos; i++)
            {
                transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, transform.position.y, 100),
                new Vector3(transform.parent.GetChild(i + 1).position.x, transform.parent.GetChild(i + 1).position.y, 100), 1f * Time.deltaTime);



                if (transform.position == transform.parent.GetChild(targetPos).position)
                {
                    playerPos = targetPos;
                    MapManager.Instance.moveCharacter = false;
                }
            } */
            //기본값 저장

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
