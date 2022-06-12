using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string NextLevel;
    public void StartGame()
    {
        SceneManager.LoadScene(NextLevel);
    }

    public void GameOptions()
    {
        
    }

    public void GameOptionsClosed()
    {
        
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quiting the Game...");
    }
}
