using System.Collections;
using System.Collections.Generic;
using coins;
using PowerUps.Types;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
public class vida : MonoBehaviour
{
    Image vidaImagen;
    public float tiempoVivoMax;
    float tiempoRestante;
    bool bajar = true;

    private void OnEnable()
    {
        monedas.monedaRecodiga += sumarVida;
        FullHP.fullHpEvent += HandleFullHP;
    }

    private void OnDisable()
    {
        monedas.monedaRecodiga -= sumarVida;
        FullHP.fullHpEvent -= HandleFullHP;
    }

    private void HandleFullHP()
    {
        tiempoRestante = tiempoVivoMax;
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

            tiempoRestante -= Time.deltaTime*0.25f;
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

        float aux=tiempoRestante+ 0.5f;
        bajar = false;
      //  Debug.Log("1");
        /*while (tiempoRestante<aux&& tiempoRestante < tiempoVivoMax) {

            tiempoRestante += Time.deltaTime*0.6f;
            vidaImagen.fillAmount = tiempoRestante / tiempoVivoMax;
            yield return new WaitForSeconds(0.1f);

        }*/
        tiempoRestante=tiempoRestante + 0.1f;
        yield return new WaitForSeconds(0.1f);
        if (tiempoRestante > tiempoVivoMax)
            tiempoRestante = tiempoVivoMax;
        //  Debug.Log("destruir en 1 sec");

        //  yield return new WaitForSeconds(0.1f);
        //   Debug.Log("destruido");
      //  Debug.Log("2");
        bajar = true;

    }
}
