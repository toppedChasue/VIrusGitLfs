using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public float speed;
    public Transform target;
    public Transform bulletPos;
    private Transform originPos;

    private float maxXPos = 15f;

    Vector3 dir;

    [SerializeField]
    private Player player;

    private void Awake()
    {
        player = GameObject.FindObjectOfType<Player>();
        bulletPos = player.bulletPos;
        transform.position = bulletPos.position;
    }

    private void Start()
    {
        dir = target.position - bulletPos.position;

    }
    private void Update()
    {

        if (target == null) // Ÿ���� ������ ó�� ���� ���� Ÿ���� ��ġ�� ��� ����
            Moving(dir);

        else if (target != null)
        {
            Vector3 dir = target.position - bulletPos.position;
            //Ÿ���� ������ ���� ������ ��� ������Ʈ �ǰ��ؼ� ���󰡰� ��
            Moving(dir);
        }

        if (transform.position.x > maxXPos)
        { //�Ѿ��� �ʹ� �ָ� ����� �ʰ� ����

            gameObject.SetActive(false);
        }
    }

    private void Moving(Vector3 dir)
    {
        transform.position += dir * speed * Time.deltaTime;
        //transform.Translate(dir);

        //transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        //transform.position += Vector3.forward * speed * Time.deltaTime;
        //�ָ� ������ ������ ����
    }

    private void OnDisable()
    {
        transform.position = bulletPos.position;
    }

}