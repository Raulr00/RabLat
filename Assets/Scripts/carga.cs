using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class carga : MonoBehaviour
{


    public Slider barracarga;
    float progreso = 0;
    private void Start()
    {
        //SceneManager.LoadScene("Tutorial");
        cargarNivel();
    }

    public void cargarNivel() {
        StartCoroutine(cargarAsync());
    }
    IEnumerator cargarAsync() {
       

        while (progreso<=1) {

             progreso += 0.1f;

            barracarga.value = progreso;
            yield return 0.2f;
        }
        AsyncOperation op = SceneManager.LoadSceneAsync(1);
    }
}
