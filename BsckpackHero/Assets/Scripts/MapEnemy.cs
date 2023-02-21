using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapEnemy : MonoBehaviour
{
    public int enemyNum;
    public string[] enemyName;
    public List<GameObject> enemyList;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < enemyName.Length; i++)
        {
            MapManager.Instance.CreateEnemy(enemyName[i], enemyList);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BattleStart()
    {
        for(int i = 0; i < enemyName.Length; i++)
        {
            enemyList[i].SetActive(true);
        }
    }
}
