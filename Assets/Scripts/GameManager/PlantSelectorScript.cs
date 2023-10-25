using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlantSelectorScript : MonoBehaviour
{
    public List<PlantsData> plantsChosen;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        
    }

    public void SelectPlant(PlantsData plant)
    {
        if(plantsChosen.Count < 6)
        {
            plantsChosen.Add(plant);
        }
    }

    public void PlayGame()
    {
        if(plantsChosen.Count == 6)
        {
            SceneManager.LoadScene("Day");
        }
    }
}
