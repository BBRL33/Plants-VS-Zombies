using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwliner : MonoBehaviour
{
    public GameObject tower;
    public GameObject enemy;
    public float speed;
    private float towerX;
    private float enemyX;
    private float dist;
    private float nextX;
    private float baseY;
    private float height;

    void Start()
    {
        tower = GameObject.FindGameObjectWithTag("Thrower");
        enemy = GameObject.FindGameObjectWithTag("Target");
    }

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Target") == null)
        {
            return;
        }
        towerX = tower.transform.position.x;
        enemyX = enemy.transform.position.x;
        dist = enemyX - towerX;
        nextX = Mathf.MoveTowards(transform.position.x, enemyX, speed * Time.deltaTime);
        baseY = Mathf.Lerp(tower.transform.position.y, enemy.transform.position.y, (nextX - towerX) / dist);
        height = 2 * (nextX - towerX) * (nextX - enemyX) / (-0.25f * dist * dist);
        Vector3 movePosition = new Vector3(nextX, baseY + height, transform.position.z);
        transform.rotation = lookAtTarget(movePosition - transform.position);
        transform.position = movePosition;
        if(transform.position == enemy.transform.position)
        {
            Destroy(gameObject);
        }
    }

    public static Quaternion lookAtTarget(Vector2 rotation)
    {
        return Quaternion.Euler(0, 0, Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg);
    }
}
