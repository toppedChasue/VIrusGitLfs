using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : Player
{
    //�߻�Ŭ������ �����غ���
    //Ÿ���� ���� - ����Ÿ��, ���� & ����� Ÿ��, ���Ÿ��,

    public GameObject[] TowerPrefabs; //�����յ�
    public Vector2 towersize; //���� - ���ݹ���, ��������

    public float currentTime;
    public float coolTime;
    public int atk;

    public Player player;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    void Attack()
    {
        SearchVirus();
    }
    //�ʿ��Ѱ͵�
    //���� - ���ݷ�, ���ݹ���, ���ݼӵ�, 
    //���� - ���� ������, ���� ���ӽð�, ���� ��Ÿ��, ���� ���� - �Ʊ�Ÿ��, �÷��̾�, ����� ���� - �ʵ�
    //��� - ��� ȹ�淮, ��� ȹ�� ��Ÿ��


    //Ÿ���� �ؾ��Ұ�
    //���� - Ÿ�ټ���, ��Ÿ�� ������, �׼�, 





}
