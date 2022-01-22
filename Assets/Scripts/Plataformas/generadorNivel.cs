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
    public static Vector3 spawnPos;
    public static Vector3 spawnInicialAux;

    public int piezasIniciales=10;

    float alturaSpawnPlat = 0;
    float des = 0;

    public GameObject padreMapa;//para la rotacion

    public int dificultadActual=1;

    private int countPwrUp = 0;
    private int pwrUpPlatforms = 10;

    private void OnEnable()
    {
        destruirPlat.salidaPieza += elegeirYspawnPieza;
        PowerUpSpawner.spawnEvent += resetPwrUpCounter;
    }

    private void OnDisable()
    {
        destruirPlat.salidaPieza -= elegeirYspawnPieza;
        PowerUpSpawner.spawnEvent -= resetPwrUpCounter;
    }


    // Start is called before the first frame update
    void Start()
    {
        spawnInicialAux = new Vector3(spawnPos.x, spawnPos.y, spawnPos.z);
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
          //  dificultadActual++;
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
           // Debug.Log(objeto.name);
            alturaSpawnPlat = 1.7f;
            objeto.transform.position = new Vector3(objeto.transform.position.x,   objeto.transform.position.y, objeto.transform.position.z);
            des = des + 1;//ESTO ES LA ALTURA DE LAS PLATAFORMAS
            spawnPos = new Vector3(spawnPos.x, spawnPos.y+1.94f, spawnPos.z);
        }
        objeto.transform.SetParent(padreMapa.transform);
        piezaAnt = piezaSpawn;
        if (objeto.GetComponentInChildren<PowerUpSpawner>() != null)
        {
            if (countPwrUp >= pwrUpPlatforms) { }
            //  Debug.Log("Tiene spawner");
            else { }
              //  Debug.Log("No tiene spawner");
            
            objeto.GetComponentInChildren<PowerUpSpawner>().spawnable = (countPwrUp >= pwrUpPlatforms);
        }
       
        countPwrUp++;
    }

    private void resetPwrUpCounter()
    {
        countPwrUp = 0;
    }

    datosPiezas elegirSigPieza() {
        List<datosPiezas> piezasPermitidas = new List<datosPiezas>();
        datosPiezas sigPieza = null;

        datosPiezas.Direcciones sigPoscionesEntrada = datosPiezas.Direcciones.norte;

      
        switch (piezaAnt.salida) {
            case datosPiezas.Direcciones.norte2:
                sigPoscionesEntrada = datosPiezas.Direcciones.sur2;
                spawnPos = spawnPos + new Vector3(0, 0, piezaAnt.tamano.x);
                break;
            case datosPiezas.Direcciones.norte3:
                sigPoscionesEntrada = datosPiezas.Direcciones.sur3;
                spawnPos = spawnPos + new Vector3(0, 0, piezaAnt.tamano.x);
                break;
            case datosPiezas.Direcciones.este:
                sigPoscionesEntrada = datosPiezas.Direcciones.oeste;
                //spawnPos = spawnPos + new Vector3(piezaAnt.tamano.x, 0, 0);
                spawnPos = spawnPos + new Vector3(piezaAnt.tamano.y, 0, 0);
                break;
            case datosPiezas.Direcciones.oeste:
                sigPoscionesEntrada = datosPiezas.Direcciones.este;
                // spawnPos = spawnPos + new Vector3(-piezaAnt.tamano.x, 0, 0);
                spawnPos = spawnPos + new Vector3(-piezaAnt.tamano.y, 0, 0);
                break;





         /*  
            case datosPiezas.Direcciones.norte:
                sigPoscionesEntrada = datosPiezas.Direcciones.sur;
                spawnPos = spawnPos + new Vector3(0, 0, piezaAnt.tamano.x);
                break;

            case datosPiezas.Direcciones.este:
                sigPoscionesEntrada = datosPiezas.Direcciones.oeste;
                //spawnPos = spawnPos + new Vector3(piezaAnt.tamano.x, 0, 0);
                spawnPos = spawnPos + new Vector3(piezaAnt.tamano.y, 0, 0);


                break;
            case datosPiezas.Direcciones.sur:
                sigPoscionesEntrada = datosPiezas.Direcciones.norte;
                spawnPos = spawnPos + new Vector3(0, 0, -piezaAnt.tamano.y);


                break;

            case datosPiezas.Direcciones.oeste:
                sigPoscionesEntrada = datosPiezas.Direcciones.este;
               // spawnPos = spawnPos + new Vector3(-piezaAnt.tamano.x, 0, 0);
                spawnPos = spawnPos + new Vector3(-piezaAnt.tamano.y, 0, 0);


                break;*/
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
