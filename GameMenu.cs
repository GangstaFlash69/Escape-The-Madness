using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public GameObject Player;
    PlayerMovement pm;
	MouseLook ml;
    public GameObject PauseMenu;
    public GameObject DeathScreen;
    public GameObject HUD;
    public string Level;
    public bool IsPaused = false;

    void Update()
    {
        if(Input.GetKey(KeyCode.Escape) && DeathScreen.activeInHierarchy == false)
        {
            if(IsPaused)
            ResumeGame();
            else PauseGame();
        }
        if(DeathScreen.activeInHierarchy && Input.GetKey(KeyCode.Space))
        {
            Restart();
        }
    }
    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        PauseMenu.SetActive(true);
        HUD.SetActive(false);
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        PauseMenu.SetActive(false);
        HUD.SetActive(true);
        Time.timeScale = 1f;
    }
    public void Restart()
    {
        SceneManager.LoadScene (Level);
        Time.timeScale = 1f;
    }

    public void GameOptions()
    {

    }
    public void MainGameMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene ("Scene0");
    }
}