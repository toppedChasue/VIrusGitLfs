using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;

    public float bulletSpeed;
    public float bulletDamage;

    float currentTime;
    public float attackTime;
    Transform target;

    public SpwanVirus spwanVirus;
    public ObjectManager objectManager;
    public Player player;
    TowerBullet bulletObj;

    private void Start()
    {
        bulletDamage = player.GetComponent<Player>().bulletDamage;
        bulletSpeed = player.GetComponent<Player>().bulletSpeed;
    }
    private void Update()
    {
        currentTime += Time.deltaTime;
        if (spwanVirus.enemies == null)
            return;

        if (spwanVirus.enemies != null)
        {
            float shortDis = 9999999f;
            for (int i = 0; i < spwanVirus.enemies.Count; i++)
            {
                float dis = Vector3.Distance(transform.position, spwanVirus.enemies[i].transform.position);
                //Ÿ���� ���ʹ��� �Ÿ��� dis������ �־���
                if (dis < shortDis)
                {
                    shortDis = dis;
                    target = spwanVirus.enemies[i].transform;
                }//���� ����� �Ÿ��� �ִ� ���� Ÿ������ �־���
            }
            if(target != null && currentTime >= attackTime)
            {
                var obj = objectManager.MakeObj("Tower");
                bulletObj = obj.GetComponent<TowerBullet>();
                bulletObj.target = target;
                bulletObj.speed = bulletSpeed;
                bulletObj.damage = bulletDamage;
                currentTime = 0;
            }
        }
    }

}
