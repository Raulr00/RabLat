using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Audio/SFXConfig")]
public class SFXConfig : ScriptableObject
{
    [Serializable]
    public struct SoundAudioClip
    {
        public AudioClip audioClip;
        public SFXManager.Sound sound;
    }

    [SerializeField] public SoundAudioClip[] audioClips;
    private Dictionary<SFXManager.Sound, AudioClip> _soundToAudioClip;

    private void Awake()
    {
        _soundToAudioClip = new Dictionary<SFXManager.Sound, AudioClip>();
        foreach (var soundClip in audioClips)
        {
            _soundToAudioClip.Add(soundClip.sound, soundClip.audioClip);
        }
    }

    public AudioClip GetAudioClip(SFXManager.Sound s)
    {
        if (!_soundToAudioClip.TryGetValue(s, out AudioClip returnSound))
        {
            return null;
        }

        return returnSound;
    }
}