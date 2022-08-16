using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkTower : Tower
{
    public Transform bulletPos;
    public int towerAtk;
    public float fireTime;
    public Vector2 atkSize;

    public float bulletSpeed;
    public int bulletDamage;

    public GameObject towerBullet;
    protected Transform towerTarget; //���� ��ǥ��
    protected Vector3 direction; //���� ��ǥ���� ����

    ObjectManager objectManager;

    public void Awake()
    {
        spwanVirus = GameObject.FindObjectOfType<SpwanVirus>().GetComponent<SpwanVirus>();
        objectManager = GameObject.FindObjectOfType<ObjectManager>().GetComponent<ObjectManager>();
        Init();
    }

    private void Update()
    {
        SearchVirus();
    }

    private void SearchVirus()
    {
        Collider2D[] obj = Physics2D.OverlapBoxAll(new Vector2(transform.position.x + 8, transform.position.y), atkSize, 0, layer);
        List<Enemy> enemies = new List<Enemy>();//����Ʈ�� ��� ����
        foreach (Collider2D enemycol in obj)
        {
            Enemy enemy1 = enemycol.GetComponent<Enemy>();
            enemies.Add(enemy1);
        }
        currentTime += Time.deltaTime;

        if (enemies != null)
        {
            float shortDis = 20f;
            for (int i = 0; i < enemies.Count; i++)//���ʹ� ������ŭ �ݺ�
            {
                float dis = Vector3.Distance(transform.position, enemies[i].transform.position);
                //Ÿ���� ���ʹ��� �Ÿ��� dis������ �־���
                if (dis < shortDis)
                {
                    shortDis = dis;
                    towerTarget = enemies[i].transform;
                }//���� ����� �Ÿ��� �ִ� ���� Ÿ������ �־���
            }
            if (towerTarget != null && currentTime > fireTime)
            {
                StartCoroutine(Attack("Tower"));
            }
        }


    }
    public IEnumerator Attack(string name)
    {
        currentTime = 0;

        var obj = objectManager.MakeObj(name);
        Bullet abc = obj.GetComponent<Bullet>();
        abc.target = towerTarget;
        abc.speed = bulletSpeed;
        abc.damage = atk;
        abc.bulletPos = bulletPos;
        yield return new WaitForSeconds(0.1f);
    }

    protected override void Init()
    {
        base.Init();
        atk = towerAtk;
        maxTime = fireTime;
        towersize = atkSize;
    }

}
