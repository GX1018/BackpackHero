    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMain : MonoBehaviour
{
    List<GameObject> mapBoxArray = new List<GameObject>();
    bool isTutorial;


    // Start is called before the first frame update
    void Start()
    {
        MapManager.Instance.MapRoot = transform.parent.gameObject;

        if (this.name == "TutorialMap")
        {
            isTutorial = true;
        }
        else
        {
            isTutorial = false;
        }
        MapManager.Instance.isTutorial = isTutorial;


        for (int i = 0; i < transform.childCount - 1; i++)
        {
            mapBoxArray.Add(transform.GetChild(i).gameObject);
        }
        MapManager.Instance.mapBoxArray = mapBoxArray;

        if (isTutorial)
        {
            for (int i = 0; i < transform.childCount - 1; i++)
            {
                transform.GetChild(i).GetComponent<mapBox>().mainSteet = true;
            }
        }

        else if (!isTutorial)
        {
            for (int i = 0; i < transform.childCount - 1; i++)
            {
                if (i <= 14)
                {
                    transform.GetChild(i).GetComponent<mapBox>().mainSteet = true;
                }
                else if (i > 14)
                {
                    transform.GetChild(i).GetComponent<mapBox>().subSteet = true;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
