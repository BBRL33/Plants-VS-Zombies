using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    private bool Toggle;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public AudioSource bgMusic;
    public AudioSource peaShoot;
    public AudioSource sunCollect;
    public AudioSource frozenpea;
    public AudioSource firepea;
    public AudioSource ZRC;
    public AudioSource plant;
    public AudioSource plantRemove;

    public float sfxVolume;
    public float musicVolume;

    void Start()
    {
        
    }

    void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Day") && Toggle == false)
        {
            SoundManager.instance.bgMusic.Play();
            Toggle = true;
        }
        peaShoot.volume = sfxVolume;
        sunCollect.volume = sfxVolume;
        frozenpea.volume = sfxVolume;
        firepea.volume = sfxVolume;
        ZRC.volume = musicVolume;
        plant.volume = sfxVolume;
        plantRemove.volume = sfxVolume;
        bgMusic.volume = musicVolume;
    }
}
