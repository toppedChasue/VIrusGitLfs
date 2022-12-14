using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public float speed;
    public Transform target;
    public Transform bulletPos;

    private float maxXPos = 15f;

    Vector3 dir;

    [SerializeField]
    private Player player;


    private void Awake()
    {
        player = GameObject.FindObjectOfType<Player>();
        bulletPos = player.bulletPos;
    }

    private void OnEnable()
    {
        transform.position = bulletPos.position;
    }

    private void Update()
    {
        if (target != null)
        {
            Vector3 dir2 = (target.position - bulletPos.position).normalized;
            transform.position += dir2 * speed * Time.deltaTime;

            //transform.forward = dir2; 이거때문에 총알의 정면이 바뀜
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
        transform.position += transform.right * speed * Time.deltaTime;
    }

}