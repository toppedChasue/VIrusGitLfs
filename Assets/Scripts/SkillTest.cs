using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTest : Skill
{//일단 스킬은 스탑

    Vector3 dir;
    bool isSkillOver;
    public bool isAtk;

    private void Awake()
    {
        Init("SkillTest");

        dir = (target.position - transform.position).normalized;

        //if (transform.position.x >= target.position.x)
        //{
        //    dir = (startPos.position - transform.position).normalized;
        //}
   
    }

    private void Update()
    {
        Action();
    }
    protected override void Init(string name)
    {
        base.Init("SkillTest");
        skillDmg = 10;
        coolDown = 2f;
    }

    protected override void SkillStart()
    {
        base.SkillStart();
        //transform.position += dir * 10 * Time.deltaTime;
        if (!isAtk)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, 10 * Time.deltaTime);
            if(transform.position == target.position)
            isAtk = true;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, startPos.position, 10 * Time.deltaTime);
            if(transform.position == startPos.position)
            isAtk = false;
        }


        //if (!isSkillOver)
        //{
        //    currentTime = 0;
        //    isSkillTime = false;
        //}

    }
}
