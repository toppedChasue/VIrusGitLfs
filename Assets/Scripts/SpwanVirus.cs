using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanVirus : MonoBehaviour
{
    public GameObject[] virusPrefabs;

    private int virusA;
    private int virusB;
    private int virusC;
    private int virusD;

    public Transform spwanArea;

    public float waitMadeTime; //하나 생성되고 다시 생성될때까지 쿨타임
    public int enemySpwanCount;
    public int BossSpwanCount;
    private int nextBoss;

    public List<Enemy> enemies = new List<Enemy>();

    public bool isSpwan;
    public bool isBossSpwan;

    public GameManager gameManager;
    private void Start()
    {
        isSpwan = true;
        isBossSpwan = false;
        enemySpwanCount = 10;
        nextBoss = BossSpwanCount;
    }
    private void Update()
    {
        StartStage();
        NextStage();
        if (GameManager.instance.enemyKillCount == nextBoss)
        {
            isBossSpwan = true;
            GameManager.instance.enemyKillCount = 0;
            nextBoss += BossSpwanCount;
        }
    }

    private void StartStage()
    {
        if (isSpwan)
        {
            waitMadeTime = 0.3f;
            StartCoroutine(MadeVirus());
            GameManager.instance.stage++;
        }

    }
    private void NextStage()
    {
        if (enemies.Count == 0)
        {
            isSpwan = true;
        }
    }

    public IEnumerator MadeVirus()
    {
        List<int> enemyConunt = new List<int>();

        if (isSpwan)
        {
            if (isBossSpwan)
            {
                isSpwan = false;
                isBossSpwan = false;
                float ran = Random.Range(spwanArea.position.y - 2f, spwanArea.position.y + 2f);
                Enemy obj = Instantiate(virusPrefabs[4], spwanArea.position, Quaternion.identity).GetComponent<Enemy>();
                enemies.Add(obj);
                yield return new WaitForSeconds(waitMadeTime);
            }
            else
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
                Enemy obj = Instantiate(virusPrefabs[enemyConunt[0]], new Vector2(spwanArea.position.x, ran), Quaternion.identity).GetComponent<Enemy>();
                enemies.Add(obj);
                enemyConunt.RemoveAt(0);
                yield return new WaitForSeconds(waitMadeTime);
            }
        }
    }
}
