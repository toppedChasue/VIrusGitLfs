using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    float currentTime;
    public float attackTime;
    Transform target;

    public SpwanVirus spwanVirus;


    private void Update()
    {
        currentTime += Time.deltaTime;
        if (spwanVirus.enemies == null)
            return;

        if (spwanVirus.enemies != null)
        {
            float shortDis = 9999999f;
            for (int i = 0; i < spwanVirus.enemies.Count; i++)
            {
                float dis = Vector3.Distance(transform.position, spwanVirus.enemies[i].transform.position);
                //타워와 에너미의 거리를 dis변수에 넣어줌
                if (dis < shortDis)
                {
                    shortDis = dis;
                    target = spwanVirus.enemies[i].transform;
                }//가장 가까운 거리에 있는 적을 타겟으로 넣어줌
            }
            if(target != null && currentTime >= attackTime)
            {
                Debug.Log("공격");
            }

        }
    }

}
