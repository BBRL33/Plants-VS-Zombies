using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanButton : MonoBehaviour
{
    public Button self;
    void Start()
    {
        self = GetComponent<Button>();
    }

    public void SelectedPlant()
    {
        if (FindObjectOfType<PlantSelectorScript>().plantsChosen.Count <= 6)
        {
            self.interactable = false;
        }
    }
}
