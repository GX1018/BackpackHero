using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : GSingleton<BattleManager>
{
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.Find("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerTurn == true && CharacterManager.Instance.isBattleMode == true)
        {
            turnEndBtn.SetActive(true);

            int targetCheck = 0;
            //targetCheck
            for (int i = 0; i < enemyInBattle.Count; i++)
            {
                if (enemyInBattle[i].GetComponent<Enemy_Script>().isTarget == true)
                {
                    targetCheck++;
                    isTargetExists = true;
                }
            }
            if (targetCheck == 0)
            {
                isTargetExists = false;
            }
            if (enemyInBattle.Count > 0 && !isTargetExists)
            {
                enemyInBattle[enemyInBattle.Count - 1].GetComponent<Enemy_Script>().isTarget = true;
            }

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

    //타겟 확인용 변수
    public bool isTargetExists = false;

    public bool isPlayerTurn = true;

    public int turnCount = 1;

    public bool isWin;

    public GameObject enemy;

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
            if (enemyInBattle[i].GetComponent<Enemy_Script>().regen > 0)
            {
                enemyInBattle[i].GetComponent<Enemy_Script>().hp += enemyInBattle[i].GetComponent<Enemy_Script>().regen;
                enemyInBattle[i].GetComponent<Enemy_Script>().regen--;
            }
            enemyInBattle[i].GetComponent<Enemy_Script>().def = 0;
            enemyInBattle[i].GetComponent<Enemy_Script>().Action();
            CharacterManager.Instance.GetDmgCheck();
            //
            yield return new WaitForSeconds(1f);
            enemyActionCnt++;
        }



    }
}
