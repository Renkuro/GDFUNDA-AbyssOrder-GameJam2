using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed;
    private Rigidbody rig;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
        rig.MovePosition(pos);
    }

    //destory zombie when it reaches house killbox
    void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "Killbox")
        {
            Destroy(gameObject);
            EventBroadcaster.Instance.PostEvent(EventNames.Game_Events.REDUCE_LIFE);
        }
    }
}
