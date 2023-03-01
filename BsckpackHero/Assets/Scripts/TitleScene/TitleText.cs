using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleText : MonoBehaviour
{
    public bool isTitleTextMove = false;
    // Start is called before the first frame update
    void Start()
    {
        isTitleTextMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("TitleScreen").GetComponent<TitleScreen>().titleClick ==true)
        {
            transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("TitleTextTarget").transform.position, 1f * Time.deltaTime);
        }
        if(transform.position == GameObject.Find("TitleTextTarget").transform.position)
        {
            isTitleTextMove = true;
            //Debug.Log(isTitleTextMove);
        }
    }
}
