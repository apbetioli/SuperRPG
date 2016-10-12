using System.Collections;

public class Enemy : Killable {

	private int health;
	private int attack;
	private int defense;

	public Enemy(int health, int attack, int defense) {
		this.health = health;
		this.attack = attack;
		this.defense = defense;
	}

	public int TakeDamage(int damage){
		health -= damage - defense;

		if (health <= 0)
			return 0;

		return attack;		
	}

	public int GetHealth() {
		return health;
	}

}
