using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform mineCameraPos;
    public Transform CameraOriginPos;
    
    public float speed;

    public bool isMoveToMine = false;
    public bool isMoveToMain = false;

    public GameObject goToMineBtn;
    public GameObject goToMainBtn;

    public GameObject mainUIGroup;
    public GameObject mineUIGroup;

    [SerializeField]
    private BtnManger btnManger;

    // Update is called once per frame
    void Update()
    {
        if(isMoveToMine)
        {
            transform.position = Vector3.MoveTowards(transform.position, mineCameraPos.position, Time.deltaTime * speed);
            if (transform.position == mineCameraPos.position)
                isMoveToMine = false;

            if(btnManger.playerStats.activeSelf == true || btnManger.playerSkills.activeSelf == true)
            {
                btnManger.playerStats.SetActive(false);
                btnManger.playerSkills.SetActive(false);
                btnManger.isPlayerStats = false;
                btnManger.isPlayerSkill = false;
            }
        }

        if (isMoveToMain)
        {
            transform.position = Vector3.MoveTowards(transform.position, CameraOriginPos.position, Time.deltaTime * speed);
            if (transform.position == CameraOriginPos.position)
                isMoveToMain = false;

            if (btnManger.minerStats.activeSelf == true || btnManger.minerSkills.activeSelf == true)
            {
                btnManger.minerStats.SetActive(false);
                btnManger.minerSkills.SetActive(false);
                btnManger.isMinerStats = false;
                btnManger.isMinerSkill = false;
            }
        }

    }

    public void GoToMineBtn()
    {
        isMoveToMine = true;
        goToMineBtn.SetActive(false);
        mainUIGroup.SetActive(false);
        goToMainBtn.SetActive(true);
        mineUIGroup.SetActive(true);
    }
    public void GotoMainBtn()
    {
        isMoveToMain = true;
        goToMineBtn.SetActive(true);
        mainUIGroup.SetActive(true);
        goToMainBtn.SetActive(false);
        mineUIGroup.SetActive(false);
    }
}
