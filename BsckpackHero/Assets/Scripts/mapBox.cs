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

            //transform.parent.GetChild(transform.parent.childCount - 1).position = Vector3.MoveTowards(new Vector3(transform.parent.GetChild(transform.parent.childCount - 1).position.x,transform.parent.GetChild(transform.parent.childCount - 1).position.y,100), new Vector3(targetPos.x,targetPos.y,100), 1f * Time.deltaTime);
            for (int i = 0; i < thisPos; i++)
            {
                transform.parent.GetChild(transform.parent.childCount - 1).position = Vector3.MoveTowards(new Vector3(transform.parent.GetChild(transform.parent.childCount - 1).position.x, transform.parent.GetChild(transform.parent.childCount - 1).position.y, 100),
            new Vector3(transform.parent.GetChild(i).position.x, transform.parent.GetChild(i).position.y, 100), 1f * Time.deltaTime);
            }

        }




    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //클릭했을때 현재 위치에 캐릭터가 있는지 여부 체크
        //없을때
        if (isCharacterIn == false)
        {
            //{ 캐릭터가 있는 pos 찾기
            for (int i = 0; i < transform.parent.childCount; i++)
            {
                if (transform.parent.GetChild(i).GetComponent<mapBox>().isCharacterIn == true)
                {
                    playerPos = i;
                    break;
                }
            }
            //{ 캐릭터가 있는 pos 찾기

            /* //현재 위치보다 캐릭터의 위치가 앞에 있을때
            if(playerPos < thisPos)
            {
                for(int i = playerPos + 1; i <= thisPos; i++)
                {
                    if(transform.parent.GetChild(i).GetComponent<mapBox>().isFilled == false)
                    {
                        canMove = true;
                    }
                }
            }
            //현재 위치보다 캐릭터의 위치가 앞에 있을때

            //현재 위치보다 캐릭터의 위치가 뒤에 있을때
            else if(playerPos > thisPos)
            {

            }
            //현재 위치보다 캐릭터의 위치가 뒤에 있을때 */


        }

        targetPos = this.transform.position;



        test = 1;

    }

    public void OnPointerUp(PointerEventData eventData)
    {

    }



    public void checkMove()
    {
        //현재 위치보다 캐릭터의 위치가 앞에 있을때
        if (playerPos < thisPos)
        {
            for (int i = playerPos + 1; i <= thisPos; i++)
            {
                if (transform.parent.GetChild(i).GetComponent<mapBox>().isFilled == true)
                {
                    canMove = false;
                    break;
                }
                if (transform.parent.GetChild(i).GetComponent<mapBox>().isFilled == false)
                {
                    canMove = true;
                }
            }
        }
        //현재 위치보다 캐릭터의 위치가 앞에 있을때

        //현재 위치보다 캐릭터의 위치가 뒤에 있을때
        else if (playerPos > thisPos)
        {
            for (int i = playerPos - 1; i >= thisPos; i--)
            {
                if (transform.parent.GetChild(i).GetComponent<mapBox>().isFilled == true)
                {
                    canMove = false;
                    break;
                }
                if (transform.parent.GetChild(i).GetComponent<mapBox>().isFilled == false)
                {
                    canMove = true;
                }
            }
        }
        //현재 위치보다 캐릭터의 위치가 뒤에 있을때
    }
}
