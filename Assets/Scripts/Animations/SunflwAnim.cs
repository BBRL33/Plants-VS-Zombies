using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunflwAnim : MonoBehaviour
{
    public GameObject Lit;
    public ProjectileTrigger trigger;
    void Start()
    {
        Lit.SetActive(false);
    }
    IEnumerator sunPop()
    {
        Lit.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Lit.SetActive(false);
    }

    void Update()
    {
        if (trigger.justSummonedSun == true)
        {
            StartCoroutine(sunPop());
            trigger.justSummonedSun = false;
        }
    }
}
