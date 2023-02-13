using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapBox : MonoBehaviour
{
    public bool isFilled = false;
    public int currentPos = 0;
    public int thisPos = 0;
    string[] split_name;
    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.name == "Tutorial1")
        {
            isFilled = true;
        }
        else
        {
            isFilled = false;
        }

        split_name = this.name.Split('_');
        thisPos = int.Parse(split_name[1]);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(isFilled);
    }

    private void OnCollisionStay2D(Collision2D other) {
        if(other.gameObject.tag == "player")
        {
            isFilled = true;
            Debug.Log(isFilled);
        }
    }

    private void OnMouseDown() {
        
        if(isFilled == true)
        {
            /*Do Nothing*/
        }
        else if(isFilled == false)
        {
            //현재 플레이어 위치 확인
            for(int i = 1; i<13; i++)
            {
                if(GameObject.Find($"Tutorial{i}").GetComponent<mapBox>().isFilled ==true)
                {
                    currentPos = i;
                    break;
                }
            }
            //현재 플레이어 위치 확인

            for(int i = currentPos; i< thisPos; i++)
            {
                if(GameObject.Find($"Tutorial{i}").GetComponent<mapBox>().isFilled ==true)
                {
                    break;
                }
            }

            //미완
        }
    }
}
