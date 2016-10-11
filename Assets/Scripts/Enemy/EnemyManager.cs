using System.Collections.Generic;


public class EnemyManager {

	List<Enemy> enemies;

	public EnemyManager(System.Type enemy, int number) {
		enemies = new List<Enemy> ();
		for (int i = 0; i < number; i++)
			enemies.Add ((Enemy)System.Activator.CreateInstance(enemy));
	}

	public List<Enemy> GetEnemies(){
		return enemies;
	}

	public bool KillEnemy(Enemy enemy){
		return enemies.Remove (enemy);
	}

	public Enemy GetNextEnemy(){	
		if (!enemies.GetEnumerator ().MoveNext ())
			return null;
			
		if (enemies[0].GetHealth () <= 0)
			KillEnemy (enemies[0]);
		
		return enemies[0];
	}
}
