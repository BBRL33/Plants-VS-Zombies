using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAnim : MonoBehaviour
{
    public GameObject[] EyePairs;
    public float timer;
    public int i;
    public int speed;
    public bool Start = false;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer == Random.Range(5, 10))
        {
            
        }
    }
}
