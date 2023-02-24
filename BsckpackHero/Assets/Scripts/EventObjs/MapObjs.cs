using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObjs : MonoBehaviour
{
    GameObject chest;
    GameObject door;
    GameObject merchant;



    // Start is called before the first frame update
    void Start()
    {
        chest = transform.Find("Chest").gameObject;
        door = transform.Find("Door_NextFloor").gameObject;
        merchant = transform.Find("Merchant").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (MapManager.Instance.findChest == true)
        {
            chest.SetActive(true);
        }

        if (MapManager.Instance.findDoor == true)
        {
            door.SetActive(true);

        }

        if (MapManager.Instance.inStore == true)
        {
            merchant.SetActive(true);

        }

    }
}
