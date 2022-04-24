using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public GameObject PauseMenu;
    public Timer timer;

public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Game()
    {
        SceneManager.LoadScene("Game");
    }
    public void Quit()
    {
        Application.Quit();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu.SetActive(true);
            timer.StopTimer();
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
