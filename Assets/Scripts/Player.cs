using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxHealth = 100;
    public float stamina = 10;

    public Weapon weapon;
    public Shield shield;
    public Hat hat;

    private float _health;

    public float health
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

    public float attack
    {
        get
        {
            return weapon.attackValue;
        }
    }

    public float defense
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

    public float GetUsedStamina()
    {
        return weapon.stamina + shield.stamina + hat.stamina;
    }

    public bool CanEquipWeapon(Weapon weapon)
    {
        return GetUsedStamina() - this.weapon.stamina + weapon.stamina < stamina;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    public bool IsDead()
    {
        return health <= 0;
    }

    public void Heal(float healFactor)
    {
        health += maxHealth * healFactor;
    }

}
