using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTrigger : MonoBehaviour
{
    public bool noZombie;
    public GameObject peaBullet;
    public GameObject frozenBullet;
    public GameObject burningBullet;
    public GameObject sun;
    public float timer1;
    public float timer2;
    public float reloadSpeed;
    public bool isOnFire;
    public bool isFrozen;
    public bool isSunflower;
    public bool justSummonedSun;
    public bool justSummonedPea;
    void Start()
    {
        
    }

    void Update()
    {
        if (isSunflower == false)
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
                timer1 -= Time.deltaTime;
                if (timer1 <= 1.2 && timer1 >= 1.1)
                {
                    justSummonedPea = true;
                }
                if (timer1 <= 0)
                {
                    if (isFrozen == false && isOnFire == false)
                    {
                        SoundManager.instance.peaShoot.Play();
                        Instantiate(peaBullet, transform.position, transform.rotation);
                        timer1 = reloadSpeed;
                    }
                    if (isFrozen == true && isOnFire == false)
                    {
                        SoundManager.instance.frozenpea.Play();
                        Instantiate(frozenBullet, transform.position, transform.rotation);
                        timer1 = reloadSpeed;
                    }
                    if (isFrozen == false && isOnFire == true)
                    {
                        SoundManager.instance.firepea.Play();
                        Instantiate(burningBullet, transform.position, transform.rotation);
                        timer1 = reloadSpeed;
                    }
                    if (isFrozen == true && isOnFire == true)
                    {
                        SoundManager.instance.peaShoot.Play();
                        Instantiate(peaBullet, transform.position, transform.rotation);
                        timer1 = reloadSpeed;
                    }
                }
            }
        }
        else
        {
            timer2 -= Time.deltaTime;
            if (timer2 <= Random.Range(-3, 0))
            {
                Instantiate(sun, transform.position, transform.rotation);
                timer2 = reloadSpeed + Random.Range(1, 5);
                justSummonedSun = true;
            }
        }
    }
}
