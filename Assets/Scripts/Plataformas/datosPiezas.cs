using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class datosPiezas : MonoBehaviour
{
    public enum Direcciones { 
    sur,
    oeste,
    norte,
    este
    }

    public Vector2 tamano = new Vector2(10f,10f);
    public GameObject[] prefabsLvl;
    public Direcciones entrada;
    public Direcciones salida;

    
    }

