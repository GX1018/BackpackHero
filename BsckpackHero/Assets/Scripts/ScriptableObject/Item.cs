using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "Item Data", menuName = "Scriptable Object/Item Data", order = int.MaxValue)]

public class Item : ScriptableObject
{
    [SerializeField]
    private string itemName;
    public string ItemName{get{return itemName;}}

    [SerializeField]
    private Sprite itemImage1;
    public Sprite ItemImage1{get{return itemImage1;}}

    [SerializeField]
    private int sizeX;
    public int SizeX{get{return sizeX;}}

    [SerializeField]
    private int sizeY;
    public int SizeY{get{return sizeY;}}
    
    [SerializeField]
    private int cost;
    public int Cost{get{return cost;}}

    [SerializeField]
    private int atk;
    public int Atk{get{return atk;}}

    [SerializeField]
    private int def;
    public int Def{get{return def;}}
    // } 기본
    

    
    [SerializeField]
    private int heal;
    public int Heal{get{return heal;}}

    [SerializeField]
    private bool consumable;
    public bool Consumable{get{return consumable;}}

    [SerializeField]
    private int consumableCount;
    public int ConsumableCount{get{return consumableCount;}}

    

    //이미지가 변하는 경우
    [SerializeField]
    private bool isImageChange;
    public bool IsImageChange{get{return isImageChange;}}

    [SerializeField]
    private Sprite itemImage2;
    public Sprite ItemImage2{get{return itemImage2;}}

    [SerializeField]
    private int chageTiming;
    public int ChageTiming{get{return chageTiming;}}
    
    //이미지가 변하는 경우



    

    

    

    
    
    
}
