using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private Player player;

    public void Awake()
    {
        player = FindObjectOfType<Player>();
        DontDestroyOnLoad(player);
    }

    public void LoadCharacter()
    {
        SceneManager.LoadScene("Character");
    }

    public void LoadBasement()
    {
        SceneManager.LoadScene("BasementQuestEnter");
    }

}
