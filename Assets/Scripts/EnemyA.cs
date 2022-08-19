using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyA : Enemy
{
    public float speed;
    public float maxDp;
    public int enemyGold;

    private void Awake()
    {
        Init();
        spwanVirus = SpwanVirus.instance.gameObject.GetComponent<SpwanVirus>();
    }

    protected override void Init()
    {
        base.Init();
        CurrentHp = GameManager.instance.stage * 2;
        DP = (GameManager.instance.stage / 5) * (maxDp + 1);
        virusFrontSpeed = speed + (GameManager.instance.stage / 100);
        gold = enemyGold;
    }
}
