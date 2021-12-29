using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class muerte : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    float alturaJuego = 0;
    public GameObject jugador;

    private void Update()
    {
        Debug.Log(gameObject.name + " " + generadorNivel.spawnPos + " " + jugador.transform.position.y);

        if (jugador.transform.position.y < generadorNivel.spawnPos.y - 5)
        {
            generadorNivel.spawnPos = new Vector3(generadorNivel.spawnInicialAux.x, generadorNivel.spawnInicialAux.y, generadorNivel.spawnInicialAux.z);
          //  SceneManager.LoadScene("Menu");

           
            Scene escena = SceneManager.GetActiveScene();
             SceneManager.LoadScene(escena.name);
        }
    }

}
