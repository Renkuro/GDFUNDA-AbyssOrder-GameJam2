using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButtons : MonoBehaviour
{

    public void backToMenu()
    {
        SceneManager.LoadScene(0);
        
    }

    public void restartGame()
    {
        SceneManager.LoadScene(1);
    }
}
