using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapManager : GSingleton<MapManager>
{
    public bool gameStart;

    //다음층 이동 관련 변수
    public GameObject screenTrans;

    public bool isTutorial;
    public bool tutorialStepCheck = false;
    GameObject tutorialMap;
    GameObject stageMap;


    public GameObject MapRoot;



    //맵에서 이벤트 체크용
    public bool nextFloor = false;
    public bool inStore = false;

    public bool clearGame = false;


    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
        if (gameStart)
        {
            tutorialMap = GameObject.Find("Map").transform.GetChild(1).gameObject;
            stageMap = GameObject.Find("Map").transform.GetChild(2).gameObject;
            tutorialMap.SetActive(true);
            gameStart = false;
        }

        if (isTutorial)
        {
            if (nextFloor)
            {
                isTutorial = false;
                findDoor = false;
                tutorialMap.SetActive(false);
                stage++;
                floor++;
                MapRoot.transform.GetChild(2).gameObject.SetActive(true);
                MapRoot.transform.GetChild(2).GetChild(stage - 1).GetChild(floor - 1).gameObject.SetActive(true);
                targetPos = 0;
                playerPos = 0;
                nextFloor = false;
            }
        }

        if (stage == 1 && floor == 1)
        {
            if (playerPos == 14 && BattleManager.Instance.isWin)
            {
                stage ++;
                floor ++;
                nextFloor = true;
                clearGame = true;
            }
        }

        if (clearGame)
        {
            screenTrans.SetActive(true);
            StartCoroutine(WaitNextScene());
        }
        // if (nextFloor == true)
        // {
        //     if (isTutorial == true)
        //     {

        //         
        //     }

        //     else if (!isTutorial)
        //     {
        //         //지우고
        //         for (int i = 0; i < stageMap.transform.childCount; i++)
        //         {
        //             Destroy(MapRoot.transform.GetChild(2).GetChild(stage - 1).GetChild(floor - 1).gameObject);
        //             //stage++;
        //             //floor++;
        //             // MapRoot.transform.GetChild(2).GetChild(stage - 1).GetChild(floor - 1).gameObject.SetActive(true);
        //             // findDoor = false;    //일단 비활성화

        //         }
        //     
        //         //만들어줌(함수 생성 후 삽입예정)
        //     }
        // }
    }

    public void QuitBtnClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
    }

    IEnumerator WaitNextScene()
    {
        yield return new WaitForSeconds(3);
        QuitBtnClick();
        MapManager.Instance.gameStart = false;
    }

    public GameObject nearestMapBox;
    public int playerPos;
    public int targetPos;
    //갈림길 이동 관련 변수
    public int thisCrossroad;
    public int thisSub_1;
    public int thisSubEnd;
    //
    public bool moveCharacter = false;

    public bool findChest = false;
    public bool openChest = false;



    //맵에서 계단에 도작했을때
    public bool findDoor = false;

    public int stage = 0;
    public int floor = 0;


    //적 생성 관련 변수//enemymanager?
    Enemy enemy;
    GameObject enemyPrefab;


    public int maxHp;

    public int minAtk;
    public int maxAtk;
    public int addDef;
    public int addRegen;
    public int xp;
    public bool createEnd = false;

    //적 생성 관련 변수


    public GameObject[,] mapBox2DArray = new GameObject[11, 6];

    public void CreateEnemy(string enemyName, List<GameObject> enemyList, int xPos)
    {
        enemy = Resources.Load<Enemy>($"Enemies/{enemyName}");

        enemyPrefab = Resources.Load<GameObject>("Prefabs/EnemyMain");

        maxHp = enemy.EnemyHp;
        minAtk = enemy.EnemyMinAtk;
        maxAtk = enemy.EnemyMaxAtk;
        addDef = enemy.EnemyDef;
        addRegen = enemy.EnemyRegen;
        xp = enemy.EnemyXp;

        GameObject clone = Instantiate(enemyPrefab, GameObject.Find("Enemy").transform);//transform 조정 //test중
        clone.name = enemy.EnemyName;

        clone.AddComponent<Enemy_Script>();
        clone.GetComponent<Enemy_Script>().maxHp = maxHp;
        clone.GetComponent<Enemy_Script>().minAtk = minAtk;
        clone.GetComponent<Enemy_Script>().maxAtk = maxAtk;
        clone.GetComponent<Enemy_Script>().addDef = addDef;
        clone.GetComponent<Enemy_Script>().addRegen = addRegen;
        clone.GetComponent<Enemy_Script>().xp = xp;

        clone.transform.GetChild(0).GetComponent<Image>().sprite = enemy.EnemyImage;

        clone.transform.GetChild(0).GetComponent<Animator>().runtimeAnimatorController = enemy.EnemyAnimCtl;

        clone.transform.position = new Vector3(clone.transform.position.x - 1.78f * xPos, clone.transform.position.y, 100);

        enemyList.Add(clone);

    }

    //not automaking
    public List<GameObject> mapBoxArray = new List<GameObject>();

}
