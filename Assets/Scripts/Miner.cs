using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miner : MonoBehaviour
{
    protected int goldPower;
    protected int goldUPCost;
    protected int mineTimeDecreaseCost;
    
    protected float currentTime;
    protected float mineTime;

    public Mineral mineral;

    void Update()
    {
        currentTime += Time.deltaTime;
        mineral = GameObject.Find("GoldPos").GetComponent<Mineral>();
    }

    private void OnEnable()
    {
        DigGold();
    }

    protected virtual void Init()
    {
        goldPower = 1;
        goldUPCost = 20;
        mineTime = 10;
        mineTimeDecreaseCost = 50;
    }


    private void DigGold()
    {
        if (currentTime > mineTime)
        {
            GameManager.instance.gold += (goldPower + mineral.value_Mineral);
            currentTime = 0;
        }
    }
    //광부의 체굴량(한번에 캐는 양) 증가(goldPower증가)
    public void GetGoldUP()
    {
        if (GameManager.instance.gold >= goldUPCost)
        {
            goldPower += goldPower + goldPower;
            goldUPCost += goldUPCost;
        }
    }

    //광부의 체굴속도 증가 (mineTime감소)
    public void MineTimeDecrese()
    {
        if (GameManager.instance.gold >= mineTimeDecreaseCost)
        {
            mineTime -= mineTime * 0.00001f;
            mineTimeDecreaseCost += mineTimeDecreaseCost;
        }
    }
}
