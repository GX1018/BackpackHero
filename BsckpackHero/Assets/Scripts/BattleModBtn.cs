using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModBtn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BattleMode()
    {
        if (InventoryManager.Instance.isBattleMode == false)
        {
            InventoryManager.Instance.isBattleMode = true;
        }
        else
        {
            InventoryManager.Instance.isBattleMode = false;
        }
    }
}
