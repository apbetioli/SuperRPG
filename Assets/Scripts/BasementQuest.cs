﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BasementQuest : MonoBehaviour
{

    private BattleManager manager;

    void Awake()
    {
		manager = FindObjectOfType<BattleManager>();
    }

    void Start()
    {
        SceneManager.LoadScene("HUD", LoadSceneMode.Additive);
    }

    void OnGUI()
    {
        if (manager.PlayerWin())
        {
            GUI.Label(new Rect(0, 0, 500, 20), "You win!");
            return;
        }
        if (manager.PlayerDead())
        {
            GUI.Label(new Rect(0, 0, 500, 20), "You loose!");
            return;
        }
    }


    public void Attack()
    {
        manager.Attack();
    }

    public void OpenBag()
    {
        Debug.Log("Open the bag!");
    }

    public void Run()
    {
        SceneManager.LoadScene("BasementQuestEnter");
    }
}
