using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public BtnManger btnManager;

    public Text bulletAtkGold;
    public Text bulletSpeedGold;
    public Text atkSpeedGold;
    public Text openMineGold;
    public Text powerSkillPoint;

    // Update is called once per frame
    void LateUpdate()
    {
        powerSkillPoint.text = btnManager.skillCost.ToString();
        bulletSpeedGold.text = btnManager.bulletSpeedUpCost.ToString();
        openMineGold.text = btnManager.mineOpenCost.ToString();
    }
}
