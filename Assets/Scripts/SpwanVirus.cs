using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanVirus : MonoBehaviour
{
    public static SpwanVirus instance = null;
    public static SpwanVirus Instance()
    {
        return instance;
    }

    public GameObject[] virusPrefabs;

    private int virusA;
    private int virusB;
    private int virusC;
    private int virusD;

    public Transform spwanArea;

    public float waitMadeTime; //하나 생성되고 다시 생성될때까지 쿨타임
    public int enemySpwanCount;
    private float BossSpwanCount;
    public float nextBoss;

    public  List<Enemy> enemies = new List<Enemy>();

    public bool isSpwan;
    public bool isBossSpwan;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        isSpwan = true;
        isBossSpwan = false;
        enemySpwanCount = 10;
        nextBoss = 20;
        BossSpwanCount = 10;
    }
    private void Update()
    {
        StartStage();
        BossSpwanStart();
        NextStage();
    }

    private void StartStage()
    {
        if (isSpwan)
        {
            waitMadeTime = 0.3f;
            StartCoroutine(MadeVirus());
        }
    }
    private void NextStage()
    {
        if (enemies.Count == 0 && !isBossSpwan)
        {//몬스터 수가 3 이하, 보스 소환이 아닐때

            isSpwan = true;
        }
    }

    private void BossSpwanStart()
    {
        if (GameManager.instance.enemyKillCount >= nextBoss)
        {
            isSpwan = false;
            isBossSpwan = true;

            for (int i = 0; i < enemies.Count; i++)
            {
                Destroy(enemies[i].gameObject);
            }
            enemies.Clear();
            StopCoroutine(MadeVirus());
            GameManager.instance.enemyKillCount = 0;
            nextBoss += BossSpwanCount;
        }
        BossSpwan();
    }

    public IEnumerator MadeVirus()
    {
        List<int> enemyConunt = new List<int>(); //소환할 몬스터 갯수

        if (isSpwan)
        {
            if (!isBossSpwan)
            {
                for (int index = 0; index < enemySpwanCount; index++)
                {
                    int ran = Random.Range(0, 4);
                    enemyConunt.Add(ran);

                    switch (ran)
                    {
                        case 0:
                            virusA++;
                            break;
                        case 1:
                            virusB++;
                            break;
                        case 2:
                            virusC++;
                            break;
                        case 3:
                            virusD++;
                            break;
                    }
                }
            }

            while (enemyConunt.Count > 0)
            {
                isSpwan = false;
                float ran = Random.Range(spwanArea.position.y - 2f, spwanArea.position.y + 2f);
                EnemyA obj = Instantiate(virusPrefabs[enemyConunt[0]], new Vector2(spwanArea.position.x, ran), Quaternion.identity).GetComponent<EnemyA>();
                enemies.Add(obj);
                enemyConunt.RemoveAt(0);
                yield return new WaitForSeconds(waitMadeTime);
            }
        }


    }

    private void BossSpwan()
    {
        if (isBossSpwan)
        {
            isBossSpwan = false;
            float ran = Random.Range(spwanArea.position.y - 2f, spwanArea.position.y + 2f);
            var obj = Instantiate(virusPrefabs[4], spwanArea.position, Quaternion.identity).GetComponent<VirusBoss>();
            enemies.Add(obj);
        }
    }
}
