using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButtons : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject game_panel;
    [SerializeField] private GameObject player;

    public void backToMenu()
    {
        SceneManager.LoadScene(0);
        
    }

    public void restartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void resumeGame()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        panel.SetActive(false);
        game_panel.SetActive(true);
        player.SetActive(true);
    }
}
