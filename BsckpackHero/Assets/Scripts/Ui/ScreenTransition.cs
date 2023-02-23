using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScreenTransition : MonoBehaviour
{
    Image upperScreen;
    Color upperScreenColor;
    Image lowerScreen;
    Color lowerScreenColor;


    float time;

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
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (MapManager.Instance.nextFloor == true)
        {
            ScreenTrans();
        }
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
    }
}
