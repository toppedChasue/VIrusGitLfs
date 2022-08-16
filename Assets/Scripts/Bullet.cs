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

    public Rigidbody2D rigid;

    private void Awake()
    {
        player = GameObject.FindObjectOfType<Player>();
        bulletPos = player.bulletPos;
        transform.position = bulletPos.position;
    }

    private void Start()
    {
        dir = (target.position - bulletPos.position).normalized;
    }
    private void Update()
    {
        if (target != null)
        {
            transform.position += transform.forward * speed * Time.deltaTime;

            Vector3 dir2 = (target.position - bulletPos.position).normalized;
            transform.forward = dir2;
        }
        else if (target == null)
            Moving();

        if (transform.position.x > maxXPos)
        { //총알이 너무 멀리 벗어나지 않게 조절
            gameObject.SetActive(false);
        }
    }

    private void Moving()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnDisable()
    {
        transform.position = bulletPos.position;
    }

}