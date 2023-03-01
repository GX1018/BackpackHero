using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    public bool titleClick = false;
    

    
    // Start is called before the first frame update
    void Start()
    {
        titleClick = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("TitleText").GetComponent<TitleText>().isTitleTextMove == true)
        {
            transform.Find("TitleButton").gameObject.SetActive(true);
        }
    }

    private void OnMouseDown() {
        if(titleClick == false)
        {
            titleClick = true;
        }
    }
}
