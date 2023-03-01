using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Merchant : MonoBehaviour, IPointerDownHandler
{
    public List<GameObject> playerItemInStore;
    public List<GameObject> merchantItem;

    public bool createItemInStore = false;
    public bool openStore = false;
    public bool itemListCheck = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (MapManager.Instance.inStore == false)
        {
            //ResetList();
            gameObject.SetActive(false);
        }

        if (openStore == true)
        {
            if (ButtonManager.Instance.changeBtn.GetComponent<changeBtn>().isClickMapBtn == true)
            {
                for (int i = 0; i < merchantItem.Count; i++)
                {
                    if (merchantItem[i].transform.parent == this)
                    {
                        merchantItem[i].SetActive(false);
                    }
                }
            }
            else
            {
                for (int i = 0; i < merchantItem.Count; i++)
                {
                    merchantItem[i].SetActive(true);
                }
            }
        }

        for (int i = 0; i < merchantItem.Count; i++)
        {
            if (merchantItem[i].GetComponent<ItemTest>().itemProperty == "player")
            {
                merchantItem[i].transform.parent = ItemManager.Instance.fieldItems.transform;
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (openStore == false)
        {
            for (int i = 0; i < ItemManager.Instance.fieldItems.transform.childCount; i++)
            {
                playerItemInStore.Add(ItemManager.Instance.fieldItems.transform.GetChild(i).gameObject);
            }
            if (createItemInStore == true)
            {
                //상점 아이템 리스트에서 아이템 출력
                for (int i = 0; i < merchantItem.Count; i++)
                {
                    merchantItem[i].SetActive(true);
                }
            }
            //아이템 생성하지 않았으면
            else if (createItemInStore == false)
            {
                //아이템 생성하고
                int itemNum = Random.Range(7, 10);
                for (int i = 0; i < itemNum; i++)
                {
                    ItemManager.Instance.CreateItem(i);
                }
                if (itemListCheck == false)
                {
                    for (int i = 0; i < transform.childCount; i++)
                    {
                        merchantItem.Add(transform.GetChild(i).gameObject);
                    }
                }
                itemListCheck = true;
                createItemInStore = true;
            }
            openStore = true;
        }
    }

    private void OnEnable()
    {
        ButtonManager.Instance.changeBtn.GetComponent<changeBtn>().changeBtnClick();
    }

    private void OnDisable()
    {
        for (int i = 0; i < merchantItem.Count; i++)
        {
            if (merchantItem[i].GetComponent<ItemTest>().itemProperty == "player")
            {
                merchantItem.Remove(merchantItem[i]);
                Debug.Log(merchantItem.Count);
            }
        }
        //비활성화 될때 플레이어 아이템 리스트 삭제

        playerItemInStore.Clear();
        Debug.Log("체크3");
        Debug.Log(merchantItem.Count);
        for (int i = 0; i < merchantItem.Count; i++)
        {

            merchantItem[i].SetActive(false);

        }
        openStore = false;
    }
}
