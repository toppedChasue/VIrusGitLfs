using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mineral : MonoBehaviour
{
    public GameObject mineral;

    public int value_Mineral;

    public int mineraCost;

    //미네랄을 업그레이드 할때마다 광부들이 캐는 양에 더해줘야지
    public void MineralUp()
    {
        value_Mineral += value_Mineral * (int) 0.5f;
    }

}
