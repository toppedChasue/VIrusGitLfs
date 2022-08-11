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

    //광산화면 UI
    public GameObject minerStats;
    public GameObject minerSkills;

    //플레이어 스탯 관련 변수
    public Player player;
    private int powerUpGold;
    private int speedUpGold;

    //총알 관련 변수
    GameObject bulletParent;
    private int BulletPowerUpGold;

    private void Awake()
    {
        powerUpGold = 1000;
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

    //Player Stats
    public void PowerUpBtn()
    {
        //나중에 스킬 포인트로 바꾸자
        if (GameManager.instance.gold >= powerUpGold && player.power <= 10)
        {
            player.power++;
            GameManager.instance.gold -= powerUpGold;
            powerUpGold += powerUpGold;
        }
        else
            return;
    }
    public void AtkSpeedUpBtn()
    {
        int gold = 200;
        if (GameManager.instance.gold >= speedUpGold)
        {
            player.attacktTime -= 0.01f;
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
        int plusGold = 100;
        if (GameManager.instance.gold >= BulletPowerUpGold)
        {
            player.bulletDamage++;
            GameManager.instance.gold -= BulletPowerUpGold;
            BulletPowerUpGold += plusGold;
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

}
