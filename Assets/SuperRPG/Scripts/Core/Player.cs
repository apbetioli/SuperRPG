using UnityEngine;
using System.Collections.Generic;
using System;

public class Player : MonoBehaviour
{
	public int maxHealth = 100;
	public int stamina = 10;

    public Weapon weapon;
    public Shield shield;
    public Hat hat;

    public Queue<SmallHealingPotion> lifePotions = new Queue<SmallHealingPotion>();

    public bool inQuest = false;

	private int _health;

	public int health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = Mathf.Clamp(value, 0, maxHealth);
        }
    }

    public int attack
    {
        get
        {
            return weapon.attackValue;
        }
    }

	public int defense
    {
        get
        {
            return shield.defenseValue;
        }
    }

    void Start()
    {
        health = maxHealth;
    }

	public int GetUsedStamina()
    {
        return weapon.stamina + shield.stamina + hat.stamina;
    }

    internal void Reborn()
    {
        health = maxHealth;
        Debug.Log("reborn " + (this.gameObject.GetComponent<Weapon>() != weapon));
        if(this.gameObject.GetComponent<Weapon>() != weapon)
            Destroy(weapon.gameObject);            
        weapon = this.gameObject.GetComponent<Weapon>();
    }

    internal bool HasPotionOfLife()
    {
        return lifePotions.Count > 0;
    }

    public bool CanEquipWeapon(Weapon weapon)
    {
        return GetUsedStamina() - this.weapon.stamina + weapon.stamina < stamina;
    }

	public void TakeDamage(int damage)
    {
        health -= damage;
    }

    public bool IsDead()
    {
        return health <= 0;
    }

	public void Heal(float healFactor)
    {
        if (!inQuest)
			health += Mathf.RoundToInt(maxHealth * healFactor);
    }

    public void UseHealingPotion()
    {
        if (HasPotionOfLife())
            this.health += lifePotions.Dequeue().healingRecovery;
    }

}
