﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Transform[] points;
    public GameObject enemy;
    public float createTime = 2.0f;
    public int maxEnemy = 10;
    public bool isGameOver = false;



    // Start is called before the first frame update
    void Start()
    {
        points = GameObject.Find("SpawnPointGroup").GetComponentsInChildren<Transform>();
        if (points.Length > 0)
        {
            StartCoroutine(this.CreateEnemy());
        }

    }
   


    IEnumerator CreateEnemy()
    {
        while (!isGameOver)
        {
            int enemyCount = (int)GameObject.FindGameObjectsWithTag("ENEMY").Length;
            if (enemyCount < maxEnemy)
            {
                yield return new WaitForSeconds(createTime);
                int idx = Random.Range(1, points.Length);
                Instantiate(enemy, points[idx].position, points[idx].rotation);
            }
            else
            {
                yield return null;
            }
        }
    }

    //void LoadGameData()
    //{
    //    killCount = PlayerPrefs.GetInt("KILL_COUNT", 0);
    //    KillCountTxt.text = "KILL " + killCount.ToString("0000");
    //}

    //public void IncKillCount()
    //{
    //    ++killCount;
    //    KillCountTxt.text = "KILL " + killCount.ToString("0000");
    //    PlayerPrefs.SetInt("KILL_COUNT", killCount);
    //}
}
