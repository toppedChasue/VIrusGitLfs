using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mineral : MonoBehaviour
{
    public GameObject mineral;

    public int value_Mineral;

    public int mineraCost;

    //�̳׶��� ���׷��̵� �Ҷ����� ���ε��� ĳ�� �翡 ���������
    public void MineralUp()
    {
        value_Mineral += value_Mineral * (int) 0.5f;
    }

}
