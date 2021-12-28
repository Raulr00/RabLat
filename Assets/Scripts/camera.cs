using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Vector3 posCam;
    public Transform jug;
    private void Start()
    {
        transform.LookAt(jug, Vector3.up);
    }

    void Update()
    {
        transform.position = jug.position + posCam;
      
    }
}
