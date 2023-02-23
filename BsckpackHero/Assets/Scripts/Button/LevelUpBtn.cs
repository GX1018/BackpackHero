using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LevelUpBtn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Start is called before the first frame update
    void Start()
    {
        ButtonManager.Instance.LevelUpBtn = this.gameObject;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }



    public void OnPointerDown(PointerEventData eventData)
    {
        CharacterManager.Instance.lvUp();
        InventoryManager.Instance.moveCheckInt = 1;

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        gameObject.SetActive(false);

    }
}
