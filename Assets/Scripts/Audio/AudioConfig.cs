using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Audio/AudioConfig")]
public class AudioConfig : ScriptableObject
{
    [Serializable] public struct SoundAudioClip
    {
        public AudioClip audioClip;
        public AudioManager.Sound sound;
    }

    [SerializeField] public SoundAudioClip[] audioClips;
    private Dictionary<AudioManager.Sound, AudioClip> _soundToAudioClip;

    private void Awake()
    {
        _soundToAudioClip = new Dictionary<AudioManager.Sound, AudioClip>();
        foreach (var soundClip in audioClips)
        {
            _soundToAudioClip.Add(soundClip.sound, soundClip.audioClip);
        }
    }

    public AudioClip GetAudioClip(AudioManager.Sound s)
    {
        if (!_soundToAudioClip.TryGetValue(s, out AudioClip returnSound))
        {
            return null;
        }

        return returnSound;
    }
}
