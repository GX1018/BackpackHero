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
            if (enemyActionCnt == enemyInBattle.Count)
            {
                turnCount++;

                CharacterManager.Instance.actionPoint = 3;

                if (CharacterManager.Instance.def > 0)
                {

                    CharacterManager.Instance.def = 0;
                }

                isPlayerTurn = true;
                enemyActionFin = false;

                enemyActionCnt = 0;
            }
        }



    }

    public List<GameObject> enemyInBattle;

    public bool isPlayerTurn = true;

    public int turnCount = 1;

    //버튼
    public GameObject turnEndBtn;
    public void TurnEnd()
    {
        if (isPlayerTurn == true)
        {
            StartCoroutine(EnemyDelay());
            isPlayerTurn = false;
        }
    }
    //버튼


    public bool enemyActionFin = false;


    public int enemyActionCnt = 0;
    IEnumerator EnemyDelay()
    {

        for (int i = 0; i < enemyInBattle.Count; i++)
        {
            //
            enemyInBattle[i].GetComponent<Enemy_Script>().def = 0;
            enemyInBattle[i].GetComponent<Enemy_Script>().Action();
            CharacterManager.Instance.GetDmgCheck();
            //
            yield return new WaitForSeconds(1f);
            enemyActionCnt++;
        }



    }
}
