using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    public GameObject eye, ceye;
    public float timer;
    
    void Start()
    {
        StartCoroutine(eyesa(Random.Range(7, 15)));
    }
    IEnumerator eyesa(float time)
    {
        ceye.SetActive(false);
        eye.SetActive(true);
        yield return new WaitForSeconds(time);
        ceye.SetActive(true);
        eye.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        ceye.SetActive(false);
        eye.SetActive(true);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 5.5)
        {
            StartCoroutine(eyesa(Random.Range(7, 15)));
            timer = 0;
        }
    }
}
