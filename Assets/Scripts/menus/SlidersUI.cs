using UnityEngine;
using UnityEngine.UI;

namespace menus
{
    public class SlidersUI : MonoBehaviour
    {
        public Slider sliderMusic;
        public Slider sliderSFX;
        public Toggle tick;

        private void OnEnable()
        {
            float musicVol = PlayerPrefs.GetFloat("MusicVol", 0.08f);
            float sfxVol = PlayerPrefs.GetFloat("SFXVol", 0.25f);

            MusicManager.Instance._audioSource.volume = musicVol;
            SFXManager.Instance.audioSource.volume = sfxVol;

            sliderMusic.value = musicVol;
            sliderSFX.value = sfxVol;

            sliderMusic.onValueChanged.AddListener(delegate { SetMusicVolume(sliderMusic.value); });
            sliderSFX.onValueChanged.AddListener(delegate { SetSFXVolume(sliderSFX.value); });

            if (!tick) return;
            
            if (PlayerPrefs.GetString("tuto", "True").Equals("True"))
            {
                tick.isOn = true;
            }
            else
            {
                tick.isOn = false;
            }
            
            tick.onValueChanged.AddListener(delegate { setTutorial(tick.isOn); });
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

        public void setTutorial(bool b)
        {
            Debug.Log(b.ToString());
            PlayerPrefs.SetString("tuto", b.ToString());
            PlayerPrefs.Save();
        }
    }
}