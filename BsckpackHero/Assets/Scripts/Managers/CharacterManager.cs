using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    private static CharacterManager instance;

    public static CharacterManager Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        maxHp = 40;
        currentHp = maxHp;

        level = 1;
        requiredExperience = requiredExperienceArray[0];

    }

    private void Update()
    {
        if (getDmg > 0)
        {
            def -= getDmg;
            getDmg = 0;
            if (def < 0)
            {
                currentHp += def;
                def = 0;
            }
        }

        if(currentHp <= 0)
        {
            Die();
        }

    }

    public int actionPoint = 3;
    public int def = 0;
    public int currentHp;
    public int maxHp;

    public int getDmg;

    public int currentExperience;
    public int requiredExperience;      //5

    public int[] requiredExperienceArray = { 5, 10, 25 };

    public int level;

    public bool isWalk;

    

    public bool isBattleMode = false;

    
    //애니메이터관리
    public Animator animator;

    public Vector3 imgDefaultPos;

    //캐릭터 이동 관련 변수
    public GameObject characterMain;


    public void lvUp()
    {
        if (currentExperience >= requiredExperience)
        {
            currentExperience -= requiredExperience;
            level++;
        }
        requiredExperience = requiredExperienceArray[level - 1];
        InventoryManager.Instance.isLvup =true;
    }

    public void GetDmgCheck()
    {
        if (getDmg > 0)
        {
            def -= getDmg;
            getDmg = 0;
            if (def < 0)
            {
                currentHp += def;
                def = 0;
            }
        }
    }

    public void Die()
    {
        ButtonManager.Instance.RetryBtn.SetActive(true);
    }

}
