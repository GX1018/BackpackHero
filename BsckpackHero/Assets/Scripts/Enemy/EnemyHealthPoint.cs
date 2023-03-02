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
    public float regen;
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
        regen = transform.parent.gameObject.GetComponent<Enemy_Script>().regen;

        transform.GetChild(2).GetComponent<TMP_Text>().text = $"{currentHp}/{maxHp}";
        transform.GetChild(1).GetComponent<Image>().fillAmount = currentHp / maxHp;


        if (transform.parent.GetComponent<Enemy_Script>().def <= 0)
        {
            transform.GetChild(3).GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Character/heart");
            transform.GetChild(4).GetComponent<TMP_Text>().text = "";
        }
        if (transform.parent.GetComponent<Enemy_Script>().def > 0)
        {
            transform.GetChild(3).GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Character/block");
            transform.GetChild(4).GetComponent<TMP_Text>().text = $"{def}";
        }

        if (transform.parent.GetComponent<Enemy_Script>().regen > 0)
        {
            transform.GetChild(5).gameObject.SetActive(true);
            transform.GetChild(5).GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Character/regen");
            transform.GetChild(5).GetChild(0).GetComponent<TMP_Text>().text = $"{regen}";
        }
        if (transform.parent.GetComponent<Enemy_Script>().regen <= 0)
        {
            transform.GetChild(5).gameObject.SetActive(false);
        }
    }

}
