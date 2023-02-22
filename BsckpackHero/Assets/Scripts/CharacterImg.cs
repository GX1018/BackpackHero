using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterImg : MonoBehaviour
{
    
    Animator animator;
    RectTransform rect;
    Vector2 defaultPos;
    // Start is called before the first frame update
    void Start()
    {
        rect = gameObject.GetComponent<RectTransform>();
        defaultPos = rect.anchoredPosition;
        CharacterManager.Instance.animator = animator;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
