using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mineral : MonoBehaviour
{
    public int value_Mineral;
    public int mineralCost;

    //UI�� ��Ÿ���� ���� ������ �ʿ��Ѱ�?
    public void MineralUp()
    {
        if(GameManager.instance.gold >= mineralCost)
        {
            value_Mineral += Mathf.RoundToInt(value_Mineral * 0.5f);
            //Mathf.RoundToInt : �Ҽ��� ù��° �ڸ����� �ݿø� int�� ��ȯ
            mineralCost += Mathf.RoundToInt(mineralCost * 0.8f);
        }
    }

}
