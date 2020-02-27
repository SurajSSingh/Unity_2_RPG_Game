using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public int mainMenuNumber;
    public int gameLevelNumber;

    public void GoToGame()
    {
        SceneManager.LoadScene(gameLevelNumber);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(mainMenuNumber);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadGame()
    {
        // TO DO NEXT WEEK
    }
}
