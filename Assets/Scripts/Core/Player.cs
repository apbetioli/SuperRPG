using UnityEngine;
using System.Collections.Generic;
using System;

public class Player : MonoBehaviour
{
	public int maxHealth = 10;
	public int coins = 15;

	public Weapon weapon;
	public Shield shield;
    
	private int _health = 10;

	public int health
    {
        get { return _health; }
        set { _health = Mathf.Clamp(value, 0, maxHealth); }
    }

	public int defense
	{
		get { return shield.defense; }
	}

	public int damage
	{
		get { return weapon.damage; }
	}

	public void Reborn()
	{
		health = 10;
		maxHealth = 10;
		coins = 15;
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
