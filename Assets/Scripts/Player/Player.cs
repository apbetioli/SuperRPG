using System;

public class Player
{
	private float health = 100f;
	private float maxHealth = 100f;
	private float healPercentage = 2f;

	private Weapon weapon = new Fist ();
	private Shield shield = new NoShield ();

	public void Attack (Enemy enemy)
	{
		if (IsDead ())
			throw new Exception ("You should not try to attack when you're dead.");

		int damage = enemy.TakeDamage (weapon.Damage ());
		TakeDamage (damage);
	}

	public void TakeDamage (int damage)
	{
		Health -= Math.Max (0, damage - shield.Defense ());
	}

	public bool IsDead ()
	{
		return Health == 0;
	}

	public void Heal ()
	{
		Health += maxHealth * healPercentage / 100f;
	}

	public Weapon Weapon {
		get {
			return weapon;
		}

		set { 
			weapon = value;
		}
	}

	public Shield Shield {
		get {
			return shield;
		}

		set { 
			shield = value;
		}
	}

	public float Health {
		get { 
			return health;
		}
		private set {
			health = Math.Max (Math.Min (maxHealth, value), 0);
		}
	}

}

