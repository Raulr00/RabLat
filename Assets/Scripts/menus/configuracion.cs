using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class configuracion : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider sliderMusicaOpciones;
    public Slider sliderSFXOpciones;
    public Slider sliderMusicaIngame;
    public Slider sliderSFXaIngame;
    public Toggle tick;
    private void Awake()
    {
        

    }
    

    private void OnEnable()
    {
        // float musicVol = PlayerPrefs.GetFloat("MusicVol", 0.3f);
        // float sfxVol = PlayerPrefs.GetFloat("SFXVol", 0.5f);
        //
        // try
        // {
        //     MusicManager.Instance._audioSource.volume = musicVol;
        // }
        // catch
        // {
        //     //It will be found eventually
        // }
        //
        // try
        // {
        //     SFXManager.Instance.audioSource.volume = sfxVol;
        // }
        // catch
        // {
        //     Debug.Log("No AudioManager encontrado");
        // }
        //
        //
        // sliderMusicaOpciones.value = musicVol;
        // sliderMusicaIngame.value = musicVol;
        // sliderSFXaIngame.value = sfxVol;
        // sliderSFXOpciones.value = sfxVol;
        // if (PlayerPrefs.GetString("tuto", "True").Equals("True"))
        // {
        //     tick.isOn = true;
        // }
        // else
        // {
        //     tick.isOn = false;
        // }

    }

    // public void SetMusicVolume(float f)
    // {
    //     try
    //     {
    //         MusicManager.Instance._audioSource.volume = f;
    //     }
    //     catch
    //     {
    //         Debug.Log("No AudioManager encontrado");
    //     }
    //  
    //     PlayerPrefs.SetFloat("MusicVol", f);
    //     PlayerPrefs.Save();
    // }
    //
    // public void SetSFXVolume(float f)
    // {
    //     try
    //     {
    //         SFXManager.Instance.audioSource.volume = f;
    //     }
    //     catch
    //     {
    //         Debug.Log("No AudioManager encontrado");
    //     }
    //     
    //     PlayerPrefs.SetFloat("SFXVol", f);
    //     PlayerPrefs.Save();
    // }
    //
    // public void setTutorial(bool b) {
    //     Debug.Log(b.ToString());
    //     PlayerPrefs.SetString("tuto", b.ToString());
    //     PlayerPrefs.Save();
    //
    // }
}
