using System.Collections;
using System.Collections.Generic;
using coins;
using UnityEngine;
using UnityEngine.SceneManagement;
public class muerteDeslizar : MonoBehaviour
{

    public GameObject rata;

    private void OnTriggerEnter(Collider other)
{
        if (other.gameObject.layer == 9) {
            StartCoroutine(playSounds());
            generadorNivel.spawnPos = generadorNivel.spawnInicialAux;
            GameManager.moverse = false;
            rata.GetComponent<Animator>().SetBool("Crash", true);
            StartCoroutine(pasarEscena(5f));
            
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
    IEnumerator pasarEscena(float time)
    {
        PlayerPrefs.SetInt("Score", CoinManager.Instance.coins);
        PlayerPrefs.Save();        
        yield return new WaitForSeconds(time);
        MusicManager.Instance.StopAndPlaySong(MusicManager.Song.DeathTheme);
        SceneManager.LoadScene("resultados");
    }
    IEnumerator playSounds()
    {
        SFXManager.Instance.PlaySound(SFXManager.Sound.HitWall);
        yield return new WaitForSeconds(1.7f);
        SFXManager.Instance.PlaySound(SFXManager.Sound.Helicopter);
    }
}
