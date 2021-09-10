using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject gamePanel;
    private GameObject pauseTextBox;
    private GameObject pauseTextBox2;
    private GameObject resumeBtn;

    // Start is called before the first frame update
    void Start()
    {
        pauseTextBox = pausePanel.transform.Find("Pause_Text").gameObject;
        pauseTextBox2 = pausePanel.transform.Find("Pause_Text_Sub").gameObject;
        resumeBtn = pausePanel.transform.Find("Resume_Btn").gameObject;
        EventBroadcaster.Instance.AddObserver(EventNames.Game_Events.DEATH_SCREEN, this.displayDeathEvent);
    }

    // Update is called once per frame
    void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.Game_Events.DEATH_SCREEN);
    }

    //displays death screen when player dies
    private void displayDeathEvent ()
    {
        print("death");
        Time.timeScale = 0;
        string death_msg = "ZOMBIFIED";
        string msg = "It was good while it lasted";
        pausePanel.SetActive(true);
        resumeBtn.SetActive(false);
        gamePanel.SetActive(false);
        pauseTextBox.GetComponent<UnityEngine.UI.Text>().text = death_msg;
        pauseTextBox2.GetComponent<UnityEngine.UI.Text>().text = msg;
    }
}
