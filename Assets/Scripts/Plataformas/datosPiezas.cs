using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class datosPiezas : MonoBehaviour
{
    public enum Direcciones { 
    sur,sur2,sur3,
    oeste,oeste2,oeste3,
    norte,norte2,norte3,
    este,este2,este3
    }

    public Vector2 tamano = new Vector2(9.89f, 8.05f);
    public GameObject[] prefabsLvl;
    public Direcciones entrada;
    public Direcciones salida;

    
    }

