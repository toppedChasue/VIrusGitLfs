using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : Miner
{
    private void Awake()
    {
        Init();
    }


    private void Update()
    {
        currentTime += Time.deltaTime;
        DigGold(goldPower);
        Debug.Log(goldPower);
    }
    protected override void Init()
    {
        base.Init();
    }
}
