using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private int points;

    //when zombie takes damage
    public void TakeDamage(float amount)
    {
        health -= amount;

        if(health <= 0f)
        {
            Die();
        }

        void Die()
        {
            Parameters param = new Parameters();
            param.PutExtra(EventNames.Game_Events.ZOMBIE_POINTS, points);
            EventBroadcaster.Instance.PostEvent(EventNames.Game_Events.ADD_POINTS, param);
            Destroy(gameObject);
        }
    }
}
