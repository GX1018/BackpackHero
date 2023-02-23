using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapBoxies : MonoBehaviour
{
    public GameObject boxPrefab;
    GameObject[,] mapBox2DArray;

    GameObject startPos;
    GameObject endPos;

    public int startPosY;
    public int endPosY;

    public GameObject nextFloorPrefab;

    // Start is called before the first frame update
    void Start()
    {
        mapBox2DArray = MapManager.Instance.mapBox2DArray;
        boxPrefab = Resources.Load<GameObject>("Prefabs/MapBox");
        nextFloorPrefab = Resources.Load<GameObject>("Prefabs/NextFloor");

        int count = 0;
        for (int y = 0; y < mapBox2DArray.GetLength(1); y++)  //7
        {
            for (int x = 0; x < mapBox2DArray.GetLength(0); x++)  //11
            {
                GameObject mapBox = Instantiate(boxPrefab, gameObject.transform);
                mapBox.name = "map_" + count.ToString();
                mapBox2DArray[x, y] = mapBox;
                count++;
            }
        }

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<Image>().enabled = false;
            transform.GetChild(i).GetComponent<mapBox>().isActive = false;
        }

        startPosY = Random.Range(0,5);
        endPosY = Random.Range(0,5);

        startPos = mapBox2DArray[10, startPosY];
        endPos = mapBox2DArray[0, endPosY];
        
        GameObject nextFloor = Instantiate(nextFloorPrefab, endPos.transform);

        startPos.GetComponent<mapBox>().isActive = true;
        startPos.GetComponent<Image>().enabled = true;

        endPos.GetComponent<mapBox>().isActive = true;
        endPos.GetComponent<Image>().enabled = true;

        




    }

    // Update is called once per frame
    void Update()
    {

    }
}
