using UnityEngine;
using UnityEngine.SceneManagement;

public class BasementQuestEnter : MonoBehaviour
{
    public void EnterQuest()
    {
        SceneManager.LoadScene("BasementQuest");
    }
}
