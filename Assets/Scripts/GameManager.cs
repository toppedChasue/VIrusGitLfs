using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
                Destroy(this.gameObject);
        }
    }

    public int stage;
    public int gold;
    public int skillPoint;
    public float enemyKillCount;

    public Text goldTxt;
    public Text atkTxt;
    public Text skillTxt;
    public Text stageTxt;
    public Text bossTxt;

    public Image bossFillAmount;

    public Player player;
    public SpwanVirus spwanVirus;
    private void LateUpdate()
    {
        goldTxt.text = string.Format("{0:n0}", gold);
        skillTxt.text = string.Format("{0:n0}", skillPoint);
        atkTxt.text = string.Format("{0:n0}", player.bulletDamage);
        stageTxt.text = stage + "스테이지";
        bossTxt.text = enemyKillCount + " / " + spwanVirus.nextBoss;

        bossFillAmount.fillAmount = enemyKillCount / spwanVirus.nextBoss;
    }

}
