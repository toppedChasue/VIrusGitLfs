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

        if (target == null) // 타겟이 없으면 처음 전달 받은 타겟의 위치로 계속 진행
            Moving(dir);

        else if (target != null)
        {
            Vector3 dir = target.position - bulletPos.position;
            //타겟이 있으면 방향 정보가 계속 업데이트 되게해서 따라가게 함
            Moving(dir);
        }

        if (transform.position.x > maxXPos)
        { //총알이 너무 멀리 벗어나지 않게 조절

            gameObject.SetActive(false);
        }
    }

    private void Moving(Vector3 dir)
    {
        transform.position += dir * speed * Time.deltaTime;
        //transform.Translate(dir);

        //transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        //transform.position += Vector3.forward * speed * Time.deltaTime;
        //멀면 빠르고 가까우면 느림
    }

    private void OnDisable()
    {
        transform.position = bulletPos.position;
    }

}