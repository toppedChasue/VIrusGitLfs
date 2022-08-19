using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{//일단 스킬은 스탑
    public string skillName;

    public int skillDmg;
    protected float coolDown;
    protected float currentTime;
    protected Transform startPos;

    public bool isUnlock;
    public bool isSkillTime;

    protected Transform target;

    protected virtual void Init(string name)
    {
        coolDown = 0;
        skillName = name;
        this.gameObject.transform.position = startPos.position;
    }

    protected virtual void Action()
    {
        if(isUnlock)
        {
            if (!isSkillTime)
                currentTime += Time.deltaTime;

            if (currentTime >= coolDown)
            {
                isSkillTime = true;
                currentTime = 0;
            }

            if (isSkillTime)
                SkillStart();
        }

    }

    protected virtual void SkillStart() { }

}
