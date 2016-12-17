using UnityEngine;
using System.Collections.Generic;
using System;

public class Player : MonoBehaviour
{
	public int maxHealth = 10;
	public int coins = 15;
	public int damage = 1;
	public int defense = 0;
	public int floor = 0;
    
	private int _health = 10;

	public int health
    {
        get { return _health; }
        set { _health = Mathf.Clamp(value, 0, maxHealth); }
    }

	public void Reborn()
	{
		health = 10;
		maxHealth = 10;
		coins = 15;
		damage = 1;
		defense = 0;
		floor = 0;
	}
    
	public void TakeDamage(int damage)
    {
        health -= damage;
    }

    public bool IsDead()
    {
        return health <= 0;
    }

}
