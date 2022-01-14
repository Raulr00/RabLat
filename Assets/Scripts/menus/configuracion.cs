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
    public Slider sliderSFXIngame;
    public Toggle tick;
    private void Awake()
    {
        float musixVol = PlayerPrefs.GetFloat("MusicVol", 0.5f);
        float sfxVol = PlayerPrefs.GetFloat("SFXVol", 0.5f);
        MusicManager.Instance._audioSource.volume = musixVol;
        sliderMusicaOpciones.value = musixVol;
        sliderMusicaIngame.value = musixVol;
        if (PlayerPrefs.GetString("tuto", "True").Equals("True"))
        {
            tick.isOn = true;
        }
        else {
            tick.isOn = false;

        }


    }

    public void SetMusicVolume(float f)
    {
        MusicManager.Instance._audioSource.volume = f;
     
        PlayerPrefs.SetFloat("MusicVol", f);
        PlayerPrefs.Save();
    }
    
    public void SetSFXVolume(float f)
    {
        SFXManager.Instance.audioSource.volume = f;
     
        PlayerPrefs.SetFloat("SFXVol", f);
        PlayerPrefs.Save();
    }

    public void setTutorial(bool b) {
        // Debug.Log(b.ToString());
        PlayerPrefs.SetString("tuto", b.ToString());
        PlayerPrefs.Save();

    }
}
