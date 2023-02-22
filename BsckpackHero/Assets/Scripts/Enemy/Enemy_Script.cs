using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Enemy_Script : MonoBehaviour, IPointerDownHandler
{
    public int hp;
    public int maxHp;

    public int minAtk;
    public int maxAtk;

    public int atk;

    public int def;
    public int addDef;
    public int xp;

    public int getDmg;


    //공격, 방어 이외의 행동 있는 경우 사용
    public int actionTypeNum;
    public int actionType;
    //공격, 방어 이외의 행동 있는 경우 사용


    public bool isTarget = false;


    //헹동시 움직임 관련
    private int attMove = 0;
    private int dffMove = 0;

    Vector3 originSize;
    Vector3 targetSize;



    Vector3 pos1;
    Vector3 pos2;


    float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
        atk = Random.Range(minAtk, maxAtk);

        pos1 = transform.GetChild(0).transform.position;
        pos2 = new Vector3(pos1.x - 1f, -2.78f, 100);

        originSize = new Vector3(1,1,1);
        targetSize = new Vector3(1,2,1);

    }

    // Update is called once per frame
    void Update()
    {
        if (isTarget == true)
        {
            transform.GetChild(1).gameObject.SetActive(true);
        }
        else if (isTarget == false)
        {
            transform.GetChild(1).gameObject.SetActive(false);
        }

        if (getDmg > 0)
        {
            def -= getDmg;
            getDmg = 0;
            if (def < 0)
            {
                hp += def;
                def = 0;
            }


        }

        if (hp <= 0)
        {
            CharacterManager.Instance.currentExperience += xp;
            for (int i = 0; i < BattleManager.Instance.enemyInBattle.Count; i++)
            {
                if (BattleManager.Instance.enemyInBattle[i] == this.gameObject)
                {
                    BattleManager.Instance.enemyInBattle.Remove(BattleManager.Instance.enemyInBattle[i]);
                }
            }
            Destroy(this.gameObject);
        }

        ActionPreview();



        //공격할때 움직임
        if (attMove == 1)
        {
            transform.GetChild(0).transform.position = Vector3.MoveTowards(transform.GetChild(0).transform.position, pos2, 10 * Time.deltaTime);
            if (transform.GetChild(0).transform.position == pos2)
            {
                attMove = 2;
            }
        }
        if (attMove == 2)
        {
            transform.GetChild(0).transform.position = Vector3.MoveTowards(transform.GetChild(0).transform.position, pos1, 10 * Time.deltaTime);
            if (transform.GetChild(0).transform.position == pos1)
            {
                attMove = 0;
            }
        }
        //공격할때 움직임

        //방어할때 움직임


        if (dffMove == 1)
        {
            time += Time.deltaTime;
            transform.GetChild(0).localScale = new Vector3(1, 1 + 1f * time, 1);
            Debug.Log(transform.GetChild(0).localScale.y);
            if (transform.GetChild(0).localScale.y>=1.3)
            {
                time = 0;
                dffMove = 2;
            }
        }
        if (dffMove == 2)
        {
            time += Time.deltaTime;
            transform.GetChild(0).localScale = new Vector3(1, 1.3f - 1f * time, 1);
            if (transform.GetChild(0).localScale.y<=1)
            {
                time = 0;
                dffMove = 0;
            }
        }
        //방어할때 움직임

    }



    public void OnPointerDown(PointerEventData eventData)
    {
        for (int i = 0; i < transform.parent.childCount; i++)
        {
            transform.parent.GetChild(i).gameObject.GetComponent<Enemy_Script>().isTarget = false;
        }
        isTarget = true;
    }

    public void ActionPreview()
    {
        if (BattleManager.Instance.turnCount % 2 == 1)
        {

            transform.GetChild(3).GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Enemy/attack");
            transform.GetChild(3).GetChild(1).GetComponent<TMP_Text>().text = atk.ToString();
        }
        else if (BattleManager.Instance.turnCount % 2 == 0)
        {
            transform.GetChild(3).GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Enemy/defense");
            transform.GetChild(3).GetChild(1).GetComponent<TMP_Text>().text = addDef.ToString();
        }
    }

    public void Action()
    {
        //enemy turn에 실행될 함수


        if (BattleManager.Instance.turnCount % 2 == 1)
        {
            attMove = 1;
            CharacterManager.Instance.getDmg += atk;
        }
        else if (BattleManager.Instance.turnCount % 2 == 0)
        {
            dffMove = 1;
            def += addDef;
        }
    }

}
