using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Miner : MonoBehaviour
{
    public int goldPower;
    protected int goldUPCost;
    protected int mineTimeDecreaseCost;

    public float currentTime;
    protected float mineTime;

    public Mineral mineral;

    //광부 스탯 관련변수
    public int minerUpCost;

    private void Start()
    {
        minerUpCost = 10;
        mineTimeDecreaseCost = 50;
        mineral = GameObject.Find("GoldPos").GetComponent<Mineral>();
    }

    protected virtual void Init()
    {
        goldPower = 1;
        mineTime = 10;
    }

    protected void DigGold(int value)
    {
        
        if (currentTime >= mineTime)
        {
            GameManager.instance.gold += (value + mineral.value_Mineral);
            Debug.Log("DigGold" + value);
            currentTime = 0;
        }
    }

    //광부의 체굴량(한번에 캐는 양) 증가(goldPower증가)
    public void GetGoldUP()
    {
        if (GameManager.instance.gold >= minerUpCost)
        {
            GameManager.instance.gold -= minerUpCost;

            goldPower += 10;
            Debug.Log(goldPower);
            minerUpCost += 10;
        }
 
    }

    //광부의 체굴속도 증가 (mineTime감소)
    public void MineTimeDecrese()
    {
        if (GameManager.instance.gold >= mineTimeDecreaseCost)
        {
            GameManager.instance.gold -= mineTimeDecreaseCost;
            mineTime -= mineTime * 0.00001f;
            mineTimeDecreaseCost += 50;
        }
    }
}
