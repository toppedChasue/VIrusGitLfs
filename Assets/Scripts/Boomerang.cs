using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : Skill
{
    public bool isAtk;
    public int abc;

    private void OnEnable()
    {
        startPos = GameObject.Find("BoomerangPos").transform;
        target = GameObject.Find("Target").transform;
        Init("Boomerang");
        abc = 1;
    }

    private void Update()
    {
        Action();
        skillDmg = Player.Instance().GetComponent<Player>().bulletDamage;
    }

    protected override void Init(string name)
    {
        base.Init("Boomerang");
        coolDown = 2f;
    }

    protected override void SkillStart()
    {
        base.SkillStart();
        Rotate();

        if (!isAtk && abc>0)
        {
            transform.position = Vector2.Lerp(transform.position, target.position, Time.deltaTime) ;
            if (target.position.x -transform.position.x < 0.5f)
            {
                abc--;
                //한번만 튕기게 해야한다.
                isAtk = true;
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, startPos.position, 10 * Time.deltaTime);
            if (transform.position.x <= startPos.position.x)
            {
                isAtk = false;
                isSkillTime = false;
                abc++;
            }

        }
    }

    private void Rotate()
    {//부메랑 자체 회전
        transform.Rotate(Vector3.forward * 1000 * Time.deltaTime);
    }
}
