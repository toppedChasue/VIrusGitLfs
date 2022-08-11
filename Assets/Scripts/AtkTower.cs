using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkTower : Tower
{
    public void Awake()
    {
        spwanVirus = GameObject.FindObjectOfType<SpwanVirus>().GetComponent<SpwanVirus>();
    }
}
