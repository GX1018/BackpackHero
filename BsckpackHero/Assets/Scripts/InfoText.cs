using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TMP_Text>().text = $" FLOOR:{1}\tEXPERIENCE: {CharacterManager.Instance.currentExperience} / {CharacterManager.Instance.requiredExperience}";
    }
}
