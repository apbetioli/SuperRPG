using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class BattleManager : MonoBehaviour
{
    public Enemy[] enemies;
    public float waitTime = 0f;

    private Queue<Enemy> enemiesQueue = new Queue<Enemy>();
    [HideInInspector]
    public Enemy currentEnemy;
    private bool winner = false;

    private Player player;

    void Awake()
    {
        player = FindObjectOfType<Player>();
        if (player == null)
        {
            Debug.LogError("Player not found");
            this.enabled = false;
        }

        foreach (Enemy enemy in enemies)
            enemiesQueue.Enqueue(enemy);
    }

    internal void NextFloor()
    {

    }

    void Start()
    {
        player.inQuest = true;
        currentEnemy = enemiesQueue.Dequeue();
    }

    internal void GameOver()
    {
        player.Reborn();
    }

    public void Attack()
    {
        StartCoroutine(CoolDown());
    }

    internal bool HasPotionOfLife()
    {
        return player.HasPotionOfLife();
    }

    public void UseHealingPotion()
    {
        player.UseHealingPotion();
    }

    public bool PlayerWin()
    {
        return winner;
    }

    public bool PlayerDead()
    {
        winner = false;
        return player.IsDead();
    }

    IEnumerator CoolDown()
    {
        currentEnemy.TakeDamage(player.attack);

        if (enemiesQueue.Count == 0 && currentEnemy.IsDead())
        {
            winner = true;
            yield break;
        }

        if (enemiesQueue.Count > 0 && currentEnemy.IsDead())
        {
            currentEnemy = enemiesQueue.Dequeue();
            yield break;
        }

        yield return new WaitForSeconds(waitTime);

        player.TakeDamage(currentEnemy.damage);
    }

    public void Run()
    {
        player.inQuest = false;
    }
}
