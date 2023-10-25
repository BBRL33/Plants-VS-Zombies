using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterAnim : MonoBehaviour
{
    public GameObject PuffedUpMouth;
    public GameObject ClosedMouth;
    public GameObject Eye1;
    public GameObject Eye2;
    public GameObject ClosedEye1;
    public GameObject ClosedEye2;
    public GameObject Mouth;
    public ProjectileTrigger trigger;
    public float timer;

    void Start()
    {
        
    }

    void Update()
    {
        if (trigger.justSummonedPea == true)
        {
            timer += 5f * Time.deltaTime;
            Eye1.SetActive(false);
            Eye2.SetActive(false);
            ClosedEye1.SetActive(true);
            ClosedEye2.SetActive(true);
            PuffedUpMouth.SetActive(true);
            PuffedUpMouth.transform.localScale = new Vector3(timer, timer, timer);
            Mouth.transform.localScale = new Vector3(1 - timer, 1 - timer, 1 - timer);
            if (timer >= 0.5 && timer <= 1)
            {
                Mouth.SetActive(false);
                ClosedMouth.SetActive(true);
            }
            if (timer >= 1)
            {
                PuffedUpMouth.transform.localScale = new Vector3(1, 1, 1);
                Mouth.transform.localScale = new Vector3(1, 1, 1);
                timer = 0;
                ClosedMouth.SetActive(false);
                Mouth.SetActive(true);
                Eye1.SetActive(true);
                Eye2.SetActive(true);
                ClosedEye1.SetActive(false);
                ClosedEye2.SetActive(false);
                PuffedUpMouth.SetActive(false);
                trigger.justSummonedPea = false;
            }

        }
    }
}
