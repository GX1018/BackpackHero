using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialText : MonoBehaviour
{
    string text;
    int tutorialStep = 0;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>().text;
    }

    // Update is called once per frame
    void Update()
    {
        if (MapManager.Instance.isTutorial && tutorialStep == 0 && MapManager.Instance.playerPos == 0)
        {

            gameObject.GetComponent<TMP_Text>().enabled = true;
            transform.position = new Vector3(0.1f, 2.65f, 100);
            GetComponent<TMP_Text>().text = "Click";
            GetComponent<TMP_Text>().fontSize = 36;
            if (Input.GetMouseButtonDown(0))
            {
                tutorialStep++;
                gameObject.GetComponent<TMP_Text>().enabled = false;
            }
        }

        if (MapManager.Instance.isTutorial && MapManager.Instance.playerPos == 5)
        {
            if (tutorialStep == 1)
            {
                gameObject.GetComponent<TMP_Text>().enabled = true;
                transform.position = new Vector3(5f, -1.9f, 100);
                GetComponent<TMP_Text>().fontSize = 50;
                GetComponent<TMP_Text>().text = "Click";
                if (Input.GetMouseButtonDown(0))
                {
                    tutorialStep++;
                    gameObject.GetComponent<TMP_Text>().enabled = false;
                }
            }
            if (tutorialStep == 2)
            {
                gameObject.GetComponent<TMP_Text>().enabled = true;
                GetComponent<TMP_Text>().text = "Drag Item Into\n the Inventory";
                if (MapManager.Instance.tutorialStepCheck)
                {
                    tutorialStep++;
                    Debug.Log(tutorialStep);
                    gameObject.GetComponent<TMP_Text>().enabled = false;
                }
            }
        }

        if (tutorialStep == 3)
        {
            gameObject.GetComponent<TMP_Text>().enabled = true;
            transform.position = new Vector3(1.5f, 2.65f, 100);
            GetComponent<TMP_Text>().text = "Click";
            GetComponent<TMP_Text>().fontSize = 36;
            if (MapManager.Instance.playerPos == 7)
            {
                tutorialStep++;
                gameObject.GetComponent<TMP_Text>().enabled = false;
            }
        }
        if (tutorialStep == 4)
        {
            gameObject.GetComponent<TMP_Text>().enabled = true;
            GetComponent<TMP_Text>().fontSize = 50;
            transform.position = new Vector3(-5.6f, 2.65f, 100);
            GetComponent<TMP_Text>().text = "Click Sword Item,\nAttack the enemy";
            if (Input.GetMouseButtonUp(0))
            {
                tutorialStep++;
            }
        }
        if (tutorialStep == 5)
        {
            GetComponent<TMP_Text>().text = "Click Shild Item,\nDefense \nfrom enemy attack";
            if (Input.GetMouseButtonDown(0))
            {
                tutorialStep++;
            }
        }
        if (tutorialStep == 6)
        {
            GetComponent<TMP_Text>().text = "Click Meal Item,\nRestore\n your HP";
            if (InventoryManager.Instance.isLvup)
            {
                tutorialStep++;
            }
        }
        if (tutorialStep == 7)
        {
            transform.position = new Vector3(5.8f, -1.65f, 100);
            GetComponent<TMP_Text>().text = "Click the Box, \nExpand Inventory";
            if (!MapManager.Instance.tutorialStepCheck)
            {
                tutorialStep++;
                gameObject.GetComponent<TMP_Text>().enabled = false;
            }
        }

        if (MapManager.Instance.playerPos == 11)
        {
            gameObject.GetComponent<TMP_Text>().enabled = true;
            transform.position = new Vector3(5.8f, 0.18f, 100);

            GetComponent<TMP_Text>().text = "Click the Gate, Go to the\nNext Floor";
        }
        if(MapManager.Instance.isTutorial == false)
        {
            gameObject.GetComponent<TMP_Text>().enabled = false;
        }
    }
}
