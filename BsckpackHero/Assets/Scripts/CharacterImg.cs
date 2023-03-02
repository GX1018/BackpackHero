using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterImg : MonoBehaviour
{

    Animator animator;
    RectTransform rect;
    Vector2 defaultPos;

    //
    float time;
    Image characterImg;
    Color characterImgColor;
    // Start is called before the first frame update
    void Start()
    {
        rect = gameObject.GetComponent<RectTransform>();
        defaultPos = rect.anchoredPosition;
        animator = GetComponent<Animator>();
        CharacterManager.Instance.animator = animator;
        CharacterManager.Instance.imgDefaultPos = transform.position;
        time = 0;
        characterImg = GetComponent<Image>();
        characterImg.color = new Color(1, 1, 1, 1);
        characterImgColor = characterImg.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (MapManager.Instance.nextFloor)
        {
            time += Time.deltaTime;
            characterImgColor.a = 1-10f * time;
            Debug.Log(characterImgColor.a);
            characterImg.color = characterImgColor;
            if (characterImg.color.a < 0)
            {
                transform.parent.gameObject.SetActive(false);
                time = 0;
            }
        }
        else
        {
            characterImg.color = new Color(1, 1, 1, 1);
        }

    }
}
