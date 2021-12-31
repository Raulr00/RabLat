using System;
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
        private Vector3 playerPos;
        private bool magnetized = false;
        public float magSpeed = 1;

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
            else if (other.CompareTag("Magnet"))
            {
                playerPos = other.GetComponentInParent<Transform>().position;
            }
        }

        private void OnCollisionStay(Collision other)
        {
            if (other.gameObject.CompareTag("Magnet"))
            {
                playerPos = other.gameObject.GetComponentInParent<Transform>().position;
            }
        }

        private void FixedUpdate()
        {
            if (magnetized)
            {
                Vector3 dir = playerPos - transform.position;
                transform.Translate(dir.normalized * magSpeed * Time.fixedDeltaTime);
            }
        }

        // Update is called once per frame
        void Update()
        {
        }
    }
}