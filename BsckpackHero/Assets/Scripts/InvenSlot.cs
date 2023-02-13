using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvenSlot : MonoBehaviour
{
    public bool isActive = false;
    public bool isTemporary = false;
    // Start is called before the first frame update
    void Start()
    {
        if (this.name == "12"||this.name=="13"||this.name=="14"||this.name=="21"||this.name=="22"||this.name=="23"
        ||this.name=="30"||this.name=="31"||this.name=="32")
        {
            isActive = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isActive ==true)
        {
            gameObject.GetComponent<Image>().enabled =true;
        }
        
        else if(isTemporary ==true&&gameObject.transform.parent.gameObject.GetComponent<Inventory>().lvUpPoint>0)
        {
            gameObject.GetComponent<Image>().enabled = true;
            gameObject.GetComponent<Image>().color = new Color(1,1,1,0.5f);
        }
        else if(gameObject.transform.parent.gameObject.GetComponent<Inventory>().lvUpPoint<=0)
        {
            gameObject.GetComponent<Image>().enabled = false;
            isTemporary =false;
        }
        
        else if(isActive == false && isTemporary ==false)
        {
            gameObject.GetComponent<Image>().enabled = false;
            //gameObject.GetComponent<BoxCollider2D>().enabled =false;
        }
    }

    private void OnMouseDown() {
        Debug.Log(this.name);
        if(isTemporary == true)
        {
            isActive = true;
            gameObject.GetComponent<Image>().color = new Color(1,1,1,1);
            transform.parent.gameObject.GetComponent<Inventory>().lvUpPoint --;
            isTemporary = false;
        }
    }


}
