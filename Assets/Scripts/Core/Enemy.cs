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

	public GameObject modelPrefab;

	private int _health;
	[HideInInspector]
	public int maxHealth;

	public int damage { get; set; }

	public int defense { get; set; }

	public int coins { get; set; }

	public int health { 
		get { return _health; } 
		set { _health = Mathf.Max (value, 0); } 
	}

	public void Start ()
	{
		damage = Random.Range (damageMin, damageMax + 1);
		defense = Random.Range (defenseMin, defenseMax + 1);
		coins = Random.Range (coinsMin, coinsMax + 1);
		health = Random.Range (healthMin, healthMax + 1);
		maxHealth = health;
	}

	public void TakeDamage (int damage)
	{
		health = Mathf.Min (health, health - damage + defense);
	}

	public bool IsDead ()
	{
		return health <= 0;
	}

	public void InstantiateModel() 
	{
		if (modelPrefab != null) {
			GameObject instance = GameObject.Instantiate (modelPrefab);
			instance.transform.SetParent (transform);
			instance.transform.localRotation = Quaternion.Euler (new Vector3 (90, 0, 0));
			instance.transform.localScale = new Vector3 (20, 20, 20);
		}
	}

}
