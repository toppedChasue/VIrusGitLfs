using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private GameObject prefabs;

    Vector2 dir;

    List<string> ABC = new List<string>();
    private void Start()
    {
        dir = target.transform.position - transform.position;
    }
    void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position, target.transform.position, 5 * Time.deltaTime);
        transform.Translate(dir * Time.deltaTime) ;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.name);

        ABC.Add(collision.name);

        //for (int i = 0; i < ABC.Count; i++)
        //{
        //    Debug.Log("112" + ABC[i]);
        //}

        if (ABC.Contains("Target (1)"))
        {
            Debug.Log("1");
        }
    }

}
