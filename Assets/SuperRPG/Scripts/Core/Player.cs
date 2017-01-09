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

    public static Player Instance
    {
        get
        {
            Player player = FindObjectOfType<Player>();
            if (player == null)
                Debug.LogError("Player not found");
            return player;
        }
    }

    public void TakeDamage(int damage)
    {
        health = Mathf.Min(health, health - damage + defense);
    }

    public bool IsDead()
    {
        return health <= 0;
    }

    public void DoEquip(Item item)
    {
        if (item.price > coins)
        {
            Debug.Log("Not enough money");
            //FloatingTextController.CreateFloatingText2("Not enough money", item.transform);
            return;
        }

		if (weapon.name.Equals(item.name))
        {
            Debug.Log("Already have weapon");
            //FloatingTextController.CreateFloatingText2("Already have weapon", item.transform);
            return;
        }

		if (shield.name.Equals(item.name))
        {
            Debug.Log("Already have shield");
           // FloatingTextController.CreateFloatingText2("Already have shield", item.transform);
            return;
        }

        maxHealth += item.maxHp;

        if (item.hp > 0 && health == maxHealth)
        {
            Debug.Log("Too much health");
           // FloatingTextController.CreateFloatingText2("Too much health", item.transform);
            return;
        }

        health += item.hp;

        coins -= item.price;

      //  FloatingTextController.CreateFloatingText(item.price.ToString(), item.transform);

        if (item.GetType() == typeof(Weapon))
            weapon = item as Weapon;

        if (item.GetType() == typeof(Shield))
            shield = item as Shield;
    }
}
