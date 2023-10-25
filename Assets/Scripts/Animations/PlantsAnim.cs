using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantsAnim : MonoBehaviour
{
    public GameObject Leaf1;
    public GameObject Leaf2;
    public GameObject Leaf3;
    public GameObject Leaf4;
    public GameObject Stem;
    public GameObject Eye1;
    public GameObject Eye2;
    public GameObject HeadBundle;
    public float headTimer;
    public bool HeadToLeft = false;
    void Start()
    {
        
    }

    void Update()
    {
        headTimer += Time.deltaTime;
        if (headTimer <= 0.3)
        {
            HeadBundle.transform.Translate(Vector2.down * 0.25f * Time.deltaTime);
            HeadBundle.transform.Translate(Vector2.right * 0.5f * Time.deltaTime);
            Stem.transform.Rotate(0, 0, 360 * -0.25f * Time.deltaTime);
            Leaf4.transform.Rotate(0, 0, 360 * 0.25f * Time.deltaTime);
            Leaf1.transform.Rotate(0, 0, 360 * 0.25f * Time.deltaTime);
        }
        else if (headTimer <= 0.6)
        {
            HeadBundle.transform.Translate(Vector2.up * 0.25f * Time.deltaTime);
            HeadBundle.transform.Translate(Vector2.left * 0.5f * Time.deltaTime);
            Stem.transform.Rotate(0, 0, 360 * 0.25f * Time.deltaTime);
            Leaf1.transform.Rotate(0, 0, 360 * -0.25f * Time.deltaTime);
            Leaf2.transform.Rotate(0, 0, 360 * -0.25f * Time.deltaTime);
        }
        else if (headTimer <= 0.9)
        {
            HeadBundle.transform.Translate(Vector2.down * 0.25f * Time.deltaTime);
            HeadBundle.transform.Translate(Vector2.left * 0.5f * Time.deltaTime);
            Stem.transform.Rotate(0, 0, 360 * 0.25f * Time.deltaTime);
            Leaf2.transform.Rotate(0, 0, 360 * 0.25f * Time.deltaTime);
            Leaf3.transform.Rotate(0, 0, 360 * 0.25f * Time.deltaTime);
        }
        else if (headTimer <= 1.2)
        {
            HeadBundle.transform.Translate(Vector2.up * 0.25f * Time.deltaTime);
            HeadBundle.transform.Translate(Vector2.right * 0.5f * Time.deltaTime);
            Stem.transform.Rotate(0, 0, 360 * -0.25f * Time.deltaTime);
            Leaf3.transform.Rotate(0, 0, 360 * -0.25f * Time.deltaTime);
            Leaf4.transform.Rotate(0, 0, 360 * -0.25f * Time.deltaTime);
        }
        else if (headTimer >= 1.2)
        {
            headTimer = 0;
        }

    }
}
