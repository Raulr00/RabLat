using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkGround : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool isGrounded = true;

    private void OnTriggerEnter(Collider other)
    {
       
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("cg"))
        {
            isGrounded = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("cg"))
        {
            isGrounded = false;
        }
    }

}
