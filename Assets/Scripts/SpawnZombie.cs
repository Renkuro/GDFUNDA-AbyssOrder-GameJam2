using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombie : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject z_norm;
    [SerializeField] private GameObject z_fast;
    [SerializeField] private GameObject z_boss;
    [SerializeField] private float spawn_interval;
    private float ticks = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        this.z_norm.SetActive(false);
        this.z_fast.SetActive(false);
        this.z_boss.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        this.ticks += Time.deltaTime;
        if (this.ticks >= spawn_interval)
        {
            this.ticks = 0.0f;
            int picker = Random.Range(0, 11);
            GameObject zombie;
            switch (picker)
            {
                case 0:
                    zombie = GameObject.Instantiate(this.z_fast, this.target.transform);
                    break;
                case 1:
                case 2:
                    zombie = GameObject.Instantiate(this.z_boss, this.target.transform);
                    break;
                default:
                    zombie = GameObject.Instantiate(this.z_norm, this.target.transform);
                    break;
            }
              
            zombie.SetActive(true);

            Vector3 pos = zombie.transform.localPosition;
            pos.z += Random.Range(-8.0f, 8.0f);
            zombie.transform.localPosition = pos;
        }
        
    }
}
