using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunSpawner : MonoBehaviour
{
    public GameObject SunPrefab;
    public float leff, wit;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 15)
        {
            float newX = Random.Range(leff, wit);
            Instantiate(SunPrefab, new Vector3(newX, transform.position.y), transform.rotation);
            timer = 0;
        }
    }
}
