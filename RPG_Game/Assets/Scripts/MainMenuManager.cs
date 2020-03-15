using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using RPGM.Gameplay;

public class MainMenuManager : MonoBehaviour
{
    public int mainMenuNumber;
    public int gameLevelNumber;
    

    void Awake()
    {
        if (!PlayerPrefs.HasKey("loadLevel"))
        {
            PlayerPrefs.SetInt("loadLevel", 0);
        }
    }

    public void GoToGame()
    {
        PlayerPrefs.SetInt("loadLevel", 0);
        SceneManager.LoadScene(gameLevelNumber);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(mainMenuNumber);
    }

    public void QuitGame()
    {
        PlayerPrefs.DeleteKey("loadLevel");
        Application.Quit();
    }

    public void LoadGame()
    {
        PlayerPrefs.SetInt("loadLevel", 1);
        SceneManager.LoadScene(gameLevelNumber);
    }
}
