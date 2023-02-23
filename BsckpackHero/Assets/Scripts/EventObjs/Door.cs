using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Door : MonoBehaviour, IPointerDownHandler
{
    private bool characterMove;

    Vector3 characterPos;
    // Start is called before the first frame update
    void Start()
    {
        characterMove = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (MapManager.Instance.findDoor == false)
        {
            gameObject.SetActive(false);
        }
        else{/*do nothing*/}

        if (characterMove == true)
        {
            CharacterManager.Instance.characterMain.transform.position = Vector3.MoveTowards(CharacterManager.Instance.characterMain.transform.position, transform.position, 3f * Time.deltaTime);
        }
        
        if (CharacterManager.Instance.characterMain.transform.position == transform.position)
        {
            characterMove = false;
            MapManager.Instance.nextFloor = true;
            MapManager.Instance.screenTrans.SetActive(true);
        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //문으로 캐릭터 이동 // 화면 전환 // 맵 교체
        characterMove = true;

    }
}
