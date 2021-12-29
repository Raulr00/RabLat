using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menuPrincipal : MonoBehaviour
{
    public delegate void menu();
    public static event menu empezarPartida;

    public GameObject canvasMenu;


 //Esto se modifica desde el script de resultados

    

    private void Awake()
    {
        //Time.timeScale = 0;

        if (!GameManager.mostrarMenu)
        {
            //Hacer el countDown
            Debug.Log("no Mostrat menu");
            canvasMenu.SetActive(false);
            empezarPartida();
        }
        else
        {
            Debug.Log(" Mostrat menu");
        }
        
    }

    public void Jugar()
    {
        //SceneManager.LoadScene("Tutorial", LoadSceneMode.Single);
        //Time.timeScale = 1;
        empezarPartida();

    }


   

    public void Salir() {
        Application.Quit();
    }
}