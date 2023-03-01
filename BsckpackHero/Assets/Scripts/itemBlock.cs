using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemBlock : MonoBehaviour
{
    public bool isReady = false;
    public bool CheckStart = false;


    private GameObject[] target;
    private float Dist;

    //인벤 슬롯 체크

    public bool invenSlotisActive = false;
    public bool invenSlotisEmpty = false;
    //인벤 슬롯 체크

    public GameObject nearestSlot;

    // Start is called before the first frame update
    void Start()
    {
        isReady = false;
        CheckStart = false;
        invenSlotisActive = false;
        invenSlotisEmpty = false;
        target = GameObject.FindGameObjectsWithTag("InvenSlot");

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent.GetComponent<ItemTest>().isClicked == true)
        {
            float defaultDist = 10;
            for (int i = 0; i < target.Length; i++)
            {
                Vector2.Distance(transform.position, target[i].transform.position);
                if (defaultDist > Vector2.Distance(transform.position, target[i].transform.position))
                {
                    defaultDist = Vector2.Distance(transform.position, target[i].transform.position);
                    nearestSlot = target[i];
                }
            }

            //가까운 인벤토리 슬롯의 활성화 여부 체크
            if (nearestSlot.GetComponent<InvenSlot>().isActive == true)
            {
                invenSlotisActive = true;
            }
            else { invenSlotisActive = false; }
            //가까운 인벤토리 슬롯의 활성화 여부 체크

            //가까운 인벤토리 슬롯이 비어있는지 여부 체크
            if (nearestSlot.GetComponent<InvenSlot>().isEmpty == true)
            {
                invenSlotisEmpty = true;
            }
            else { invenSlotisEmpty = false; }
            //가까운 인벤토리 슬롯이 비어있는지 여부 체크
        }

    }
}
