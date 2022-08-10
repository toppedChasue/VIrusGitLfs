using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int b_hp =1;

    public float damage;
    public float speed;
    public Transform target;
    public Transform bulletPos;
    public Transform originPos;

    private float maxXpos = 15f;

    Vector3 dir;

    private void Start()
    {
        transform.position = bulletPos.position;
        originPos = bulletPos;

        dir = target.position - transform.position;
    }
    private void Update()
    {
        if (target == null) // 타겟이 없으면 처음 전달 받은 타겟의 위치로 계속 진행
            Moving();

        else if (target != null)
        {
            dir = target.position - transform.position;
            //타겟이 있으면 방향 정보가 계속 업데이트 되게해서 따라가게 함
            Moving();
        }

        if (transform.position.x > maxXpos)
        { //총알이 너무 멀리 벗어나지 않게 조절
            transform.position = originPos.position;
            //비활성화 전에 위치를 원래 위치로 조정
            gameObject.SetActive(false);
        }
    }

    private void Moving()
    {
        transform.position += dir.normalized * speed * Time.deltaTime;
    }
}