using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BasementQuest : MonoBehaviour
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
            return;
        }
        if (manager.PlayerDead())
        {
            GUI.Label(new Rect(0, 0, 500, 20), "You loose!");
            return;
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
        manager.Run();
        SceneManager.LoadScene("Main");
    }
}
