using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SFXManager : MonoBehaviour
{
   public static SFXManager Instance;
   public SFXConfig sfxConfig;
   public AudioSource audioSource;
   public enum Sound
   {
      CheeseBite,
      HitWall,
      Helicopter,
      PowerUp,
      Jump,
      Swipe
   }
   private void Awake()
   {
      if (Instance != null && Instance != this)
      {
         Destroy(this.gameObject);
      }
      else
      {
         Instance = this;
      }

      sfxConfig = Instantiate(sfxConfig);

      audioSource = gameObject.AddComponent<AudioSource>();
      audioSource.volume = PlayerPrefs.GetFloat("SFXVol", 0.5f);
   }

   public void PlaySound(Sound sound)
   {
      audioSource.PlayOneShot(sfxConfig.GetAudioClip(sound));
   }
   public void PlaySample()
   {
      audioSource.PlayOneShot(sfxConfig.GetAudioClip(Sound.CheeseBite));
   }
}
