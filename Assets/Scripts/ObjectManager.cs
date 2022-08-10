using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public Transform bulletParent;
    public GameObject playerBulletPrefab;
    public GameObject TowerBulletPrefab;

    GameObject[] playerBullet;
    GameObject[] TowerBullet;

    GameObject[] targetPool;
    void Awake()
    {
        playerBullet = new GameObject[100];
        TowerBullet = new GameObject[60];

        Generate();
    }
    void Generate()
    {
        for (int index = 0; index < playerBullet.Length; index++)
        {
            playerBullet[index] = Instantiate(playerBulletPrefab);
            playerBullet[index].transform.SetParent(bulletParent.transform);
            playerBullet[index].SetActive(false);
        }
        for (int index = 0; index < TowerBullet.Length; index++)
        {
            TowerBullet[index] = Instantiate(TowerBulletPrefab);
            TowerBullet[index].transform.SetParent(bulletParent.transform);
            TowerBullet[index].SetActive(false);
        }
    }

    public GameObject MakeObj(string type)
    {
        switch (type)
        {
            case "Basic":
                targetPool = playerBullet;
                break;
            case "Tower":
                targetPool = TowerBullet;
                break;
        }

        for (int index = 0; index < targetPool.Length; index++)
        {
            if (!targetPool[index].activeSelf)
            {
                targetPool[index].SetActive(true);
                return targetPool[index];
            }
        }
        return null;
    }
}
