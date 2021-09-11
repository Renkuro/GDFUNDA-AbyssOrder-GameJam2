using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject player;
    private GameObject pauseTextBox;
    private GameObject pauseTextBox2;
    private GameObject pauseTextBox3;
    private GameObject resumeBtn;
    private int points;

    // Start is called before the first frame update
    void Start()
    {
        pauseTextBox = pausePanel.transform.Find("Pause_Text").gameObject;
        pauseTextBox2 = pausePanel.transform.Find("Pause_Text_Sub").gameObject;
        pauseTextBox3 = pausePanel.transform.Find("Pause_Text_Points").gameObject;
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
        gamePanel.SetActive(false);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        string death_msg = "ZOMBIFIED";
        string msg = "It was good while it lasted";
        points = int.Parse(gamePanel.transform.Find("Score_Value_Text").gameObject.GetComponent<UnityEngine.UI.Text>().text);
        string score_msg = "Final Score: " + points.ToString();
        pausePanel.SetActive(true);
        resumeBtn.SetActive(false);
        player.SetActive(false);
        pauseTextBox.GetComponent<UnityEngine.UI.Text>().text = death_msg;
        pauseTextBox2.GetComponent<UnityEngine.UI.Text>().text = msg;
        pauseTextBox3.GetComponent<UnityEngine.UI.Text>().text = score_msg;
    }
}
