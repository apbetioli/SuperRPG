using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleManager : MonoBehaviour
{

    public Enemy[] enemies;
	public float waitTime = 0f;
	
    private Queue<Enemy> enemiesQueue = new Queue<Enemy>();
    private Enemy currentEnemy;
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
        currentEnemy = enemiesQueue.Dequeue();
        Debug.Log("Quest iniciada");
        Debug.Log("Player health: " + player.health);
        Debug.Log("Enemy health: " + currentEnemy.health);
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
        Debug.Log("Wait x1: " + Time.time);
        currentEnemy.TakeDamage(player.attack);
        Debug.Log("Enemy health: " + currentEnemy.health);

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

        Debug.Log("Wait x2: " + Time.time);
        player.TakeDamage(currentEnemy.attack);
        Debug.Log("Player health: " + player.health);
    }

}
