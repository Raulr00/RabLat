using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menuPrincipal : MonoBehaviour
{
    public delegate void menu();
    public static event menu empezarPartida;

    private void Awake()
    {
        //Time.timeScale = 0;
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