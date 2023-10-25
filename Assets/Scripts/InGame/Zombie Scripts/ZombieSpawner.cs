using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject[] Zombies;
    public Transform[] SpawnPoints;
    public float startTime;
    public float timer;
    public bool gameStart;
    public int numberOfEnemiesLeft;
    public static int numberOfEnemiesLeftScreen;
    public static int wave;
    public int randZombie;
    private int randPoint;
    public GameObject flagZombie;
    void Start()
    {
        StartCoroutine(GracePeriod());
    }

    IEnumerator GracePeriod()
    {
        yield return new WaitForSeconds(startTime);
        gameStart = true;
        SoundManager.instance.ZRC.Play();
    }

    IEnumerator StartNextWave()
    {
        gameStart = false;
        yield return new WaitForSeconds(15);
        Instantiate(flagZombie, SpawnPoints[randPoint].position, transform.rotation);
        wave++;
        numberOfEnemiesLeft += 10 * Random.Range(1, 3) * wave - Random.Range(0, wave) * 5;
        gameStart = true;
    }

    void Update()
    {
        if (gameStart == true)
        {
            float ranSpawn = Random.Range(2, 5);
            if (timer >= ranSpawn && numberOfEnemiesLeft > 0)
            {
                randPoint = Random.Range(0, SpawnPoints.Length);

                if (wave == 1)
                {
                    randZombie = 0;
                }
                
                if (wave <= 3 && wave >= 2)
                {
                    randZombie = Random.Range(0, 3);
                }

                if (wave >= 4)
                {
                    randZombie = Random.Range(0, 5);
                }

                Instantiate(Zombies[randZombie], SpawnPoints[randPoint].position, transform.rotation);
                timer = 0;
                numberOfEnemiesLeft--;
            }
            timer += Time.deltaTime;
            if (numberOfEnemiesLeft <= 0)
            {
                StartCoroutine(StartNextWave());
            }
        }
    }
}
