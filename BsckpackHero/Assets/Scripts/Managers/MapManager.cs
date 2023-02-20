using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : GSingleton<MapManager>
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject nearestMapBox;
    public int playerPos;
    public int targetPos;

    public bool moveCharacter = false;
}
