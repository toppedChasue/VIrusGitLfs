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
                //Ÿ���� ���ʹ��� �Ÿ��� dis������ �־���
                if (dis < shortDis)
                {
                    shortDis = dis;
                    target = spwanVirus.enemies[i].transform;
                }//���� ����� �Ÿ��� �ִ� ���� Ÿ������ �־���
            }
            if(target != null && currentTime >= attackTime)
            {
                Debug.Log("����");
            }

        }
    }

}
