using UnityEngine;
using UnityEngine.UI;

public class Battle : MonoBehaviour
{
	public Text currentEnemyText;
	public Text turnText;

	private BattleManager manager;

	void Awake ()
	{
		manager = FindObjectOfType<BattleManager> ();
	}

	void OnGUI ()
	{
		if (manager.currentEnemy != null)
			currentEnemyText.text = "Enemy: " + manager.currentEnemy.name
			+ " damage:" + manager.currentEnemy.damage
			+ " defense:" + manager.currentEnemy.defense
			+ " coins:" + manager.currentEnemy.coins
			+ " health:" + manager.currentEnemy.health;

		turnText.text = manager.GetTurnDescription ();
	}

	public void Attack ()
	{
		manager.Attack ();
	}

	public void Run ()
	{
		GameManager.GameOver ();
	}
}
