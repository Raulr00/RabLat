using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class muerte : MonoBehaviour
{
     
    
    private void OnCollisionEnter(Collision collision)
    {
      
          if (collision.gameObject.tag.Equals("muerte")) {
            SceneManager.LoadScene("resultados");
        }

            
          }
    }



