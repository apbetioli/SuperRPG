using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    public float attack;
    private float defense;
    public float health;

    public Enemy(float attack, int health)
    {
        this.attack = attack;
        this.health = health;
        this.defense = 0;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    public bool IsDead()
    {
        return health <= 0;
    }
}
