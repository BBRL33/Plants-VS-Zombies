using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int suns = 50;
    public PlantsData plantToPlace;
    public CustomCursor customCursor;
    public Tiles[] tiles;
    public Text sunDisplay;
    public Text wave;
    public Text zombieLeft;
    public GameObject gameOver;
    public LayerMask sunlayer;
    public PlantSelectorScript selector;
    public Button[] buttons;
    public Text[] plantCosts;
    void Start()
    {
        customCursor.gameObject.SetActive(false);
        gameOver = FindObjectOfType<Restart>().gameObject;
        gameOver.SetActive(false);
        selector = FindObjectOfType<PlantSelectorScript>();
        buttons[0].onClick.AddListener(delegate { BuyPlant(selector.plantsChosen[0]); });
        buttons[0].GetComponent<Image>().sprite = selector.plantsChosen[0].buttonImage;
        plantCosts[0].text = selector.plantsChosen[0].cost.ToString();
        buttons[1].onClick.AddListener(delegate { BuyPlant(selector.plantsChosen[1]); });
        buttons[1].GetComponent<Image>().sprite = selector.plantsChosen[1].buttonImage;
        plantCosts[1].text = selector.plantsChosen[1].cost.ToString();
        buttons[2].onClick.AddListener(delegate { BuyPlant(selector.plantsChosen[2]); });
        buttons[2].GetComponent<Image>().sprite = selector.plantsChosen[2].buttonImage;
        plantCosts[2].text = selector.plantsChosen[2].cost.ToString();
        buttons[3].onClick.AddListener(delegate { BuyPlant(selector.plantsChosen[3]); });
        buttons[3].GetComponent<Image>().sprite = selector.plantsChosen[3].buttonImage;
        plantCosts[3].text = selector.plantsChosen[3].cost.ToString();
        buttons[4].onClick.AddListener(delegate { BuyPlant(selector.plantsChosen[4]); });
        buttons[4].GetComponent<Image>().sprite = selector.plantsChosen[4].buttonImage;
        plantCosts[4].text = selector.plantsChosen[4].cost.ToString();
        buttons[5].onClick.AddListener(delegate { BuyPlant(selector.plantsChosen[5]); });
        buttons[5].GetComponent<Image>().sprite = selector.plantsChosen[5].buttonImage;
        plantCosts[5].text = selector.plantsChosen[5].cost.ToString();
    }

    void Update()
    {
        sunDisplay.text = suns.ToString();
        wave.text = ZombieSpawner.wave.ToString();
        zombieLeft.text = ZombieSpawner.numberOfEnemiesLeftScreen.ToString();
        if (Input.GetMouseButtonDown(0) && plantToPlace != null)
        {
            Tiles nearestTile = null;
            float nearestDistance = float.MaxValue;
            foreach (Tiles tile in tiles)
            {
                float distance = Vector2.Distance(tile.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
                if (distance < nearestDistance)
                {
                    nearestDistance = distance;
                    nearestTile = tile;
                }
            }
            if (nearestTile.isOccupied == false)
            {
                PlantsData newPlant = Instantiate(plantToPlace, nearestTile.transform.position, Quaternion.identity);
                newPlant.tile = nearestTile;
                plantToPlace = null;
                nearestTile.isOccupied = true;
                Cursor.visible = true;
                customCursor.gameObject.SetActive(false);
                SoundManager.instance.plant.Play();
            }
        }
        if (Input.GetMouseButtonDown(0) && plantToPlace == null)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward, Mathf.Infinity, sunlayer);
            if (hit.collider == null)
            {
                return;
            }
            if (hit.collider.GetComponent<SunScript>())
            {
                suns += 50;
                SoundManager.instance.sunCollect.Play();
                hit.collider.GetComponent<SunScript>().FadeOutAndDie();
            }
        }
        if (Input.GetMouseButtonDown(1) && plantToPlace != null)
        {
            suns += plantToPlace.cost;
            plantToPlace = null;
            Cursor.visible = true;
            customCursor.gameObject.SetActive(false);
        }
        if (Input.GetMouseButtonDown(1) && plantToPlace == null)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward, Mathf.Infinity);
            if (hit.collider == null) return;
            if (hit.collider.GetComponent<PlantsData>())
            {
                suns += hit.collider.GetComponent<PlantsData>().cost / 5 * 2;
                hit.collider.GetComponent<PlantsData>().tile.isOccupied = false;
                Destroy(hit.collider.gameObject);
                SoundManager.instance.plantRemove.Play();
            }
        }
    }

    public void BuyPlant(PlantsData plant)
    {
        if (suns >= plant.cost)
        {
            customCursor.gameObject.SetActive(true);
            customCursor.GetComponent<SpriteRenderer>().sprite = plant.GetComponent<SpriteRenderer>().sprite;
            Cursor.visible = false;
            suns -= plant.cost;
            plantToPlace = plant;
        }
    }
}
