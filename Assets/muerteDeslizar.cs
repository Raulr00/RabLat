using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class muerteDeslizar : MonoBehaviour
{

    public GameObject rata;

    private void OnTriggerEnter(Collider other)
{
        if (other.gameObject.layer == 9) {
            generadorNivel.spawnPos = generadorNivel.spawnInicialAux;
            GameManager.moverse = false;
            rata.GetComponent<Animator>().SetBool("Crash", true);
            StartCoroutine(pasarEscena(5f));
            
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
    IEnumerator pasarEscena(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("resultados");
    }
}
