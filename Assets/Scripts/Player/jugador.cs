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

       public int moves = 0;
        public float velPersonaje = 10;
        public float minVel = 10;
        public int[] direccion = {0, 1, 2, 3};


        int aux = 0;
        float offsetZ = 0;

        [SerializeField]public GameObject magnet;

        public GameObject popup;
        void Awake()
        {
            if (PlayerPrefs.GetString("tuto", "true").Equals("true"))
            {
                popup.SetActive(true);
            }
            else {
                popup.SetActive(false);
            }



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
            Debug.Log("empezar llamado");
            GameManager.moverse = true;
            animator.SetBool("Run", true);

            if (PlayerPrefs.GetString("tuto", "True").Equals("True"))
            {
                popup.SetActive(true);
            }
            else
            {
                popup.SetActive(false);
            }
        }

        private void OnEnable()
        {
            Slow.slowEvent += HanldeSlowPwrUp;
            //    menuPrincipal.empezarPartida += empezar;
            Magnet.magnetEvent += HandleMagnetPwrUp;


            menuPrincipal.empezarPartida += empezar;

        }

        private void OnDisable()
        {
            Slow.slowEvent -= HanldeSlowPwrUp;
            Magnet.magnetEvent -= HandleMagnetPwrUp;
            menuPrincipal.empezarPartida -= empezar;
        }

        private void HandleMagnetPwrUp(float f)
        {
            if(magnet == null) return;
            magnet.SetActive(true);
            StartCoroutine(BackToNormal(f));
        }

        private IEnumerator BackToNormal(float secs)
        {
            yield return new WaitForSeconds(secs);
            magnet.SetActive(false);
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
        private void FixedUpdate()
        {
            if (!GameManager.moverse)
                return;
            Quaternion acce = Input.gyro.attitude;
            Vector3 dir = Vector3.zero;
            dir = Input.acceleration;
            if (dir.sqrMagnitude > 1)
                dir.Normalize();

            Vector3 direccion = Vector3.zero;

            // Debug.Log(transform.forward);


            if (moves == 1)
            {


                // Debug.Log("4 " + dir.z);
                int zzz = (int)(Input.acceleration.z * 10);
                /// Debug.Log("5 " + zzz);
                // Debug.Log("6 " + ((float)zzz / 10));
                float auxx = (float)zzz / 10;
                Debug.Log("6 " + auxx);
                direccion = new Vector3(gameObject.transform.forward.x, gameObject.transform.forward.y,
                    gameObject.transform.forward.z - dir.x);

                // Debug.Log(dir.z+" "+ offsetZ);
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
                GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + direccion * velPersonaje * Time.deltaTime);
                // int i = (int) transform.forward.x;



                //  transform.position += direccion  * Time.deltaTime*2f;
                //  GetComponent<Rigidbody>().MovePosition(transform.position + direccion * velPersonaje * Time.deltaTime);
            }
            else if (moves == 2)
            {
                //   texto.text = "FALSO";

                direccion = new Vector3(gameObject.transform.forward.x + dir.x, gameObject.transform.forward.y,
                    gameObject.transform.forward.z);
                //  transform.Translate(direccion * Time.deltaTime /*velPersonaje*/, Space.World);

                GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + direccion * velPersonaje * Time.deltaTime);


                // transform.Translate(gameObject.transform.forward * Time.deltaTime * velPersonaje, Space.World);
                //  int i = (int)transform.forward.x;
            }
            else if (moves == 3)
            {
                //      texto.text = "FALSO";
                int zzz = (int)(Input.acceleration.z * 10);
                /// Debug.Log("5 " + zzz);
                // Debug.Log("6 " + ((float)zzz / 10));
                float auxx = (float)zzz / 10;
                direccion = new Vector3(gameObject.transform.forward.x, gameObject.transform.forward.y,
                gameObject.transform.forward.z + dir.x);

                GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + direccion * velPersonaje * Time.deltaTime);

                //  transform.Translate(direccion * Time.deltaTime /*velPersonaje*/, Space.World);
            }
        }
        void Update()
        {

            Debug.Log(Input.gyro.gravity);
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

                    // offsetZ = Input.acceleration.z;
                    offsetZ = Input.acceleration.z;

                    Debug.Log("1 " + offsetZ);
                    int zz = (int)(offsetZ * 10);
                    Debug.Log("2 " + zz);
                    Debug.Log("3 " + ((float)zz / 1000));
                    offsetZ = (float)zz / 10;

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
                    // offsetZ = Input.acceleration.z;
                    offsetZ = Input.acceleration.z;
                    
                    Debug.Log("1 " + offsetZ);
                    int zz = (int)(offsetZ * 10);
                    Debug.Log("2 " + zz);
                    Debug.Log("3 " + ((float)zz / 1000));
                    offsetZ = (float)zz / 10;


                }

                // camera.transform.RotateAround(gameObject.transform.position, new Vector3(0, 90, 0), 90);

                //   transform.rotation = Quaternion.RotateTowards(transform.rotation, new Quaternion(gameObject.transform.forward.x, gameObject.transform.forward.y, gameObject.transform.forward.z, 0), 720*Time.deltaTime);
                //  Debug.Log(gameObject.transform.forward);
            }
            else if (Input.GetKeyDown(KeyCode.W) || swipeMovil.swipeUp)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * 200f);
                SFXManager.Instance.PlaySound(SFXManager.Sound.Jump);
                animator.SetTrigger("Jump");
            }
            else if (Input.GetKeyDown(KeyCode.S) || swipeMovil.swipeDown)
            {
                gizmo.transform.localScale = new Vector3(1, 0.2f, 1);
                SFXManager.Instance.PlaySound(SFXManager.Sound.Swipe);
                animator.SetTrigger("Slide");
                StartCoroutine(agacharse());
            }


            //if (Input.GetKey(KeyCode.L)) {
            //    transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z);
            //} else if (Input.GetKey(KeyCode.J)) {
            //    transform.position = new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z);

            //}
          //  Quaternion acce = Input.gyro.attitude;
          //  Vector3 dir = Vector3.zero;
          //  dir = Input.acceleration;
          //  if (dir.sqrMagnitude > 1)
          //      dir.Normalize();

          //  Vector3 direccion = Vector3.zero;

          //// Debug.Log(transform.forward);


          //  if (moves == 1)
          //  {
               

          //      // Debug.Log("4 " + dir.z);
          //      int zzz = (int)(Input.acceleration.z * 10);
          //    /// Debug.Log("5 " + zzz);
          //     // Debug.Log("6 " + ((float)zzz / 10));
          //      float auxx = (float)zzz / 10;
          //      Debug.Log("6 "+auxx);
          //      direccion = new Vector3(gameObject.transform.forward.x, gameObject.transform.forward.y,
          //          gameObject.transform.forward.z - dir.x);

          //     // Debug.Log(dir.z+" "+ offsetZ);
          //      //  transform.Translate(direccion * Time.deltaTime /* velPersonaje*/, Space.World);
          //      //transform.Translate(gameObject.transform.forward * Time.deltaTime * velPersonaje, Space.World);

          //      //    Debug.Log(direccion * velPersonaje * Time.deltaTime);
          //      // transform.position += direccion * velPersonaje * Time.deltaTime;
          //      GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + direccion * velPersonaje * Time.deltaTime);

          //      // GetComponent<Rigidbody>().MovePosition(transform.position + direccion * velPersonaje * Time.deltaTime);

          //  }
          //  else if (moves == 0)
          //  {
          //      //         texto.text = "FALSO";

          //      direccion = new Vector3(gameObject.transform.forward.x + dir.x, gameObject.transform.forward.y,
          //          gameObject.transform.forward.z);
          //    //  Debug.Log("fnwiefl");
          //      // transform.Translate(direccion * Time.deltaTime /*velPersonaje*/, Space.World);
          //      //transform.position += direccion * velPersonaje * Time.deltaTime;
          //     GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position+ direccion * velPersonaje * Time.deltaTime);
          //      // int i = (int) transform.forward.x;

                

          //      //  transform.position += direccion  * Time.deltaTime*2f;
          //    //  GetComponent<Rigidbody>().MovePosition(transform.position + direccion * velPersonaje * Time.deltaTime);
          //  }
          //  else if (moves == 2)
          //  {
          //      //   texto.text = "FALSO";

          //      direccion = new Vector3(gameObject.transform.forward.x + dir.x, gameObject.transform.forward.y,
          //          gameObject.transform.forward.z) ;
          //      //  transform.Translate(direccion * Time.deltaTime /*velPersonaje*/, Space.World);

          //      GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + direccion * velPersonaje * Time.deltaTime);


          //      // transform.Translate(gameObject.transform.forward * Time.deltaTime * velPersonaje, Space.World);
          //      //  int i = (int)transform.forward.x;
          //  }
          //  else if (moves == 3)
          //  {
          //      //      texto.text = "FALSO";
          //      int zzz = (int)(Input.acceleration.z * 10);
          //      /// Debug.Log("5 " + zzz);
          //      // Debug.Log("6 " + ((float)zzz / 10));
          //      float auxx = (float)zzz / 10;
          //      direccion = new Vector3(gameObject.transform.forward.x, gameObject.transform.forward.y,
          //      gameObject.transform.forward.z + dir.x);

          //      GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + direccion * velPersonaje * Time.deltaTime);

          //      //  transform.Translate(direccion * Time.deltaTime /*velPersonaje*/, Space.World);
          //  }



            //  transform.Translate(gameObject.transform.forward*Time.deltaTime* velPersonaje, Space.World);
            //   transform.Translate(direccion * Time.deltaTime * velPersonaje, Space.World);
        }

        IEnumerator agacharse()
        {
            

            yield return new WaitForSeconds(1f);
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