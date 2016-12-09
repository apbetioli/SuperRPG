using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
	
    void Start()
    {
        player.inQuest = true;
        currentEnemy = enemiesQueue.Dequeue();
    }

    public void Attack()
    {
        StartCoroutine(CoolDown());
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

        player.TakeDamage(currentEnemy.attack);
    }

    public void Run() {
        player.inQuest = false;
    }
}
