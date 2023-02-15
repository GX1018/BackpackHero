using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemSize : MonoBehaviour
{
    public bool isReady = false;
    public bool CheckStart = false;


    private GameObject[] target;
    private float Dist;

    //인벤 슬롯 체크

    public bool invenSlotisActive = false;
    //인벤 슬롯 체크

    public GameObject nearestSlot;

    // Start is called before the first frame update
    void Start()
    {
        isReady = false;
        CheckStart = false;
        invenSlotisActive = false;
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
            if (nearestSlot.GetComponent<InvenSlot>().isActive == true)
            {
                invenSlotisActive = true;
            }
            else { invenSlotisActive = false; }
        }






    }
}
