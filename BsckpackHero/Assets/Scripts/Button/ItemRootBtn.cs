using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemRootBtn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }



    public void OnPointerDown(PointerEventData eventData)
    {
        InventoryManager.Instance.removeItem = true;

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        InventoryManager.Instance.removeItem = false;
        gameObject.SetActive(false);

    }
}
