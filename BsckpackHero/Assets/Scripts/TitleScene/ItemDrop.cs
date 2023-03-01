using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(CreateItemCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CreateItemCoroutine()
    {
        ItemManager.Instance.CreateItem(0);
        yield return new WaitForSeconds(1f);
    }
}
