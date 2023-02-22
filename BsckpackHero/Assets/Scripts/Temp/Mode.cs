using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Mode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (InventoryManager.Instance.rootItemCheck == true)
        {
            GetComponent<TMP_Text>().text = "Debug Mode :\nItem Rooting";
        }

        if (InventoryManager.Instance.rootItemCheck == false)
        {
            if (CharacterManager.Instance.isBattleMode == false)
            {
                GetComponent<TMP_Text>().text = "Debug Mode :\nDefault";
            }
            else 
            {
                GetComponent<TMP_Text>().text = $"Debug Mode :\nBattle \n turn : {BattleManager.Instance.turnCount}";
            }
        }
    }
}
