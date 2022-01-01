using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class configuracion : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider sliderMusicaOpciones;
    public Slider sliderMusicaIngame;
    public Toggle tick;
    private void Awake()
    {
        float f = PlayerPrefs.GetFloat("volumen", 0);
        audioMixer.SetFloat("volumen",f);
        sliderMusicaOpciones.value = f;
        sliderMusicaIngame.value = f;
        if (PlayerPrefs.GetString("tuto", "True").Equals("True"))
        {
            tick.isOn = true;
        }
        else {
            tick.isOn = false;

        }


    }

    public void setVolume(float f) {
        audioMixer.SetFloat("volumen",f);
     
        PlayerPrefs.SetFloat("volumen", f);
        PlayerPrefs.Save();
    }

    public void setTutorial(bool b) {
        Debug.Log(b.ToString());
        PlayerPrefs.SetString("tuto", b.ToString());
        PlayerPrefs.Save();

    }
}
