using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace coins
{
    public class monedas : MonoBehaviour
    {
        public delegate void monedaCogida();

        public static event monedaCogida monedaRecodiga;
        bool unaVez = true;

        void Start()
        {
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.name.Equals("player") && unaVez)
            {
                monedaRecodiga?.Invoke();
                unaVez = false;
                Destroy(gameObject);
            }
        }

        // Update is called once per frame
        void Update()
        {
        }
    }
}