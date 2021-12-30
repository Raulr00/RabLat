using System;
using System.Collections;
using System.Collections.Generic;
using PowerUps.Types;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class jugador : MonoBehaviour
    {
        public GameObject mapa;
        public GameObject gizmo;
        private Animator animator;


        Vector3 desplazamiento;

        public GameObject camera;

        int moves = 0;
        public float velPersonaje = 10;
        public float minVel = 10;
        public int[] direccion = {0, 1, 2, 3};


        int aux = 0;
        float offsetZ = 0;




        void Awake()
        {
            animator = GetComponentInChildren<Animator>();
            animator.SetBool("Run", false);

            if (GameManager.moverse)
            {
                animator.SetBool("Run", true);
            }
            desplazamiento = new Vector3(0, 0, 0.01f);
            StartCoroutine(aumentarVelcidad());
            
         //   Debug.Log(transform.forward);
        }

        private void OnDestroy()
        {
            menuPrincipal.empezarPartida -= empezar;
        }

        //Se llama cuando se le da play
        void empezar() {
            GameManager.moverse = true;
            animator.SetBool("Run", true);
        }

        private void OnEnable()
        {
            Slow.slowEvent += HanldeSlowPwrUp;
            //    menuPrincipal.empezarPartida += empezar;


            menuPrincipal.empezarPartida += empezar;

        }

        private void OnDisable()
        {
            Slow.slowEvent -= HanldeSlowPwrUp;
            menuPrincipal.empezarPartida -= empezar;
        }

        [ContextMenu("HandleSlow")]
        private void HanldeSlowPwrUp(float slow)
        {
            velPersonaje -= slow;
            if (velPersonaje < minVel)
            {
                velPersonaje = minVel;
            }
        }

        // Update is called once per frame

        void Update()
        {
          //  Debug.Log("anim idle");
            if (!GameManager.moverse)
                return;


            //  Debug.Log("Vel personaje " + GetComponent<Rigidbody>().velocity);
            if (Input.GetKeyDown(KeyCode.A) || swipeMovil.swipeLeft)
            {
                moves = (moves - 1);
                if (moves < 0)
                {
                    moves = 3;
                }

                if (moves == 1 || moves == 3)
                {
                    offsetZ = Input.acceleration.z;
                }

                transform.Rotate(new Vector3(0, -90, 0));
               // Debug.Log(transform.forward);

                //    camera.transform.RotateAround(gameObject.transform.position,new Vector3(0, -90, 0),-90);
                //   transform.rotation = Quaternion.RotateTowards(transform.rotation, new Quaternion(gameObject.transform.forward.x, gameObject.transform.forward.y, gameObject.transform.forward.z, 0), 720 * Time.deltaTime);

                //  Debug.Log(gameObject.transform.forward);
            }
            else if (Input.GetKeyDown(KeyCode.D) || swipeMovil.swipeRight)
            {
                moves = (moves + 1) % 4;
                transform.Rotate(new Vector3(0, 90, 0));
              //  Debug.Log(transform.forward);

                if (moves == 1 || moves == 3)
                {
                    offsetZ = Input.acceleration.z;



                }

                // camera.transform.RotateAround(gameObject.transform.position, new Vector3(0, 90, 0), 90);

                //   transform.rotation = Quaternion.RotateTowards(transform.rotation, new Quaternion(gameObject.transform.forward.x, gameObject.transform.forward.y, gameObject.transform.forward.z, 0), 720*Time.deltaTime);
                //  Debug.Log(gameObject.transform.forward);
            }
            else if (Input.GetKeyDown(KeyCode.W) || swipeMovil.swipeUp)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * 200f);
                ;
                animator.SetTrigger("Jump");
            }
            else if (Input.GetKeyDown(KeyCode.S) || swipeMovil.swipeDown)
            {
                gizmo.transform.localScale = new Vector3(1, 0.6f, 1);
                animator.SetTrigger("Slide");
                StartCoroutine(agacharse());
            }


            //if (Input.GetKey(KeyCode.L)) {
            //    transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z);
            //} else if (Input.GetKey(KeyCode.J)) {
            //    transform.position = new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z);

            //}
            Vector3 acce = Input.acceleration;
            Vector3 dir = Vector3.zero;
            dir = Input.acceleration;
            if (dir.sqrMagnitude > 1)
                dir.Normalize();

            Vector3 direccion = Vector3.zero;

            // Debug.Log((int)transform.forward.x == 1);


            if (moves == 1)
            {
                direccion = new Vector3(gameObject.transform.forward.x, gameObject.transform.forward.y,
                    gameObject.transform.forward.z - (dir.z - offsetZ));

                Debug.Log(dir.z+" "+ offsetZ);
                //  transform.Translate(direccion * Time.deltaTime /* velPersonaje*/, Space.World);
                //transform.Translate(gameObject.transform.forward * Time.deltaTime * velPersonaje, Space.World);

                //    Debug.Log(direccion * velPersonaje * Time.deltaTime);
                // transform.position += direccion * velPersonaje * Time.deltaTime;
                GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + direccion * velPersonaje * Time.deltaTime);

                // GetComponent<Rigidbody>().MovePosition(transform.position + direccion * velPersonaje * Time.deltaTime);

            }
            else if (moves == 0)
            {
                //         texto.text = "FALSO";


                direccion = new Vector3(gameObject.transform.forward.x + dir.x, gameObject.transform.forward.y,
                    gameObject.transform.forward.z);
              //  Debug.Log("fnwiefl");
                // transform.Translate(direccion * Time.deltaTime /*velPersonaje*/, Space.World);
                //transform.position += direccion * velPersonaje * Time.deltaTime;
               GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position+ direccion * velPersonaje * Time.deltaTime);
                // int i = (int) transform.forward.x;

                

                //  transform.position += direccion  * Time.deltaTime*2f;
              //  GetComponent<Rigidbody>().MovePosition(transform.position + direccion * velPersonaje * Time.deltaTime);
            }
            else if (moves == 2)
            {
                //   texto.text = "FALSO";

                direccion = new Vector3(gameObject.transform.forward.x + dir.x, gameObject.transform.forward.y,
                    gameObject.transform.forward.z) ;
                //  transform.Translate(direccion * Time.deltaTime /*velPersonaje*/, Space.World);

                GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + direccion * velPersonaje * Time.deltaTime);


                // transform.Translate(gameObject.transform.forward * Time.deltaTime * velPersonaje, Space.World);
                //  int i = (int)transform.forward.x;
            }
            else if (moves == 3)
            {
                //      texto.text = "FALSO";

                direccion = new Vector3(gameObject.transform.forward.x, gameObject.transform.forward.y,
                gameObject.transform.forward.z - (dir.z - offsetZ));

                GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + direccion * velPersonaje * Time.deltaTime);

                //  transform.Translate(direccion * Time.deltaTime /*velPersonaje*/, Space.World);
            }



            //  transform.Translate(gameObject.transform.forward*Time.deltaTime* velPersonaje, Space.World);
            //   transform.Translate(direccion * Time.deltaTime * velPersonaje, Space.World);
        }

        IEnumerator agacharse()
        {
            while (gizmo.transform.localScale.y == 0.6f)
            {
                gizmo.transform.localScale = new Vector3(1, gizmo.transform.localScale.y - 0.1f, 1);
                yield return new WaitForSeconds(0.1f);
            }

            yield return new WaitForSeconds(0.5f);
            gizmo.transform.localScale = new Vector3(1, 1, 1);
        }

        IEnumerator aumentarVelcidad()
        {
            while (velPersonaje < 15)
            {
                yield return new WaitForSeconds(2f); //Tardo 100 segundo (1' 30'') en llegar a la max velocidad

                velPersonaje += 0.1f;
            }
        }
    }
}