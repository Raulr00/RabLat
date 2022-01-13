using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popup : MonoBehaviour
{
    bool unaVez = true;
    public GameObject uitutorial;
    public static bool mov;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

  public  void reactivarGame() {
        Time.timeScale = 1;
        Destroy(gameObject);
        Debug.Log("Hola");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("player") && unaVez)
        {
            unaVez = false;
            Time.timeScale = 0;
            uitutorial.SetActive(true);
            Debug.Log("Sale mensaje AD");
        }
    }
}
