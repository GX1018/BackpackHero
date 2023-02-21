using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Enemy_Script : MonoBehaviour, IPointerDownHandler
{
    public int hp;
    public int maxHp;

    public int minAtk;
    public int maxAtk;
    public int def;
    public int addDef;
    public int xp;

    public bool isTarget = false;




    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTarget == true)
        {
            transform.GetChild(1).gameObject.SetActive(true);
        }
        else if (isTarget == false)
        {
            transform.GetChild(1).gameObject.SetActive(false);
        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        for (int i = 0; i < transform.parent.childCount; i++)
        {
            transform.parent.GetChild(i).gameObject.GetComponent<Enemy_Script>().isTarget = false;
        }
        isTarget = true;
    }

}
