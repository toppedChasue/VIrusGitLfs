using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinerSpwan : MonoBehaviour
{
    public GameObject[] minerPos;
    public GameObject minerPrefab;

    public Button minerbtn;
    public Image minerBtnImg;

    private int minerCount;
    private int minerCost;

    public GameManager gameManager;
    private void Update()
    {
        MinerCheck();
    }
    public void SpwanMiner()
    {
        minerCost = 200;
        if(gameManager.gold >= minerCost)
        {
            switch (minerCount)
            {
                case 0:
                    Mine obj = Instantiate(minerPrefab, minerPos[0].transform.position, Quaternion.identity).GetComponent<Mine>();
                    obj.transform.SetParent(minerPos[0].transform);
                    minerCount++;
                    minerCost += minerCost * 5;
                    break;
                case 1:
                    Mine obj1 =Instantiate(minerPrefab, minerPos[1].transform.position, Quaternion.identity).GetComponent<Mine>();
                    obj1.transform.SetParent(minerPos[1].transform);
                    minerCount++;
                    minerCost += minerCost * 10;
                    break;
                case 2:
                    Mine obj2 = Instantiate(minerPrefab, minerPos[2].transform.position, Quaternion.identity).GetComponent<Mine>();
                    obj2.transform.SetParent(minerPos[2].transform);
                    minerCount++;
                    break;
                case 3:
                    return;
            }
        }

    }

    private void MinerCheck()
    {
        if (minerCount >= 3)
        {
            minerBtnImg.color = new Color32(80, 80, 80, 255);
            minerbtn.enabled = false;
        }
    }
}
