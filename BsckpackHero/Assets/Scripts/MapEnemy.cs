using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapEnemy : MonoBehaviour
{
    public int enemyNum;
    public string[] enemyName;

    // Start is called before the first frame update
    void Start()
    {
        /* for (int i = 0; i < enemyName.Length; i++)
        {
            MapManager.Instance.CreateEnemy(enemyName[i], enemyList);
        } */
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BattleStart()
    {
        if (MapManager.Instance.createEnd == false)
        {
            for (int i = 0; i < enemyName.Length; i++)
            {
                MapManager.Instance.CreateEnemy(enemyName[i], BattleManager.Instance.enemyInBattle, i);
            }

            MapManager.Instance.createEnd = true;
            //배틀 종료될때 createEnd false로 변경
        }


        for (int i = 0; i < BattleManager.Instance.enemyInBattle.Count; i++)
        {
            
                BattleManager.Instance.enemyInBattle[i].SetActive(true);
        }
    }
}
