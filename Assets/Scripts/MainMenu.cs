using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene(1);
    }

    public void exitGame()
    {
        Debug.Log("App Exit");
        Application.Quit();
    }

    public void openTutorial()
    {
        SceneManager.LoadScene(2);
    }

    public void openCredits()
    {
        SceneManager.LoadScene(3);
    }
}
