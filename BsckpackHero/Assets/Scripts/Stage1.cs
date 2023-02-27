using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1 : MonoBehaviour
{
    List<GameObject> mapBoxArray = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.childCount - 1; i++)
        {
            mapBoxArray.Add(transform.GetChild(i).gameObject);
        }

        MapManager.Instance.mapBoxArray = mapBoxArray;


        for (int i = 0; i < transform.childCount - 1; i++)
        {
            if(i <=14)
            {
                transform.GetChild(i).GetComponent<mapBox>().mainSteet =true;
            }
            else if(i>14)
            {
                transform.GetChild(i).GetComponent<mapBox>().subSteet =true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
