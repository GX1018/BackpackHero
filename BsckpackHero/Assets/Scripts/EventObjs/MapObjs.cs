using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObjs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(MapManager.Instance.findChest == true)
        {
            transform.Find("Chest").gameObject.SetActive(true);
        }
    }
}
