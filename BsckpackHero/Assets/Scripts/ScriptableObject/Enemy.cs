using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "Enemy Data", menuName = "Scriptable Object/Enemy Data", order = int.MaxValue-1)]
public class Enemy : ScriptableObject
{
    [SerializeField]
    private string enemyName;
    public string EnemyName{get{return enemyName;}}

    [SerializeField]
    private Sprite enemyImage;
    public Sprite EnemyImage{get{return enemyImage;}}

    [SerializeField]
    private int enemyHp;
    public int EnemyHp{get{return enemyHp;}}
    
    [SerializeField]
    private int enemyMinAtk;
    public int EnemyMinAtk{get{return enemyMinAtk;}}
    
    [SerializeField]
    private int enemyMaxAtk;
    public int EnemyMaxAtk{get{return enemyMaxAtk;}}
    
    [SerializeField]
    private int enemyDef;
    public int EnemyDef{get{return enemyDef;}}
    
    [SerializeField]
    private int enemyXp;
    public int EnemyXp{get{return enemyXp;}}
}
