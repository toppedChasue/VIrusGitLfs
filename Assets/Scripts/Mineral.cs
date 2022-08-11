using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mineral : MonoBehaviour
{
    public int value_Mineral;
    public int mineralCost;

    //UI에 나타내기 위한 변수가 필요한가?
    public void MineralUp()
    {
        if(GameManager.instance.gold >= mineralCost)
        {
            value_Mineral += Mathf.RoundToInt(value_Mineral * 0.5f);
            //Mathf.RoundToInt : 소숫점 첫번째 자리에서 반올림 int형 반환
            mineralCost += Mathf.RoundToInt(mineralCost * 0.8f);
        }
    }

}
