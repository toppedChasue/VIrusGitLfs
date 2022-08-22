using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public BtnManger btnManager;

    //Plyer
    public Text bulletAtkCost;
    public Text atkSpeedCost;
    public Text bulletSpeedCost;
    public Text openMineCost;
    public Text powerSkillCost;

    //Miner
    public Text spwanMinerCost;
    public Text getGoldUpCost;
    public Text goldSpeedCost;
    public Text mineralUPCost;

    // Update is called once per frame
    void LateUpdate()
    {
        //Player UI Text
        bulletAtkCost.text = btnManager.BulletPowerUpCost.ToString();
        atkSpeedCost.text = btnManager.atkSpeedUpCost.ToString();
        bulletSpeedCost.text = btnManager.bulletSpeedUpCost.ToString();
        openMineCost.text = btnManager.mineOpenCost.ToString();
        powerSkillCost.text = btnManager.skillCost.ToString();


    }
}
