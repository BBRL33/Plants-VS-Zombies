using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public Slider sfxVolume;
    public Slider musicVolume;
    public Toggle fullscreen;
    void Start()
    {
        
    }

    void Update()
    {
        SoundManager.instance.sfxVolume = sfxVolume.value;
        SoundManager.instance.musicVolume = musicVolume.value;
        Screen.fullScreen = fullscreen.isOn;
    }
    public void Exit()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void sfxTest()
    {
        SoundManager.instance.plant.Play();
    }
    public void bgTest()
    {
        SoundManager.instance.ZRC.Play();
    }
}
