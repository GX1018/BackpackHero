using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvenSlot : MonoBehaviour
{
    public bool isActive = false;
    public bool isTemporary = false;

    // modifying
    public bool isEmpty = true;
    public GameObject filledItem;
    // modifying

    public int xInArray;
    public int yInArray;

    // Start is called before the first frame update
    void Start()
    {

        isEmpty = true;

        if (this.name == "26" || this.name == "27" || this.name == "28" || this.name == "37" || this.name == "38" || this.name == "39"
        || this.name == "48" || this.name == "49" || this.name == "50")
        {
            isActive = true;
        }
        if(isActive)
        {
            InventoryManager.Instance.activeSlot.Add(this.gameObject);
        }


        for (int y = 0; y < InventoryManager.Instance.itemSlot2DArray.GetLength(1); y++)  //7
        {
            for (int x = 0; x < InventoryManager.Instance.itemSlot2DArray.GetLength(0); x++)  //11
            {
                if (InventoryManager.Instance.itemSlot2DArray[x, y] == this.gameObject)
                {
                    xInArray = x;
                    yInArray = y;
                }
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (isActive == true)
        {
            gameObject.GetComponent<Image>().enabled = true;
            gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Inventory/backpackBox");
            gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }

        else if (isTemporary == true && InventoryManager.Instance.lvUpPoint > 0 && isActive == false)
        {
            gameObject.GetComponent<Image>().enabled = true;
            gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Inventory/blankBorder");
            gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        }
        else if (InventoryManager.Instance.lvUpPoint <= 0)
        {
            gameObject.GetComponent<Image>().enabled = false;
        }

        else if (isActive == false && isTemporary == false)
        {
            gameObject.GetComponent<Image>().enabled = false;
        }

        if (InventoryManager.Instance.isLvup == true && InventoryManager.Instance.lvUpPoint == 0)
        {
            ButtonManager.Instance.lvUpDoneBtn.SetActive(true);
        }

        if(InventoryManager.Instance.isLvup == false && (isActive == true || isTemporary == true))
        {
            isTemporary = false;
        }
    }

    private void OnMouseDown()
    {
        if (isTemporary == true && isActive == false)
        {
            isActive = true;
            InventoryManager.Instance.activeSlot.Add(this.gameObject);
            InventoryManager.Instance.lvUpPoint--;
        }

        else if (isTemporary == true && isActive == true)
        {
            isActive = false;
            InventoryManager.Instance.activeSlot.Remove(this.gameObject);
            InventoryManager.Instance.lvUpPoint++;

        }
    }

}
