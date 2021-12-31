using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class muerte : MonoBehaviour
{

    
    private void OnTriggerEnter(Collider other)
{

        if (other.gameObject.tag.Equals("muerte")) {

            generadorNivel.spawnPos = generadorNivel.spawnInicialAux;//METERSELO CUANDO HAGAS LO DE LA PARED



            GameManager.moverse = false;
            GetComponent<Animator>().SetBool("Fall", true);
            GetComponent<Animator>().SetBool("Fly", true);
            gameObject.GetComponent<BoxCollider>().enabled = false;

            StartCoroutine(pasarEscena(3f));

            // SceneManager.LoadScene("resultados");
        }
        else if (other.gameObject.tag.Equals("pared")) {
            if (Mathf.Abs(Vector3.Dot(transform.forward, other.gameObject.transform.forward))>0)
            {
                generadorNivel.spawnPos = generadorNivel.spawnInicialAux;
                GameManager.moverse = false;
                GetComponent<Animator>().SetBool("Crash", true);
                StartCoroutine(pasarEscena(5f));
                gameObject.GetComponent<BoxCollider>().enabled = false;
            }
            
        }


    }

    IEnumerator pasarEscena(float time) {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("resultados");
    }
    }


