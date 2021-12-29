using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class muerte : MonoBehaviour
{
    public GameObject jugador;
    public GameObject pantallaResultados;

    private void Update()
    {
      //  Debug.Log(gameObject.name + " " + generadorNivel.spawnPos + " " + jugador.transform.position.y);

        if (jugador.transform.position.y < generadorNivel.spawnPos.y - 5)
        {
            generadorNivel.spawnPos = new Vector3(generadorNivel.spawnInicialAux.x, generadorNivel.spawnInicialAux.y, generadorNivel.spawnInicialAux.z);//Imp 
           // pantallaResultados.SetActive(true);
            //Scene escena = SceneManager.GetActiveScene();
            SceneManager.LoadScene("resultados");
        }
    }

}
