using System.Collections;
using System.Collections.Generic;
using coins;
using UnityEngine;
using UnityEngine.SceneManagement;

public class muerte : MonoBehaviour
{
    private void OnEnable()
    {
        vida.muerteSinVida += morirPorVida;
    }
    private void OnDisable()
    {
        vida.muerteSinVida -= morirPorVida;
    }
    private void morirPorVida() {
        generadorNivel.spawnPos = generadorNivel.spawnInicialAux;
        GameManager.moverse = false;
        GetComponent<Animator>().SetBool("Crash", true);
        StartCoroutine(pasarEscena(5f));
        gameObject.GetComponent<BoxCollider>().enabled = false;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("muerte"))
        {
            generadorNivel.spawnPos = generadorNivel.spawnInicialAux; //METERSELO CUANDO HAGAS LO DE LA PARED


            SFXManager.Instance.PlaySound(SFXManager.Sound.Helicopter);
            GameManager.moverse = false;
            GetComponent<Animator>().SetBool("Fall", true);
            GetComponent<Animator>().SetBool("Fly", true);
            gameObject.GetComponent<BoxCollider>().enabled = false;

            StartCoroutine(pasarEscena(3f));

            // SceneManager.LoadScene("resultados");
        }
        else if (other.gameObject.tag.Equals("pared"))
        {
            if (Mathf.Abs(Vector3.Dot(transform.forward, other.gameObject.transform.forward)) > 0)
            {
                StartCoroutine(playSounds());                
                generadorNivel.spawnPos = generadorNivel.spawnInicialAux;
                GameManager.moverse = false;
                GetComponent<Animator>().SetBool("Crash", true);
                StartCoroutine(pasarEscena(5f));
                gameObject.GetComponent<BoxCollider>().enabled = false;
            }
        }
    }

    IEnumerator playSounds()
    {
        SFXManager.Instance.PlaySound(SFXManager.Sound.HitWall);
        yield return new WaitForSeconds(1.7f);
        SFXManager.Instance.PlaySound(SFXManager.Sound.Helicopter);
    }

    IEnumerator pasarEscena(float time)
    {
        PlayerPrefs.SetInt("Score", CoinManager.Instance.coins);
        PlayerPrefs.Save();
        yield return new WaitForSeconds(time);
        MusicManager.Instance.StopAndPlaySong(MusicManager.Song.DeathTheme);
        SceneManager.LoadScene("resultados");
    }
}