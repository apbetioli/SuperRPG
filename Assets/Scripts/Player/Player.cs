using System;

public class Player {

	private int health = 100;

	private Weapon weapon = new Fist();
	private Shield shield = new NoShield();

	public void attack(Enemy enemy) {
		if (IsDead ())
			throw new Exception ("You should not try to attack when you're dead.");

		int damage = enemy.TakeDamage (weapon.Damage ());
		damage = Math.Max(0, damage - shield.Defense ());
		health -= damage;
	}

	public int GetHealth() {
		return health;
	}


	public bool IsDead() {
		return health <= 0;
	}

	public Weapon Weapon{
		get{
			return weapon;
		}

		set{ 
			weapon = value;
		}
	}

	public Shield Shield{
		get{
			return shield;
		}

		set{ 
			shield = value;
		}
	}
}

