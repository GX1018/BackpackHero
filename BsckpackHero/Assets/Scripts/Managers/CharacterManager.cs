using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public int actionPoint = 3;
    public int def = 0;
    public int currentHp;
    public int maxHp;

    public int currentExperience;
    public int requiredExperience;      //5

    public int[] requiredExperienceArray = { 5, 10, 25 };

    public int level;

    public bool isWalk;

    public void lvUp()
    {
        if (currentExperience >= requiredExperience)
        {
            currentExperience -= requiredExperience;
            level++;
        }
        requiredExperience = requiredExperienceArray[level - 1];
    }

}
