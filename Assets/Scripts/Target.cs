using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private float health;

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
            EventBroadcaster.Instance.PostEvent(EventNames.Game_Events.ADD_POINTS);
            Destroy(gameObject);
        }
    }
}
