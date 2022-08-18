using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBullet : MonoBehaviour
{
    public float damage;
    public float speed;
    public Transform target;
    public Transform bulletPos;
    private float maxXPos = 15f;

    Vector3 dir;

    [SerializeField]
    private Tower tower;

    private void Awake()
    {
        tower = GameObject.FindObjectOfType<Tower>();
        bulletPos = tower.bulletPos;
        transform.position = bulletPos.position;
    }

    //private void Start()
    //{
    //    dir = (target.position - bulletPos.position).normalized;
    //}
    private void Update()
    {
        if (target != null)
        {
            Vector3 dir2 = (target.position - bulletPos.position).normalized;
            transform.position += dir2 * speed * Time.deltaTime;
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

    private void OnDisable()
    {
        transform.position = bulletPos.position;
    }


}
