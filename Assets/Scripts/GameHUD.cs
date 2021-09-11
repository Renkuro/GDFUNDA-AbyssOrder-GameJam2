using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHUD : MonoBehaviour
{
    [SerializeField] private GameObject scoreVal;
    [SerializeField] private GameObject lifeVal;

    // Start is called before the first frame update
    void Start()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.Game_Events.ADD_POINTS, this.addPointsEvent);
        EventBroadcaster.Instance.AddObserver(EventNames.Game_Events.REDUCE_LIFE, this.removeLivesEvent);
    }

    void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.Game_Events.ADD_POINTS);
        EventBroadcaster.Instance.RemoveObserver(EventNames.Game_Events.REDUCE_LIFE);
    }

    //add points when player kills zombie
    void addPointsEvent (Parameters param)
    {
        int pts_add = param.GetIntExtra(EventNames.Game_Events.ZOMBIE_POINTS, 100);
        int pts = int.Parse(scoreVal.GetComponent<UnityEngine.UI.Text>().text);
        pts = pts + pts_add;
        scoreVal.GetComponent<UnityEngine.UI.Text>().text = pts.ToString();

    }

    //remove lives when zombie reaches house
    void removeLivesEvent ()
    {
        int hp = int.Parse(lifeVal.GetComponent<UnityEngine.UI.Text>().text);
        hp = hp - 1;
        print("HP " + hp.ToString());
        if (hp == 0)
        {
            print("nice");
            EventBroadcaster.Instance.PostEvent(EventNames.Game_Events.DEATH_SCREEN);

        }
            
        lifeVal.GetComponent<UnityEngine.UI.Text>().text = hp.ToString();

    }
}
