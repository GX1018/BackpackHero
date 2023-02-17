using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterMain : MonoBehaviour
{
    GameObject changeBtn;
    
    
    // Start is called before the first frame update
    void Start()
    {
        changeBtn =GameObject.Find("changeBtn");

        
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetChild(2).GetComponent<TMP_Text>().text = CharacterManager.Instance.actionPoint.ToString();
        
        if(changeBtn.GetComponent<changeBtn>().isClickInventoryBtn == true)
        {
            this.gameObject.GetComponent<Animator>().SetBool("isInventory", true);
            this.gameObject.GetComponent<Animator>().SetBool("isMap", false);
        }
        else if(changeBtn.GetComponent<changeBtn>().isClickMapBtn == true)
        {
            this.gameObject.GetComponent<Animator>().SetBool("isInventory", false);
            this.gameObject.GetComponent<Animator>().SetBool("isMap", true);
        }
        

        
    }
}
