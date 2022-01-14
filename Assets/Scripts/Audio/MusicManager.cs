using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public enum Song
    {
        PlayTheme,
        DeathTheme
    }

    public static MusicManager Instance;

    [SerializeField] public MusicConfig musicConfig;
    public AudioSource _audioSource;

    private void Awake()
    {
        if (Instance != null & Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        musicConfig = Instantiate(musicConfig);

        if (!_audioSource)
            _audioSource = gameObject.AddComponent<AudioSource>();
        
        switch (SceneManager.GetActiveScene().name)
        {
            case "Tutorial":
                StopAndPlaySong(Song.PlayTheme);
                break;
            case "resultados":
                StopAndPlaySong(Song.DeathTheme);
                break;
        }
        
        DontDestroyOnLoad(gameObject);
    }

    public void StopAndPlaySong(Song song)
    {
        _audioSource.Stop();
        _audioSource.loop = true;
        _audioSource.clip = musicConfig.GetSong(song);
        _audioSource.Play();
    }
}