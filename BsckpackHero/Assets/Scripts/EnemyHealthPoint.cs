using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyHealthPoint : MonoBehaviour
{
    public float currentHp;
    public float maxHp;
    public float def;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentHp = transform.parent.gameObject.GetComponent<Enemy_Script>().hp;
        maxHp = transform.parent.gameObject.GetComponent<Enemy_Script>().maxHp;
        def = transform.parent.gameObject.GetComponent<Enemy_Script>().def;

        transform.GetChild(2).GetComponent<TMP_Text>().text = $"{currentHp}/{maxHp}";
        transform.GetChild(1).GetComponent<Image>().fillAmount = currentHp / maxHp;


        if (CharacterManager.Instance.def <= 0)
        {
            transform.GetChild(3).GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Character/heart");
            transform.GetChild(4).GetComponent<TMP_Text>().text = "";
        }
        if (CharacterManager.Instance.def > 0)
        {
            transform.GetChild(3).GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Character/block");
            transform.GetChild(4).GetComponent<TMP_Text>().text = $"{def}";

        }
    }

}
