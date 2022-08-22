using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnManger : MonoBehaviour
{
    //����ȭ�� UI
    public GameObject playerStats;
    public GameObject playerSkills;
    public GameObject playerTowers;
    public GameObject optionbtn;
    public GameObject optionUI;

    public GameObject gotoMineBtn;

    public Button mineOpenBtn;
    public Image mineOpenImg;

    //����ȭ�� UI
    public GameObject minerStats;
    public GameObject minerSkills;

    //�÷��̾� ���� ���� ����
    public Player player;
    public int bulletSpeedUpCost;
    public int atkSpeedUpCost;
    public int skillCost;

    //�Ѿ� ���� ����
    public int BulletPowerUpCost;


    public int mineOpenCost;

    //�ʿ��� �ؽ�Ʈ�� ����������
    //�ؽ�Ʈ�� ��� ������Ʈ �Ǿ����
    //������ �ִ� �� >= ���
    //��� += �󸶳� �÷����ϴ°�?
    //����� cost�� ǥ���ϰ�

    //���ʿ� ����� ��ư�� �Ѱ� ���°ŷ� �߾���ߴ�
    //������ ���� ��ũ��Ʈ ���� �����߾����
    //���߿� �ٽ� �Űܾ߰ڴ�.


    private void Awake()
    {
        bulletSpeedUpCost = 50;
        atkSpeedUpCost = 50;
        BulletPowerUpCost = 100;
        mineOpenCost = 100000;
    }
    public void Start()
    {
    }

    //���º���
    public bool isPlayerStats;
    public bool isPlayerSkill;
    public bool isPlayerTower;
    public bool isMinerStats;
    public bool isMinerSkill;
    public bool isOptionUi;

    public bool isMineOpen = false;

    public bool action;

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
            if (playerStats.activeSelf == true || playerTowers.activeSelf == true)
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
        if (!isOptionUi)
        {
            isOptionUi = true;
            optionUI.SetActive(true);
        }
        else if (isOptionUi)
        {
            isOptionUi = false;
            optionUI.SetActive(false);
        }
    }


    //Player Stats
    public void PowerUpBtn()
    {
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
        //�������� ��� �ö󰡰Բ�
        int gold = 200;
        if (GameManager.instance.gold >= atkSpeedUpCost)
        {
            player.attacktTime -= 0.0005f;
            GameManager.instance.gold -= atkSpeedUpCost;
            atkSpeedUpCost += gold;
        }
        else
            return;
    }
    public void BulletSpeedUpBtn()
    {
        int gold = bulletSpeedUpCost;

        if (GameManager.instance.gold >= gold)
        {
            player.bulletSpeed += 0.1f;
            GameManager.instance.gold -= gold;
            bulletSpeedUpCost += gold + Mathf.RoundToInt(gold * 0.5f);
        }
        else
            return;
    }
    public void BulletPowerUpBtn()
    {
        if (GameManager.instance.gold >= BulletPowerUpCost)
        {
            player.bulletDamage++;
            GameManager.instance.gold -= BulletPowerUpCost;
            BulletPowerUpCost += 10;
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

        if (GameManager.instance.gold >= mineOpenCost && isMineOpen == false)
        {
            GameManager.instance.gold -= mineOpenCost;
            isMineOpen = true;
            gotoMineBtn.SetActive(true);

            mineOpenImg.color = new Color32(80, 80, 80, 255);
            mineOpenImg.transform.SetAsLastSibling();
            mineOpenBtn.enabled = false;
           
        }
        else
            return;
    }
}
