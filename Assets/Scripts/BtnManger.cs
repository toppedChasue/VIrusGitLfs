using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnManger : MonoBehaviour
{
    //메인화면 UI
    public GameObject playerStats;
    public GameObject playerSkills;
    public GameObject playerTowers;
    public GameObject optionbtn;
    public GameObject optionUI;

    public GameObject gotoMineBtn;

    //광산화면 UI
    public GameObject minerStats;
    public GameObject minerSkills;

    //플레이어 스탯 관련 변수
    public Player player;
    private int speedUpGold;
    private int skillCost = 5;

    //총알 관련 변수
    GameObject bulletParent;
    private int BulletPowerUpGold;

    private void Awake()
    {
        speedUpGold = 50;
        BulletPowerUpGold = 100;
    }
    public void Start()
    {
       bulletParent = GameObject.Find("BulletParent");
    }

    //상태변수
    public bool isPlayerStats;
    public bool isPlayerSkill;
    public bool isPlayerTower;
    public bool isMinerStats;
    public bool isMinerSkill;
    public bool isOptionUi;

    public bool isMineOpen = false;

    //Player UI
    public void PlayerStatsUI()
    {
        if (!isPlayerStats)
        {
            isPlayerStats = true;
            if (playerSkills.activeSelf == true || playerTowers.activeSelf == true)
            {
                playerSkills.SetActive(false);
                isPlayerSkill = false;
                playerTowers.SetActive(false);
                isPlayerTower = false;
            }
            playerStats.SetActive(true);
        }
        else if (isPlayerStats)
        {
            playerStats.SetActive(false);
            isPlayerStats = false;
            isPlayerSkill = false;
            isPlayerTower = false;
        }
    }
    public void PlayerSkillsUI()
    {
        if (!isPlayerSkill)
        {
            isPlayerSkill = true;
            if(playerStats.activeSelf ==true || playerTowers.activeSelf == true)
            {
                playerStats.SetActive(false);
                isPlayerStats = false;
                playerTowers.SetActive(false);
                isPlayerTower = false;
            }
            playerSkills.SetActive(true);
        }

        else if (isPlayerSkill)
        {
            playerSkills.SetActive(false);
            isPlayerSkill = false;
            isPlayerStats = false;
            isPlayerTower = false;
        }
    }
    public void PlayerTowersUI()
    {
        if (!isPlayerTower)
        {
            isPlayerTower = true;
            if (playerStats.activeSelf == true || playerSkills.activeSelf == true)
            {
                playerStats.SetActive(false);
                isPlayerStats = false;
                playerSkills.SetActive(false);
                isPlayerSkill = false;
            }
            playerTowers.SetActive(true);
        }

        else if (isPlayerTower)
        {
            playerTowers.SetActive(false);
            isPlayerSkill = false;
            isPlayerStats = false;
            isPlayerTower = false;
        }
    }

    public void OptionUI()
    {
        if(!isOptionUi)
        {
            isOptionUi = true;
            optionUI.SetActive(true);
        }
        else if(isOptionUi)
        {
            isOptionUi = false;
            optionUI.SetActive(false);
        }
    }

    //Player Stats
    public void PowerUpBtn()
    {
        
        //나중에 특별한 재화로 바꾸자
        if (GameManager.instance.skillPoint >= skillCost && player.power <= 10)
        {
            player.power++;
            GameManager.instance.skillPoint -= skillCost;
            skillCost += skillCost * 2;
        }
        else
            return;
    }
    public void AtkSpeedUpBtn()
    {
        //눌럿을때 계속 올라가게끔
        int gold = 200;
        if (GameManager.instance.gold >= speedUpGold)
        {
            player.attacktTime -= 0.0005f;
            GameManager.instance.gold -= speedUpGold;
            speedUpGold += gold;
        }
        else
            return;
    }
    public void BulletSpeedUpBtn()
    {
        int gold = speedUpGold;
        if (GameManager.instance.gold >= gold)
        {
            player.bulletSpeed += 0.1f;
            GameManager.instance.gold -= gold;
            gold += gold + Mathf.RoundToInt(gold * 0.5f);
        }
        else
            return;
    }
    public void BulletPowerUpBtn()
    {
        if (GameManager.instance.gold >= BulletPowerUpGold)
        {
            player.bulletDamage++;
            GameManager.instance.gold -= BulletPowerUpGold;    
        }
        else
            return;
    }

    //Miner Ui
    public void MinerStatsUI()
    {
        if (!isMinerStats)
        {
            isMinerStats = true;
            if (minerSkills.activeSelf == true)
            {
                minerSkills.SetActive(false);
                isMinerSkill = false;
            }
            minerStats.SetActive(true);
        }
        else if (isMinerStats)
        {
            minerStats.SetActive(false);
            isMinerStats = false;
            isMinerSkill = false;
        }
    }
    public void MinerSkillsUI()
    {
        if (!isMinerSkill)
        {
            isMinerSkill = true;
            if (minerStats.activeSelf == true)
            {
                minerStats.SetActive(false);
                isMinerStats = false;
            }
            minerSkills.SetActive(true);
        }

        else if (isMinerSkill)
        {
            minerSkills.SetActive(false);
            isMinerSkill = false;
            isMinerStats = false;
        }
    }

    public void MineOpen()
    {
        int mineOpenCost = 100000;
        if (GameManager.instance.gold >= mineOpenCost && isMineOpen == false)
        {
            GameManager.instance.gold -= mineOpenCost;
            isMineOpen = true;
            gotoMineBtn.SetActive(true);
        }
        else
            return;
    }

}
