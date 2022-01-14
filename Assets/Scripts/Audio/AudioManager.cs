using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
   public static AudioManager Instance;
   public AudioConfig audioConfig;
   public enum Sound
   {
      
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
      
      DontDestroyOnLoad(this.gameObject);
   }
}
