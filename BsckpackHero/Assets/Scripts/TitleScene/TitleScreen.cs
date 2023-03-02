using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    public bool titleClick = false;
    GameObject titleButton;
    GameObject itemDrop;
    GameObject characterTitle;

    Vector3 bgDefaultPos;
    Vector3 bgMoveTargetPos;
    

    
    // Start is called before the first frame update
    void Start()
    {
        titleButton = transform.Find("TitleButton").gameObject;
        itemDrop = transform.Find("ItemDrop").gameObject;
        characterTitle = transform.Find("CharacterTitle").gameObject;
        titleClick = false;

        bgDefaultPos = transform.GetChild(0).transform.position;
        bgMoveTargetPos = new Vector3(bgDefaultPos.x-18, bgDefaultPos.y, bgDefaultPos.z);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(titleClick)
        {
            transform.GetChild(0).transform.position = Vector3.MoveTowards(transform.GetChild(0).transform.position, bgMoveTargetPos, 8f*Time.deltaTime);
        }
        
        if(GameObject.Find("TitleText").GetComponent<TitleText>().isTitleTextMove == true)
        {
            titleButton.SetActive(true);
            itemDrop.SetActive(true);
            characterTitle.SetActive(true);
        }
    }

    private void OnMouseDown() {
        if(titleClick == false)
        {
            titleClick = true;
        }
    }
}
