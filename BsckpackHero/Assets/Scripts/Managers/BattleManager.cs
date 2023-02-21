using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : GSingleton<BattleManager>
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerTurn == true && CharacterManager.Instance.isBattleMode == true)
        {
            turnEndBtn.SetActive(true);
        }
        else
        {
            turnEndBtn.SetActive(false);
        }

        if (isPlayerTurn == false)
        {

            for (int i = 0; i < enemyInBattle.Count; i++)
            {
                enemyInBattle[i].GetComponent<Enemy_Script>().def = 0;
                enemyInBattle[i].GetComponent<Enemy_Script>().Action();
            }
            turnCount++;
            CharacterManager.Instance.def = 0;
            CharacterManager.Instance.actionPoint = 3;
            isPlayerTurn = true;
        }



    }

    public List<GameObject> enemyInBattle;

    public GameObject turnEndBtn;
    public bool isPlayerTurn = true;

    public int turnCount = 1;

    public void TurnEnd()
    {
        if (isPlayerTurn == true)
        {
            isPlayerTurn = false;
        }
    }
}
