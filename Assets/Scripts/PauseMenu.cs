using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject player;
    private bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
        player.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused == true)
            {
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;               
                panel.SetActive(false);
                player.SetActive(true);
                isPaused = false;
            }
            else
            {
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;               
                panel.SetActive(true);
                player.SetActive(false);
                isPaused = true;
            }
        }
    }
}
