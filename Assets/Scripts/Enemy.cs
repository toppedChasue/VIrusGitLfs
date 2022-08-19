using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IEnemy
{
    public float CurrentHp { get; set; }
    public float MaxHp { get; set; }
    public float DP { get; set; }
}

public enum enemyType { A, B, C, D, BOSS }
public class Enemy : MonoBehaviour, IEnemy
{

    public string enemyName;
    public enemyType type;
    protected int gold;

    protected float virusFrontSpeed;
    protected float virusUpDownSpeed;

    private Vector3 virusPos; //Virus가 생성되었을 때 위치를 기억하는 변수

    public bool inUnbeatable;
    protected SpwanVirus spwanVirus;

    public float CurrentHp { get; set; }
    public float MaxHp { get; set; }
    public float DP { get; set; }


    private void Awake()
    {
        Init();
        inUnbeatable = false;
    }

    private void Start()
    {
        StartCoroutine(VirusMove());
    }

    protected virtual void Init()
    {
        virusFrontSpeed = 0.4f;
        virusUpDownSpeed = 0.5f;
        virusPos = transform.position;
    }

    private IEnumerator VirusMove()
    {
        while (transform.position.y < virusPos.y + 0.4f)
        {
            transform.Translate(new Vector3(-virusFrontSpeed, virusUpDownSpeed) * Time.deltaTime);
            yield return null;
        }
        while (transform.position.y > virusPos.y - 0.4f)
        {
            transform.Translate(new Vector3(-virusFrontSpeed, -virusUpDownSpeed) * Time.deltaTime);
            yield return null;
        }
        StartCoroutine(VirusMove());
    }
    public void TakeDamage(float damage)
    {
        //방어력이 있으면, 체력 전에 방어력을 먼저 깎는다

        if (DP > 0)
        {//방어력이 있고 0보다 크면
            DP -= damage;
            return;
        }

        CurrentHp -= damage;
        if (CurrentHp <= 0)
        {
            switch(type)
            {
                case enemyType.A:
                case enemyType.B:
                case enemyType.C:
                case enemyType.D:
                    GameManager.instance.gold += gold * GameManager.instance.stage;
                    break;
                case enemyType.BOSS:
                    GameManager.instance.gold += (gold *2) * GameManager.instance.stage;
                    GameManager.instance.skillPoint++;
                    break;
                    
            }
            SpwanVirus.instance.enemies.Remove(this);
            GameManager.instance.enemyKillCount++;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            
            if (!inUnbeatable)
            {
                TakeDamage(bullet.damage);
                collision.gameObject.SetActive(false);
            }
            else
            {
                collision.gameObject.SetActive(false);
            }
        }

        if (collision.gameObject.tag == "TowerBullet")
        {
            TowerBullet towerBullet = collision.gameObject.GetComponent<TowerBullet>();
            if (!inUnbeatable)
            {
                TakeDamage(towerBullet.damage);
                collision.gameObject.SetActive(false);
            }
            else
            {
                collision.gameObject.SetActive(false);
            }
        }


        if (collision.gameObject.tag == "Finish")
        {
            virusFrontSpeed = 0f;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Skill")
        {
            var skill = collision.gameObject.GetComponent<Skill>();

            if (!inUnbeatable)
            {
                TakeDamage(skill.skillDmg);
            }
            else
                return;
        }
    }
}
