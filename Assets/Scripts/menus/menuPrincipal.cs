using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menuPrincipal : MonoBehaviour
{
    public delegate void menu();
    public static event menu empezarPartida;

    public GameObject canvasMenu;
    public GameObject canvasIngame;


    //Esto se modifica desde el script de resultados



    private void Start()
    {
        //Time.timeScale = 0;

        if (!GameManager.mostrarMenu)
        {
            //Hacer el countDown
          // Debug.Log("no Mostrat menu");
            canvasMenu.SetActive(false);
            canvasIngame.SetActive(true);
            empezarPartida();
        }
        else
        {
         //   Debug.Log(" Mostrat menu");
        }

    }

    public void Jugar()
    {
        //SceneManager.LoadScene("Tutorial", LoadSceneMode.Single);
        //Time.timeScale = 1;
        empezarPartida();

    }
    public void mostratMenuEnPartida(){
        Time.timeScale = 0;//Para el tiempo del juego
    }

    public void quitarMenuEnPatida() {
        Time.timeScale = 1.0f;//Reanuda el tiempo del juego
    }


    public void terminarPartida() {
        generadorNivel.spawnPos = generadorNivel.spawnInicialAux;
        GameManager.moverse = false;
        GameManager.mostrarMenu = true;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Tutorial");
    }

    public menu getempezar()
    {

        return empezarPartida;
    }


    public void Salir()
    {
        Application.Quit();
    }
}