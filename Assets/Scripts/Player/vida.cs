using System.Collections;
using System.Collections.Generic;
using coins;
using UnityEngine;
using UnityEngine.UI;

public class vida : MonoBehaviour
{
    Image vidaImagen;
    public float tiempoVivoMax;
    float tiempoRestante;
    bool bajar = true;

    private void OnEnable()
    {
        monedas.monedaRecodiga += sumarVida;
    }

    private void OnDisable()
    {
        monedas.monedaRecodiga -= sumarVida;
    }

    // Start is called before the first frame update
    void Start()
    {
        vidaImagen = GetComponent<Image>();
        tiempoRestante = tiempoVivoMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (tiempoRestante > 0 && bajar)
        {

            tiempoRestante -= Time.deltaTime/1.5f;
            vidaImagen.fillAmount = tiempoRestante / tiempoVivoMax;
        }
        else
        {
            // Time.timeScale = 0;
        }
    }

    void sumarVida()
    {
        if (tiempoRestante <=tiempoVivoMax) {

    
          /* tiempoRestante += Time.deltaTime*5;


            vidaImagen.fillAmount = tiempoRestante / tiempoVivoMax;

            bajar = false;*/
            StartCoroutine(reactivarBajar());
        }
        
    }
   
    IEnumerator reactivarBajar()
    {

        float aux=tiempoRestante+ Time.deltaTime * 5;
        bajar = false;

        while (tiempoRestante<aux&& tiempoRestante < tiempoVivoMax) {

            tiempoRestante += Time.deltaTime;
            vidaImagen.fillAmount = tiempoRestante / tiempoVivoMax;
            yield return new WaitForSeconds(0.1f);

        }

        if (tiempoRestante > tiempoVivoMax)
            tiempoRestante = tiempoVivoMax;
        //  Debug.Log("destruir en 1 sec");

      //  yield return new WaitForSeconds(0.1f);
        //   Debug.Log("destruido");
        bajar = true;


    }
}
