using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeashooterPea : MonoBehaviour
{
    public float moveSpeed;
    public int damage;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        if (transform.position.x > 12)
        {
            Destroy(gameObject);
        }
    }
}
