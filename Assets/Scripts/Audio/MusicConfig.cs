using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "Custom/Audio/MusicConfig")]
public class MusicConfig : ScriptableObject
{
    [Serializable]public struct MusicAudioClip
    {
        public AudioClip audioClip;
        public MusicManager.Song song;
    }

    [SerializeField] public MusicAudioClip[] songClips;
    private Dictionary<MusicManager.Song, AudioClip> _songToAudioClip;

    private void Awake()
    {
        if (_songToAudioClip == null)
        {
            _songToAudioClip = new Dictionary<MusicManager.Song, AudioClip>();
            foreach (var songClip in songClips)
            {
                _songToAudioClip.Add(songClip.song, songClip.audioClip);
            }
        }
    }

    public AudioClip GetSong(MusicManager.Song song)
    {
        if (!_songToAudioClip.TryGetValue(song, out AudioClip outSong))
        {
            return null;
        }

        return outSong;
    }
}