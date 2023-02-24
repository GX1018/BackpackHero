using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemTest : MonoBehaviour, IPointerDownHandler,
    IPointerUpHandler, IDragHandler
{
    public bool isClicked = false;
    public bool isCreated = false;

    public bool imageAdjust = false;

    public int sizeX = 0;
    public int sizeY = 0;

    public int size2D;

    public int isReadyCount = 0;


    public int invenSlotisActiveCnt = 0;
    public int invenSlotisEmptyCnt = 0;

    Vector3 itemOriginPos;


    public string itemProperty = "none";        //none, neutrality, player 3가지 // int 형식으로 바꿔야할지

    public int cost;
    public int atk;
    public int def;

    public List<GameObject> enemyInBattle;

    //클릭시 애니메이션 관련
    public int attackWaypoint = 0;
    public int defenseWaypoint = 0;
    public int useItemWaypoint = 0;
    public int speed = 15;

    public float time = 0;
    //클릭시 애니메이션 관련


    //소모템용
    public int heal;
    public int consumableCount;
    public bool consumable;

    //이미지 변환용
    public bool isImageChange;
    public Sprite itemImage2;
    public int chageTiming;



    private RectTransform objRect = default;
    // Start is called before the first frame update
    void Start()
    {
        isClicked = false;

        objRect = gameObject.GetComponent<RectTransform>();
        size2D = 6;
        //size2D = GameObject.Find("TestCreateItem").GetComponent<TestCreateItem>().size2D;
        isReadyCount = 0;
        invenSlotisActiveCnt = 0;
        invenSlotisEmptyCnt = 0;

        itemProperty = "none";


    }

    // Update is called once per frame
    void Update()
    {
        ////////////조건체크///////////////
        #region conditionCheck
        invenSlotisActiveCnt = 0;

        for (int i = 0; i < transform.childCount - 2; i++)
        {
            if (transform.GetChild(i).GetComponent<itemBlock>().invenSlotisActive == true)
            {
                invenSlotisActiveCnt++;
            }
        }

        invenSlotisEmptyCnt = 0;

        for (int i = 0; i < transform.childCount - 2; i++)
        {
            if (transform.GetChild(i).GetComponent<itemBlock>().invenSlotisEmpty == true)
            {
                invenSlotisEmptyCnt++;
            }
        }
        #endregion
        ////////////조건체크///////////////


        ImageCheck();

        ItemRootCheck();

        //배틀모드이고 행동력이 0일때 아이템의 코스트가 0보다 크면
        if (CharacterManager.Instance.isBattleMode == true && cost > 0)
        {
            //색상 변경
            if (CharacterManager.Instance.actionPoint == 0)
            {
                transform.GetChild(transform.childCount - 1).GetComponent<Image>().color = new Color32(0, 0, 0, 100);
            }
            else if (CharacterManager.Instance.actionPoint > 0)
            {
                transform.GetChild(transform.childCount - 1).GetComponent<Image>().color = new Color32(255, 255, 255, 255);

            }

        }



        //{ 공격할때 움직임

        //시작위치
        Vector3 pos1 = CharacterManager.Instance.imgDefaultPos;

        //공격시 앞으로 이동할 위치
        Vector3 pos2 = new Vector3(pos1.x + 1.17f, pos1.y, pos1.z);

        if (attackWaypoint == 1)
        {
            GameObject.Find("CharacterImg").transform.position = Vector3.MoveTowards(GameObject.Find("CharacterImg").transform.position, pos2, speed * Time.deltaTime);
            if (GameObject.Find("CharacterImg").transform.position == pos2)
            {
                attackWaypoint = 2;
            }
        }
        if (attackWaypoint == 2)
        {
            GameObject.Find("CharacterImg").transform.position = Vector3.MoveTowards(GameObject.Find("CharacterImg").transform.position, pos1, speed * Time.deltaTime);
            if (GameObject.Find("CharacterImg").transform.position == pos1)
            {
                CharacterManager.Instance.animator.SetTrigger("HitEnd");

                attackWaypoint = 0;
            }
        }
        //} 공격할때 움직임


        //방어할때 움직임
        if (defenseWaypoint == 1)
        {
            time += Time.deltaTime;
            if (time >= 0.5f)
            {
                CharacterManager.Instance.animator.SetTrigger("DefenseEnd");
                time = 0;
                defenseWaypoint = 0;
            }
        }
        //방어할때 움직임

        //아이템 사용시 움직임  

        //[itemTest.cs] 캐릭터 애니메이션 관련
        //사용아이템 횟수 0일때  destroy로 설정하여 파괴시 SetTrigger("UseItemEnd") 실행 x 아이템 애니메이션 컨트롤을 다른곳에서 해야할것
        //charactermanager에서 컨트롤 하도록 변경 예정
        /* if (useItemWaypoint == 1)
        {
            time += Time.deltaTime;
            if (time >= 0.5f)
            {
                CharacterManager.Instance.animator.SetTrigger("UseItemEnd");
                useItemWaypoint = 0;
                time = 0;
            }
        } */

    }


    //아이템을 클릭했을때
    public void OnPointerDown(PointerEventData eventData)
    {
        //마우스 왼쪽 버튼 클릭
        if (Input.GetMouseButtonDown(0))
        {
            if (!CharacterManager.Instance.isBattleMode)
            {
                //{ 아이템의 태그 상태가 인벤토리에 들어있는 상태(tag : "GainedItem")면 인벤토리 슬롯의 isempty를 true로 변경
                if (this.tag == "GainedItem")
                {
                    for (int i = 0; i < transform.childCount - 2; i++)
                    {
                        transform.GetChild(i).GetComponent<itemBlock>().nearestSlot.GetComponent<InvenSlot>().isEmpty = true;
                    }
                }
                //} 아이템의 태그 상태가 인벤토리에 들어있는 상태(tag : "GainedItem")면 인벤토리 슬롯의 isempty를 true로 변경

                this.tag = "SelectedItem";

                //아이템 클릭했을때의 위치 저장
                itemOriginPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                                        Input.mousePosition.y, 1));
                //아이템 클릭했을때의 위치 저장

                isClicked = true;
            }

            //배틀모드일때의 행동
            if (CharacterManager.Instance.isBattleMode == true && CharacterManager.Instance.actionPoint >= cost)
            {
                enemyInBattle = BattleManager.Instance.enemyInBattle;
                //아이템의 방어력이 존재하면(type armor로 변경?)
                if (def > 0)
                {
                    CharacterManager.Instance.animator.SetTrigger("Defense");
                    defenseWaypoint = 1;

                    CharacterManager.Instance.def += def;
                }
                if (atk > 0)
                {

                    CharacterManager.Instance.animator.SetTrigger("Hit");
                    attackWaypoint = 1;

                    for (int i = 0; i < enemyInBattle.Count; i++)
                    {
                        if (enemyInBattle[i].GetComponent<Enemy_Script>().isTarget == true)
                        {
                            enemyInBattle[i].GetComponent<Enemy_Script>().getDmg += atk;
                        }
                    }
                }
                if (heal > 0)
                {
                    ItemManager.Instance.useItemWaypoint = 1;
                    CharacterManager.Instance.animator.SetTrigger("UseItem");
                    CharacterManager.Instance.currentHp += heal;
                    if (CharacterManager.Instance.currentHp > CharacterManager.Instance.maxHp)
                    {
                        CharacterManager.Instance.currentHp = CharacterManager.Instance.maxHp;
                    }

                }


                if (consumable)
                {
                    consumableCount--;
                    if (consumableCount == 0)
                    {
                        Destroy(this.gameObject);
                    }
                }

                if (isImageChange)
                {
                    if (consumableCount == chageTiming)
                    {
                        transform.GetChild(transform.childCount - 1).GetComponent<Image>().sprite = itemImage2;
                        transform.GetChild(transform.childCount - 2).GetComponent<Image>().sprite = itemImage2;
                    }
                }

                //최종 : 행동력 감소
                CharacterManager.Instance.actionPoint -= cost;
            }


            //배틀모드일때의 행동

        }

        //마우스 오른쪽 버튼 클릭
        if (Input.GetMouseButtonDown(1))
        {
            if (!CharacterManager.Instance.isBattleMode)
            {
                objRect.rotation = Quaternion.Euler(0, 0, objRect.rotation.eulerAngles.z + 90);
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (Input.GetMouseButtonUp(0))
        {
            this.tag = "Item";

                if (invenSlotisActiveCnt == transform.childCount - 2 && invenSlotisEmptyCnt == transform.childCount - 2)
                {
                    //아이템을 인벤토리에 넣기
                    for (int i = 0; i < transform.childCount - 2; i++)
                    {
                        transform.GetChild(i).GetComponent<itemBlock>().nearestSlot.GetComponent<InvenSlot>().isEmpty = false;
                    }


                    transform.GetChild(transform.childCount - 2).transform.position
                    = transform.GetChild(transform.childCount - 1).transform.position;
                    transform.GetChild(transform.childCount - 2).GetComponent<Image>().color = new Color32(255, 255, 255, 100);

                    transform.position = (transform.GetChild(0).GetComponent<itemBlock>().nearestSlot.transform.position
                        + transform.GetChild(transform.childCount - 3).GetComponent<itemBlock>().nearestSlot.transform.position) / 2;
                    this.tag = "GainedItem";
                    //아이템을 인벤토리에 넣기

                    //아이템 갖는걸 확정할때의(조건 추가요망)

                    itemProperty = "player";
                }
                else if ((invenSlotisActiveCnt != transform.childCount - 2) || (invenSlotisEmptyCnt != transform.childCount - 2))
                {
                    transform.GetChild(transform.childCount - 2).transform.position
                    = transform.GetChild(transform.childCount - 1).transform.position;
                }
            

                InventoryManager.Instance.addItemAvailable = false;

            isClicked = false;

            //////////////

            //클릭을 풀었을때 소유권 상태
            if (itemProperty == "none")
            {
                float ranPosX = Random.Range(-7.5f, 7.5f);
                float ranPosY = Random.Range(-1f, -4.5f);
                transform.position = new Vector3(ranPosX, ranPosY, 100);
            }

            if (itemProperty == "neutrality")
            {
                float ranPosX = Random.Range(-7.5f, 7.5f);
                float ranPosY = Random.Range(1f, 4.5f);
                transform.position = new Vector3(ranPosX, ranPosY, 100);
            }

            if (itemProperty == "player")
            {

            }

            /////////////

        }



    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isClicked == true)
        {
            gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                Input.mousePosition.y, 100));
        }
    }
    //test


    public void ImageCheck()
    {
        if (isClicked == true)
        {

            //드래그 중일때 아이템이 위치의 활성화된 인벤 슬롯이 0개일때
            if (invenSlotisActiveCnt == 0)
            {
                //인벤체크용 이미지의 위치를 기본 위치로 이동 & 색상 초기화
                transform.GetChild(transform.childCount - 2).transform.position
                = transform.GetChild(transform.childCount - 1).transform.position;
                transform.GetChild(transform.childCount - 2).GetComponent<Image>().color = new Color32(255, 255, 255, 100);
            }

            //드래그 중일때 아이템이 위치의 활성화된 인벤 슬롯이 0보다 크고 아이템 블록 수보다 작을때
            if (invenSlotisActiveCnt > 0 && invenSlotisActiveCnt < transform.childCount - 2)
            {
                //인벤 체크용 이미지가 인벤토리 위치로 이동 & 색상 붉은색으로 변경
                transform.GetChild(transform.childCount - 2).transform.position
                = (transform.GetChild(0).GetComponent<itemBlock>().nearestSlot.transform.position
                + transform.GetChild(transform.childCount - 3).GetComponent<itemBlock>().nearestSlot.transform.position) / 2;
                transform.GetChild(transform.childCount - 2).GetComponent<Image>().color = new Color32(255, 0, 0, 100);
            }

            //드래그 중일때 아이템이 위치의 활성화된 인벤 슬롯이 아이템 블록 수와 같을때
            if (invenSlotisActiveCnt == transform.childCount - 2)
            {
                //인벤 슬롯이 모두 비어있으면
                if (invenSlotisEmptyCnt == transform.childCount - 2)
                {
                    //체크용 이미지 초기화
                    transform.GetChild(transform.childCount - 2).transform.position
                    = (transform.GetChild(0).GetComponent<itemBlock>().nearestSlot.transform.position
                    + transform.GetChild(transform.childCount - 3).GetComponent<itemBlock>().nearestSlot.transform.position) / 2;
                    transform.GetChild(transform.childCount - 2).GetComponent<Image>().color = new Color32(255, 255, 255, 100);
                }
                //비어있지 않은 인벤 슬롯이 존재하면
                else
                {
                    //인벤 체크용 이미지가 인벤토리 위치로 이동 & 색상 붉은색으로 변경
                    transform.GetChild(transform.childCount - 2).transform.position
                    = (transform.GetChild(0).GetComponent<itemBlock>().nearestSlot.transform.position
                    + transform.GetChild(transform.childCount - 3).GetComponent<itemBlock>().nearestSlot.transform.position) / 2;
                    transform.GetChild(transform.childCount - 2).GetComponent<Image>().color = new Color32(255, 0, 0, 100);
                }
            }
        }
    }


    public void ItemRootCheck()
    {
        if (InventoryManager.Instance.rootItemCheck == true)
        {
            if (itemProperty == "none")
            {
                if (this.tag == "GainedItem")
                {
                    itemProperty = "player";
                }
            }

            if (itemProperty == "player")
            {
                if (this.tag != "GainedItem")
                {
                    itemProperty = "neutrality";
                }

                if (itemProperty == "neutrality")
                {

                }
            }

        }
        //디폴트 상태일때
        else if (InventoryManager.Instance.rootItemCheck == false)
        {
            if (this.tag != "GainedItem")
            {
                itemProperty = "none";
            }

            if (itemProperty != "player")
            {
                //Destroy(this.gameObject);
            }
        }
    }

}
