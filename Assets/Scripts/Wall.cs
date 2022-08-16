using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField]
    private GameObject[] walls;

    Animator[] anim;
    public BtnManger btnManger;
    private void Awake()
    {
        anim = GetComponentsInChildren<Animator>();
    }

    private void Update()
    {
        if (btnManger.isMineOpen == true)
        {
            for (int i = 0; i < walls.Length; i++)
            {
                anim[i].SetTrigger("Open");
            }
            Destroy(gameObject, 2);
        }
    }
}
