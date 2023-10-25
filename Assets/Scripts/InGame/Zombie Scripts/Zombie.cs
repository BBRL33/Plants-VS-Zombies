using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float moveSpeed;
    private float ms;
    public int health;
    public PlantsData plantToAttack;
    public int plantDamage;

    public Color myColor;
    public float rFloat;
    public float gFloat;
    public float bFloat;
    public float aFloat;
    public Renderer myRenderer;
    private bool frozenHit;
    void Start()
    {
        ZombieSpawner.numberOfEnemiesLeftScreen++;
        ms = moveSpeed;
        aFloat = 1;
        myRenderer = gameObject.GetComponent<Renderer>();
    }

    void Update()
    {

        transform.position = new Vector3(transform.position.x - ms * Time.deltaTime, transform.position.y);
        if (health <= 0)
        {
            ZombieSpawner.numberOfEnemiesLeftScreen--;
            Destroy(gameObject);
        }

        if (transform.position.x <= -10)
        {
            FindObjectOfType<GameManager>().gameOver.SetActive(true);
        }
        if (frozenHit == true)
        {
            if (rFloat > 0)
            {
                rFloat -= 0.1f;
            }
            else
            {
                rFloat = 0;
            }
            frozenHit = false;
        }
        myColor = new Color(rFloat, gFloat, bFloat, aFloat);
        myRenderer.material.color = myColor;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Zombie>())
        {
            ms = 0.000000001f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Tiles>())
        {
            collision.gameObject.GetComponent<Tiles>().isOccupied = true;
        }
        if (collision.gameObject.GetComponent<PlantsData>())
        {
            ms = 0.000000001f;
            plantToAttack = collision.gameObject.GetComponent<PlantsData>();
            InvokeRepeating("DamagePlant", 1, 1);
        }
        if (collision.gameObject.GetComponent<PeashooterPea>())
        {
            if (collision.gameObject.CompareTag("Frozen"))
            {
                moveSpeed /= 2;
                ms /= 2;
                frozenHit = true;
            }
            health -= collision.gameObject.GetComponent<PeashooterPea>().damage;
            Destroy(collision.gameObject);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Zombie>())
        {
            ms = moveSpeed;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Tiles>())
        {
            collision.gameObject.GetComponent<Tiles>().isOccupied = false;
        }
        if (collision.gameObject.GetComponent<PlantsData>())
        {
            ms = moveSpeed;
            CancelInvoke();
            plantToAttack = null;
        }
    }

    void DamagePlant()
    {
        plantToAttack.health -= plantDamage;
        if(plantToAttack.health <= 0)
        {
            plantToAttack.tile.isOccupied = false;
            Destroy(plantToAttack.gameObject);
            ms = moveSpeed;
            plantToAttack = null;
            CancelInvoke();
        }
    }
}
