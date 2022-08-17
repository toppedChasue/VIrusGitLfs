using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusBoss : Enemy
{
    public float speed;
    public float maxDp;
    public float maxHp;
    public int enemyGold;

    public float currentTime;
    public float maxTime;

    public CircleCollider2D col;
    Animator anim;

    private void Awake()
    {
        Init();
        player = FindObjectOfType<Player>();
        spwanVirus = FindObjectOfType<SpwanVirus>();
        col = GetComponent<CircleCollider2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= maxTime)
        {
            currentTime = maxTime;
        }
        BossHealthUp(CurrentHp);
    }

    protected override void Init()
    {
        base.Init();
        gold = enemyGold * GameManager.instance.stage;
        maxHp = ((GameManager.instance.stage * 2) + maxHp);
        CurrentHp = maxHp;
        DP = ((GameManager.instance.stage * 2) + maxDp) * 2;
        virusFrontSpeed = speed;
        virusUpDownSpeed = speed;
    }

    private void BossHealthUp(float hp)
    {
        if (currentTime >= maxTime && maxHp * 0.5f >= hp)
        {
            inUnbeatable = true;
            StartCoroutine(HealthUp(CurrentHp, maxHp));
        }
    }

    IEnumerator HealthUp(float hp, float heal)
    {
        anim.SetBool("isMoving", false);
        virusFrontSpeed = 0f; //���ڸ�
        virusUpDownSpeed = 0f;
        col.radius = 1f; //�ݶ��̴� ũ�� Ȯ��
        yield return new WaitForSeconds(0.1f);
        CurrentHp = hp + (heal /2); //��
        yield return new WaitForSeconds(5f);
        anim.SetBool("isMoving", true);
        currentTime = 0; //��Ÿ�� �ʱ�ȭ
        virusFrontSpeed = speed; //���󺹱�
        virusUpDownSpeed = speed;
        col.radius = 0.5f;
        inUnbeatable = false;
    }
}
