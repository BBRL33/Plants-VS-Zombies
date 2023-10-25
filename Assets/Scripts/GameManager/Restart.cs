using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    public Text display;
    void Start()
    {
        Time.timeScale = 0f;
    }

    void Update()
    {
        int num = ZombieSpawner.wave % 10;
        if (ZombieSpawner.wave == 0)
        {
            display.text = "Really? You are still at the start wave!";
        }
        else if (num == 1 && ZombieSpawner.wave != 11)
        {
            display.text = "You made it to the " + ZombieSpawner.wave + "st wave!";
        }
        else if (num == 2 && ZombieSpawner.wave != 12)
        {
            display.text = "You made it to the " + ZombieSpawner.wave + "nd wave!";
        }
        else if (num == 3 && ZombieSpawner.wave != 13)
        {
            display.text = "You made it to the " + ZombieSpawner.wave + "rd wave!";
        }
        else
        {
            display.text = "You made it to the " + ZombieSpawner.wave + "th wave!";
        }
    }

    public void Reload()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
