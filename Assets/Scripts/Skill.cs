using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{//일단 스킬은 스탑
    protected string skillName;
    protected float skillDmg;
    protected float coolTime;
    protected float currentTime;
    protected float range;

    protected virtual void Init()
    {

    }
}
