using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Chest : MonoBehaviour, IPointerDownHandler
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Map/pack_1");

        if (MapManager.Instance.isTutorial)
        {
            for (int i = 0; i < 3; i++)
            {
                ItemManager.Instance.CreateItem(i);
            }
        }
        else
        {
            for (int i = 0; i < 8; i++)
            {
                ItemManager.Instance.CreateItem(i);
            }

        }
        MapManager.Instance.openChest = true;

        MapManager.Instance.findChest = false;

        //함수 종료 전에 확인 버튼 생성해주기
        GameObject.Find("Button").transform.GetChild(1).gameObject.SetActive(true);
        Destroy(this.gameObject);
    }
}
