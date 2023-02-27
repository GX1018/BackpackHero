using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : GSingleton<MapManager>
{
    //다음층 이동 관련 변수
    public GameObject screenTrans;

    public bool isTutorial = true;
    GameObject tutorialMap;
    GameObject stageMap;
    
    //맵에서 이벤트 체크용
    public bool nextFloor = false;
    public bool inStore = false;

    // Start is called before the first frame update
    void Start()
    {
        tutorialMap = GameObject.Find("TutorialMap");
        stageMap = GameObject.Find("StageMap");
    }

    // Update is called once per frame
    void Update()
    {
        if (nextFloor == true)
        {
            if (isTutorial == true)
            {
                tutorialMap.SetActive(false);
                findDoor = false;
                isTutorial = false;
            }
            else
            {
                //지우고
                for (int i = 0; i < stageMap.transform.childCount; i++)
                {
                    Destroy(stageMap.transform.GetChild(i).gameObject);
                }

                //만들어줌(함수 생성 후 삽입예정)
            }
        }
    }

    public GameObject nearestMapBox;
    public int playerPos;
    public int targetPos;
    //갈림길 이동 관련 변수
    public int crossroads;
    public int firstSubRoad;
    public int lastSubRoad;
    //
    public bool moveCharacter = false;

    public bool findChest = false;
    public bool openChest = false;



    //맵에서 계단에 도작했을때
    public bool findDoor = false;

    public int floor = 0;


    //적 생성 관련 변수//enemymanager?
    Enemy enemy;
    GameObject enemyPrefab;


    public int maxHp;

    public int minAtk;
    public int maxAtk;
    public int addDef;
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
        xp = enemy.EnemyXp;

        GameObject clone = Instantiate(enemyPrefab, GameObject.Find("Enemy").transform);//transform 조정 //test중
        clone.name = enemy.EnemyName;

        clone.AddComponent<Enemy_Script>();
        clone.GetComponent<Enemy_Script>().maxHp = maxHp;
        clone.GetComponent<Enemy_Script>().minAtk = minAtk;
        clone.GetComponent<Enemy_Script>().maxAtk = maxAtk;
        clone.GetComponent<Enemy_Script>().addDef = addDef;
        clone.GetComponent<Enemy_Script>().xp = xp;

        clone.transform.GetChild(0).GetComponent<Image>().sprite = enemy.EnemyImage;

        clone.transform.GetChild(0).GetComponent<Animator>().runtimeAnimatorController = enemy.EnemyAnimCtl;

        clone.transform.position = new Vector3(clone.transform.position.x - 1.78f * xPos, clone.transform.position.y, 100);

        enemyList.Add(clone);

    }
}
