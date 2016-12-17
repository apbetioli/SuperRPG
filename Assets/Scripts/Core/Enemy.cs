using UnityEngine;

public class Enemy : MonoBehaviour
{
	public int damageMin;
	public int damageMax;
	public int defenseMin;
	public int defenseMax;
	public int coinsMin;
	public int coinsMax;
	public int healthMin;
	public int healthMax;
	public float probability = 1f;

	private int _health;

	public int damage { get; set; }
	public int defense { get; set; }
	public int coins { get; set; }
	public int health { 
		get { return _health; } 
		set { _health = Mathf.Max (value, 0); } 
	}

	public void Start ()
	{
		damage = Random.Range (damageMin, damageMax+1);
		defense = Random.Range (defenseMin, defenseMax+1);
		coins = Random.Range (coinsMin, coinsMax);
		health = Random.Range (healthMin, healthMax);
	}

	public void TakeDamage (int damage)
	{
		health -= damage;
	}

	public bool IsDead ()
	{
		return health <= 0;
	}
}
