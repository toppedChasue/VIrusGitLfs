using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject arms;

    public Vector2 size;
    public LayerMask layer;

    public Transform target;

    public GameObject bullet;
    public Transform bulletPos;
    public float bulletSpeed;
    public int bulletDamage;
    
    public float attackRange;

    public int power;

    private float currentTime;
    public float attacktTime;

    public ObjectManager objectManager;
    private Bullet bulletObj;
    public SpriteRenderer muzzle;

    private void Update()
    {
        SearchVirus();
    }
    public void SearchVirus()
    {
        Collider2D[] obj = Physics2D.OverlapBoxAll(new Vector2(transform.position.x + 9, transform.position.y), size, 0, layer);
        List<Enemy> enemies = new List<Enemy>();//����Ʈ�� ��� ����
        foreach (Collider2D enemycol in obj)
        {
            Enemy enemy1 = enemycol.GetComponent<Enemy>();
            enemies.Add(enemy1);
        }

        currentTime += Time.deltaTime;

        if (enemies != null)
        {
            float shortDis = attackRange;
            for (int i = 0; i < enemies.Count; i++)
            {
                float dis = Vector3.Distance(transform.position, enemies[i].transform.position);
                //Ÿ���� ���ʹ��� �Ÿ��� dis������ �־���
                if (dis < shortDis)
                {
                    shortDis = dis;
                    target = enemies[i].transform;
                }//���� ����� �Ÿ��� �ִ� ���� Ÿ������ �־���
            }
            if (target != null && currentTime > attacktTime)
            {
                StartCoroutine(Attack(power, "Basic"));
            }
        }

    }
    public IEnumerator Attack(int power, string name)
    {
        currentTime = 0;
        for (int i = 0; i < power + 1; i++)
        {
            var obj = objectManager.MakeObj(name);
            bulletObj = obj.GetComponent<Bullet>();
            bulletObj.target = target;
            bulletObj.bulletPos = bulletPos;
            bulletObj.speed = bulletSpeed;
            bulletObj.damage = bulletDamage;

            AttackEffect(255, -0.01f);
            yield return new WaitForSeconds(0.1f);
            AttackEffect(255, 0.01f);
        }
    }

    private void AttackEffect(byte alpha, float x)
    {
        muzzle.color = new Color32(255, 255, 255, alpha);
        arms.transform.localPosition += new Vector3(x, 0, 0);
    }
    void OnDrawGizmos()
    {//���� ���� �׷���
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(new Vector2(transform.position.x + 9, transform.position.y), size);
    }
}
