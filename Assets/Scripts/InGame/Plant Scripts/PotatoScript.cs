using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoScript : MonoBehaviour
{
    public PlantsData self;
    public LayerMask zombieLayer;
    public float timer;
    public GameObject unPrepared;
    public GameObject Prepared;
    void Start()
    {
        self = GetComponent<PlantsData>();
        Prepared.SetActive(false);
        unPrepared.SetActive(true);
    }

    void Update()
    {
        if (timer >= 4.5)
        {
            Prepared.SetActive(true);
            unPrepared.SetActive(false);
            self.transform.localScale = new Vector3((timer - 4.5f) * 0.125f, (timer - 4.5f) * 0.125f, (timer - 4.5f) * 0.125f);
        }
        timer += Time.deltaTime;
        if (timer >= 5)
        {
            self.transform.localScale = new Vector3(0.125f, 0.125f, 0.125f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Zombie>() && timer >= 5)
        {
            Collider2D[] zombiesInRange = Physics2D.OverlapCircleAll(transform.position, 1, zombieLayer);
            for (int i = 0; i < zombiesInRange.Length; i++)
            {
                zombiesInRange[i].gameObject.GetComponent<Zombie>().health -= 1000;
            }
            self.tile.isOccupied = false;
            Destroy(gameObject);
        }
    }
}
