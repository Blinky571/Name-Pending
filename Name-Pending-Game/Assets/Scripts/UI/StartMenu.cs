using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public string _gameScene;
    public void PlayGame()
    {
        SceneManager.LoadScene(_gameScene);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
