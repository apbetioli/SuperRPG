using System;

public class Character {

	private int health = 100;

	public Weapon weapon = new Fist();
	public Shield shield = new NoShield();

	public void attack(Enemy enemy) {
		int damage = enemy.TakeDamage (weapon.Damage ());
		damage = Math.Max(0, damage - shield.Defense ());
		health -= damage;
	}

	public int GetHealth() {
		return health;
	}

}

