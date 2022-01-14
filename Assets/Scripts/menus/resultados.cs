using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class resultados : MonoBehaviour
{
    public void cambiarEscenaJugarSinMenu()
    {

        GameManager.mostrarMenu = false;
        GameManager.moverse = true;
        MusicManager.Instance.StopAndPlaySong(MusicManager.Song.PlayTheme);
        SceneManager.LoadScene("Tutorial");
    }
    public void cambiarEscenaJugarConMenu()
    {
        GameManager.mostrarMenu = true;
        GameManager.moverse = false;
        MusicManager.Instance.StopAndPlaySong(MusicManager.Song.PlayTheme);
        SceneManager.LoadScene("Tutorial");

    }
}

