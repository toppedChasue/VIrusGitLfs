using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IEnemy
{
    public float CurrentHp { get; set; }
    public float MaxHp { get; set; }
    public float DP { get; set; }
}

public enum Type { A, B, C, D, BOSS}
public class Enemy : MonoBehaviour, IEnemy
{

    public string enemyName;
    public Type type;
    protected int gold;

    protected float virusFrontSpeed;
    protected float virusUpDownSpeed;

    private Vector3 virusPos; //Virus가 생성되었을 때 위치를 기억하는 변수
    public Player player;
    public SpwanVirus spwanVirus;

    public bool inUnbeatable;

    public float CurrentHp { get; set; }
    public float MaxHp { get; set; }
    public float DP { get; set; }


    private void Awake()
    {
        Init();
        player = FindObjectOfType<Player>();
        spwanVirus = FindObjectOfType<SpwanVirus>();
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
        while (transform.position.y > virusPos.y -0.4f)
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
            GameManager.instance.gold += gold * GameManager.instance.stage;
            spwanVirus.enemies.Remove(this);
            GameManager.instance.enemyKillCount++;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();

            if(!inUnbeatable)
            {
                if (bullet.b_hp >= 1)
                {
                    TakeDamage(bullet.damage);
                    bullet.b_hp--;
                    if (bullet.b_hp == 0)
                    {
                        collision.gameObject.SetActive(false);
                        bullet.b_hp = 1;
                        bullet.transform.position = bullet.originPos.position;
                    }
                }
            }
            else
            {
                collision.gameObject.SetActive(false);
                bullet.b_hp= 1;
                bullet.transform.position = bullet.originPos.position;
            }
        }


        if(collision.gameObject.tag == "Finish")
        {
            virusFrontSpeed = 0f;
        }
    }
}
