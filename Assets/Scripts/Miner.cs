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

    //���� ���� ���ú���
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

    //������ ü����(�ѹ��� ĳ�� ��) ����(goldPower����)
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

    //������ ü���ӵ� ���� (mineTime����)
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
