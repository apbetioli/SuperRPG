using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Battle : MonoBehaviour
{
    public Text currentEnemyHealth;

    private BattleManager manager;

    void Awake()
    {
        manager = FindObjectOfType<BattleManager>();
    }

    void Start()
    {
        SceneManager.LoadSceneAsync("HUD", LoadSceneMode.Additive);
    }

    void OnGUI()
    {
        if (manager.currentEnemy != null)
            currentEnemyHealth.text = "Current enemy health: " + manager.currentEnemy.health;

        if (manager.PlayerWin())
        {
            GUI.Label(new Rect(0, 0, 500, 20), "You win!");
            manager.NextFloor();
            Run();
        }
        if (manager.PlayerDead())
        {
            GUI.Label(new Rect(0, 0, 500, 20), "You loose!");
            manager.GameOver();
            Run();
        }

    }


    public void Attack()
    {
        manager.Attack();
    }

    public void UseHealingPotion()
    {
        manager.UseHealingPotion();
    }

    public void Run()
    {
        manager.GameOver();
        manager.Run();
        SceneManager.LoadScene("Main_Shop");
    }
}
