using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mineral : MonoBehaviour
{
    public int value_Mineral;
    public int mineralCost;

    //�̳׶��� ���׷��̵� �Ҷ����� ���ε��� ĳ�� �翡 ���������
    public void MineralUp()
    {
        if(GameManager.instance.gold >= mineralCost)
        {
            value_Mineral += value_Mineral * (int)0.5f;
            mineralCost += mineralCost;
        }
    }

}
