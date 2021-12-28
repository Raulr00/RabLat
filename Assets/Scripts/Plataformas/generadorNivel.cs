using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generadorNivel : MonoBehaviour
{

    public GameObject jugador;
    int distanciaIncDif = 100;

    public datosPiezas[] piezas;
    public datosPiezas primeraPieza;
    private datosPiezas piezaAnt;

    public Vector3 spawnOrigen;
    private Vector3 spawnPos;
    public int piezasIniciales=10;

    float alturaJuego=0;
    float alturaSpawnPlat = 0;
    float des = 0;

    public GameObject padreMapa;//para la rotacion

    public int dificultadActual=1;

    private void OnEnable()
    {
        destruirPlat.salidaPieza += elegeirYspawnPieza;
    }

    private void OnDisable()
    {
        destruirPlat.salidaPieza -= elegeirYspawnPieza;
    }


    // Start is called before the first frame update
    void Start()
    {
        piezaAnt = primeraPieza;
        for (int i = 0; i < piezasIniciales; i++) {
            elegeirYspawnPieza();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (jugador.transform.position.z > distanciaIncDif&& distanciaIncDif<300) {
            distanciaIncDif += 100;
            dificultadActual++;
        }

    }

    void elegeirYspawnPieza() {
        datosPiezas piezaSpawn = elegirSigPieza();

        GameObject prefab = piezaSpawn.prefabsLvl[Random.Range(0, piezaSpawn.prefabsLvl.Length)];

        while (prefab.GetComponent<infoPieza>().dificultadPieza > dificultadActual) {
            prefab = piezaSpawn.prefabsLvl[Random.Range(0, piezaSpawn.prefabsLvl.Length)];
        }
        
        
       GameObject objeto= Instantiate(prefab, spawnPos + spawnOrigen, prefab.transform.rotation);
        if (prefab.tag.Equals("rampa"))
        {
            Debug.Log(objeto.name);
            alturaSpawnPlat = 1.7f;
            objeto.transform.position = new Vector3(objeto.transform.position.x,   objeto.transform.position.y+alturaSpawnPlat, objeto.transform.position.z);
            des = des + 1;//ESTO ES LA ALTURA DE LAS PLATAFORMAS
            spawnPos = new Vector3(spawnPos.x, spawnPos.y + 2.6f, spawnPos.z);
        }
        objeto.transform.SetParent(padreMapa.transform);
        piezaAnt = piezaSpawn;


        

    }

    datosPiezas elegirSigPieza() {
        List<datosPiezas> piezasPermitidas = new List<datosPiezas>();
        datosPiezas sigPieza = null;

        datosPiezas.Direcciones sigPoscionesEntrada = datosPiezas.Direcciones.norte;

        switch (piezaAnt.salida) {
            case datosPiezas.Direcciones.norte:
                sigPoscionesEntrada = datosPiezas.Direcciones.sur;
                spawnPos = spawnPos + new Vector3(0, 0, piezaAnt.tamano.x);
                break;

            case datosPiezas.Direcciones.este:
                sigPoscionesEntrada = datosPiezas.Direcciones.oeste;
                spawnPos = spawnPos + new Vector3(piezaAnt.tamano.x, 0, 0);

                break;
            case datosPiezas.Direcciones.sur:
                sigPoscionesEntrada = datosPiezas.Direcciones.norte;
                spawnPos = spawnPos + new Vector3(0, 0, -piezaAnt.tamano.y);


                break;

            case datosPiezas.Direcciones.oeste:
                sigPoscionesEntrada = datosPiezas.Direcciones.este;
                spawnPos = spawnPos + new Vector3(-piezaAnt.tamano.x, 0, 0);

                break;
        }

        for (int i = 0; i < piezas.Length; i++) {
            if (piezas[i].entrada == sigPoscionesEntrada) {
                piezasPermitidas.Add(piezas[i]);
            }
        }

        sigPieza = piezasPermitidas[Random.Range(0, piezasPermitidas.Count)];

        return sigPieza;
    }

    public void updateOrigenSpawn(Vector3 delta) {
        spawnOrigen = spawnOrigen + delta;
    }

     

    

}