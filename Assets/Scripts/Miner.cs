using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miner : MonoBehaviour
{
    public int goldPower;
    public int goldUPCost;
    public int mineTimeDecreaseCost;

    public float currentTime;
    public float mineTime;

    void Update()
    {
        currentTime += Time.deltaTime;
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
            GameManager.instance.gold += goldPower;
            currentTime = 0;
        }
    }
    //±¤ºÎÀÇ Ã¼±¼·® Áõ°¡(goldPowerÁõ°¡)
    public void GetGoldUP()
    {
        if (GameManager.instance.gold >= goldUPCost)
        {
            goldPower += goldPower + goldPower;
            goldUPCost += goldUPCost;
        }
    }

    //±¤ºÎÀÇ Ã¼±¼¼Óµµ Áõ°¡ (mineTime°¨¼Ò)
    public void MineTimeDecrese()
    {
        if (GameManager.instance.gold >= mineTimeDecreaseCost)
        {
            mineTime -= mineTime * 0.00001f;
            mineTimeDecreaseCost += mineTimeDecreaseCost;
        }
    }
}
