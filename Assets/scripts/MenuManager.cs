using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("LevelSelect");
        //Debug.Log(SceneManager.GetSceneByName("LevelSelect").name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackHome()
    {
        SceneManager.LoadScene("Menu");
    }

    public void GotoLevelOne()
    {
        SceneManager.LoadScene("level1");
    }

    public void GoNext()
    {
        //TODO: build settings??scenes index??????
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BackPrevious()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
