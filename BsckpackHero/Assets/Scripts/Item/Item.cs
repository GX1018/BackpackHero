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
    private Sprite itemImage;
    public Sprite ItemImage{get{return itemImage;}}

    [SerializeField]
    private int sizeX;
    public int SizeX{get{return sizeX;}}

    [SerializeField]
    private int sizeY;
    public int SizeY{get{return sizeY;}}

    

    
    
    
}
