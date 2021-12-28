using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popup : MonoBehaviour
{
    bool unaVez = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!unaVez && Input.GetKeyDown(KeyCode.P)) {
            Time.timeScale = 1;
            Destroy(gameObject);


        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("player") && unaVez)
        {
            unaVez = false;
            Time.timeScale = 0;
            Debug.Log("Sale mensaje AD");
        }
    }
}
