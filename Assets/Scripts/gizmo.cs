using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gizmo : MonoBehaviour
{
    // Start is called before the first frame update
    public float gizmoTam = 0.75f;
    public Color gizmoColor = Color.yellow;
    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireSphere(transform.position, gizmoTam);
    }

    private void Update()
    {

    }
}
