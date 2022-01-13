using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
   public static AudioManager Instance;
   public AudioConfig audioConfig;
   public AudioSource audioSource;
   public enum Sound
   {
      CheeseBite
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

      audioConfig = Instantiate(audioConfig);

      audioSource = gameObject.AddComponent<AudioSource>(); 
      
      DontDestroyOnLoad(this.gameObject);
   }

   public void PlaySound(Sound sound)
   {
      audioSource.PlayOneShot(audioConfig.GetAudioClip(sound));
   }
}
