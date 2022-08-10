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
        player = FindObjectOfType<Player>();
        spwanVirus = FindObjectOfType<SpwanVirus>();
    }

    protected override void Init()
    {
        base.Init();
        gold = enemyGold * (GameManager.instance.stage / 5);
        CurrentHp = GameManager.instance.stage * 2;
        DP = (GameManager.instance.stage / 5) * (maxDp + 1);
        virusFrontSpeed = speed + (GameManager.instance.stage / 100);
    }
}
