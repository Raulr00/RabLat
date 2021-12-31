using System;
using UnityEngine;

namespace PowerUps
{
    public class PowerUp: MonoBehaviour
    {
        public string id;
        public float rotSpeed = 1;
        
        public delegate void PowerUpEvent();

        private void FixedUpdate()
        {
            transform.Rotate(Vector3.up, rotSpeed);
        }
    }
}