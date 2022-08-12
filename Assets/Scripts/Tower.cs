using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  enum  TowerType { ATK, BUFF, GOLD }

public class Tower : MonoBehaviour
{
    //Ÿ���� ���� - ����Ÿ��, ���� & ����� Ÿ��, ���Ÿ��,
    public TowerType type;

    public string towerName; //Ÿ���� �̸�
    public float currentTime;
    public float maxTime; //�����ϸ� �׼�
    public Vector2 towersize; //���� - ���ݹ���, ��������
    public int atk; //���ݷ�, ������ġ, �������ġ, ��� ȹ�淮

    public SpwanVirus spwanVirus;

    //�ʿ��Ѱ͵�
    //Ÿ��
    //���� - ���ݷ�, ���ݹ���, ���ݼӵ�, 
    //���� - ���� ������, ���� ���ӽð�, ���� ��Ÿ��, ���� ���� - (�Ʊ�Ÿ��, �÷��̾�), ����� ���� - �ʵ�
    //��� - ��� ȹ�淮, ��� ȹ�� ��Ÿ��

    //Ÿ���� �ؾ��Ұ�
    //���� - Ÿ��, ��Ÿ��, �׼�, ������

    private void Update()
    {
        currentTime += Time.deltaTime;
    }
    void OnDrawGizmos()
    {//���� ���� �׷���
        Gizmos.color = Color.red;
        switch (type)
        {
            case TowerType.ATK:
                Gizmos.DrawRay(transform.localPosition, Vector3.right);
                break;
            case TowerType.BUFF:
                Gizmos.DrawWireCube(transform.position, towersize);
                break;
        }
    }
}
