using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destruirPlat : MonoBehaviour
{
    public delegate void ExitAction();
    public static event ExitAction salidaPieza;
    GameObject jugador;


    bool unaVez;
    // Start is called before the first frame update
    void Start()
    {
        unaVez = true;
        jugador = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z + 8 < jugador.transform.position.z) {
            Destroy(gameObject.transform.parent.gameObject);
            salidaPieza();
        }     
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name.Equals("player")&&unaVez) {
      //      unaVez = false;
     //       salidaPieza();
     //       StartCoroutine(destruir());
        }
    }

    IEnumerator destruir() {
      //  Debug.Log("destruir en 1 sec");

        yield return new WaitForSeconds(2f);
     //   Debug.Log("destruido");
        Destroy(gameObject.transform.parent.gameObject);
      
    
    }

}
