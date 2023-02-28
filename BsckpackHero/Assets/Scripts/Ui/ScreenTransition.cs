using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScreenTransition : MonoBehaviour
{
    Image upperScreen;
    Color upperScreenColor;
    Image lowerScreen;
    Color lowerScreenColor;


    float time;

    //text move var
    Vector3 text1DefaultPoint;
    Vector3 text2DefaultPoint;

    Vector3 text1StartPoint;
    Vector3 text2StartPoint;



    //text move var


    // Start is called before the first frame update
    void Start()
    {
        MapManager.Instance.screenTrans = this.gameObject;

        upperScreen = transform.GetChild(0).GetComponent<Image>();
        upperScreen.color = new Color(0, 0, 0, 0);
        upperScreenColor = upperScreen.color;
        lowerScreen = transform.GetChild(1).GetComponent<Image>();
        lowerScreen.color = new Color(0, 0, 0, 0);
        lowerScreenColor = lowerScreen.color;

        time = 0;

        //temp

        text1DefaultPoint = transform.GetChild(2).position;
        text2DefaultPoint = transform.GetChild(3).position;

        text1StartPoint = new Vector3(text1DefaultPoint.x - 6, text1DefaultPoint.y, text1DefaultPoint.z);
        text2StartPoint = new Vector3(text2DefaultPoint.x + 14, text2DefaultPoint.y, text2DefaultPoint.z);

        transform.GetChild(2).position = text1StartPoint;
        transform.GetChild(3).position = text2StartPoint;

        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (MapManager.Instance.nextFloor == true)
        {
            ScreenTrans();
        }

        /* transform.GetChild(2).position = Vector3.MoveTowards(transform.GetChild(2).position, text1DefaultPoint, 5f*Time.deltaTime);
        transform.GetChild(3).position = Vector3.MoveTowards(transform.GetChild(3).position, text2DefaultPoint, 10f*Time.deltaTime); */


    }

    public void ScreenTrans()
    {
        transform.parent.GetComponent<Canvas>().sortingOrder = 99;

        time += Time.deltaTime;
        upperScreen.fillAmount = 0.5f * time;
        upperScreenColor.a = 0.5f * time;
        upperScreen.color = upperScreenColor;


        lowerScreen.fillAmount = 0.5f * time;
        lowerScreenColor.a = 0.5f * time;
        lowerScreen.color = lowerScreenColor;

        Debug.Log(time);
        if (time > 5)
        {
            transform.parent.GetComponent<Canvas>().sortingOrder = 0;

            MapManager.Instance.nextFloor = false;
            this.gameObject.SetActive(false);
            CharacterManager.Instance.characterMain.SetActive(true);

        }

        transform.GetChild(2).position = Vector3.MoveTowards(transform.GetChild(2).position, text1DefaultPoint, 5f * Time.deltaTime);
        transform.GetChild(3).position = Vector3.MoveTowards(transform.GetChild(3).position, text2DefaultPoint, 10f * Time.deltaTime);
    }
}
