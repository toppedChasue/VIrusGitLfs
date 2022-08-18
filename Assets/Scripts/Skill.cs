using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{//�ϴ� ��ų�� ��ž
    public string skillName;

    public int skillDmg;
    public float coolDown;
    public float currentTime;
    public Transform startPos;

    public bool isUnlock;
    public bool isSkillTime;

    public Transform target;
    SpwanVirus spwanVirus;

    protected virtual void Init(string name)
    {
        spwanVirus = GetComponent<SpwanVirus>();
        skillDmg = 0;
        coolDown = 0;
        skillName = name;
        this.gameObject.transform.position = startPos.position;
    }

    protected virtual void Action()
    {
        if(!isSkillTime)
        currentTime += Time.deltaTime;

        if (currentTime >= coolDown)
        {
            isSkillTime = true;
            currentTime = 0;
        }
            
        if(isSkillTime)
            SkillStart();
    }

    protected virtual void SkillStart() { }


    //��Ÿ�� ������ ����
    //Ÿ�� ��ġ��

}
