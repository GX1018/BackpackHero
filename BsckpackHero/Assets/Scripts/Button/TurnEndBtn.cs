using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnEndBtn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        BattleManager.Instance.turnEndBtn = this.gameObject;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
