using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;

public class Menu : MonoBehaviour
{
 
    public void StartGame()
    {
        SceneManager.LoadScene ("Load");
    }
    public void Exit()
    {
		Debug.Log("Fechar jogo!");
        Application.Quit();
    }

	 public void Credits()
    {
		Debug.Log("Creditos!");
    }
}