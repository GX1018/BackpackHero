using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterMain : MonoBehaviour
{
    GameObject changeBtn;

    Vector3 defaultPos;


    // Start is called before the first frame update
    void Start()
    {
        changeBtn = GameObject.Find("changeBtn");


        defaultPos = transform.position;

        CharacterManager.Instance.characterMain = this.gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        transform.GetChild(1).transform.GetChild(1).GetComponent<TMP_Text>().text = CharacterManager.Instance.actionPoint.ToString();


        //애니메이션 관리
        //기본, 아이템 루팅
        if (changeBtn.GetComponent<changeBtn>().isClickInventoryBtn == true)
        {
            transform.GetChild(0).GetComponent<Animator>().SetBool("isInventory", true);
            transform.GetChild(0).GetComponent<Animator>().SetBool("isMap", false);
        }
        else if (changeBtn.GetComponent<changeBtn>().isClickMapBtn == true)
        {
            transform.GetChild(0).GetComponent<Animator>().SetBool("isInventory", false);
            transform.GetChild(0).GetComponent<Animator>().SetBool("isMap", true);
        }

        //걸을때
        if (CharacterManager.Instance.isWalk == true)
        {
            transform.GetChild(0).GetComponent<Animator>().SetBool("isWalk", true);
            transform.GetChild(0).GetComponent<Animator>().SetBool("isMap", false);
        }
        else if (CharacterManager.Instance.isWalk == false)
        {
            transform.GetChild(0).GetComponent<Animator>().SetBool("isWalk", false);
            transform.GetChild(0).GetComponent<Animator>().SetBool("isMap", true);
        }
        //걸을때


        if (CharacterManager.Instance.isBattleMode == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, defaultPos, 10f * Time.deltaTime);
            transform.GetChild(0).GetComponent<Animator>().SetBool("isBattleMode", true);
            transform.GetChild(0).GetComponent<Animator>().SetBool("isMap", false);
        }
        else if (CharacterManager.Instance.isBattleMode == false)
        {
            transform.GetChild(0).GetComponent<Animator>().SetBool("isBattleMode", false);
            transform.GetChild(0).GetComponent<Animator>().SetBool("isMap", true);
        }

        //애니메이션 관리        }

        //맵에서 이동중 메인 캐릭터 이동//
        if (MapManager.Instance.moveCharacter == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, transform.position.y, transform.position.z), 3f * Time.deltaTime);
        }
        //맵에서 이동중 메인 캐릭터 이동//




        //레벨업
        if (!CharacterManager.Instance.isBattleMode && CharacterManager.Instance.currentExperience >= CharacterManager.Instance.requiredExperience)
        {
            //레벨업 버튼활성화
            ButtonManager.Instance.levelUpBtn.SetActive(true);
        }

        //CharacterManager.Instance.lvUp();


        if (MapManager.Instance.findChest == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, defaultPos, 10f * Time.deltaTime);
        }

        if (MapManager.Instance.nextFloor == true)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDisable() {
        transform.position = defaultPos;
    }
}
