using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{//�ϴ� ��ų�� ��ž
    protected string skillName;
    protected int skillDmg;
    protected float coolTime;
    protected float currentTime;
    protected float range;

    protected bool isUnlock;

    protected List<Skill> skillList;
    protected List<Skill> unLockSkillList;

    public Transform target;

    Player player;

    private void Start()
    {
        skillList = new List<Skill>();
        unLockSkillList = new List<Skill>();
        player = GetComponent<Player>();
    }

    protected virtual void Init()
    {
        target = player.target;
    }
}
