using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameBtn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("UiObjs").transform.GetChild(1).GetComponent<ScreenTransition>().ScreenTrans();
    }

    public void StartGameBtnClick(){
        GameObject.Find("UiObjs").transform.GetChild(1).gameObject.SetActive(true);
        StartCoroutine(WaitNextScene());
    }

    IEnumerator WaitNextScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("97.TestScene");
        MapManager.Instance.gameStart = true;
    }
}
