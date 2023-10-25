using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwerScript : MonoBehaviour
{
    public GameObject projectile;
    public float speed;
    private float timer;
    public bool noZombie;
    void Start()
    {

    }

    void Update()
    {
        if (ZombieSpawner.numberOfEnemiesLeftScreen == 0)
        {
            noZombie = true;
        }
        else
        {
            noZombie = false;
        }
        if (noZombie == false)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Instantiate(projectile, transform.position, Quaternion.identity);
                timer = speed;
            }
        }
    }
}
