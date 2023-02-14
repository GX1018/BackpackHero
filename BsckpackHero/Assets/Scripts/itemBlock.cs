using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemBlock : MonoBehaviour
{
    public bool inInventory = false;
    public bool isClicked = false;
    public bool isTemporary = false;


    // Start is called before the first frame update
    void Start()
    {
        inInventory = false;
        isClicked = false;
        isTemporary = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
