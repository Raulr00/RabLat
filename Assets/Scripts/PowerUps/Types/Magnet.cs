using System;
using UnityEngine;

namespace PowerUps.Types
{
    public class Magnet : PowerUp
    {
        public delegate void MagnetEvent(float f);
        public static event MagnetEvent magnetEvent;

        public float duration = 10;
        private void OnCollisionEnter(Collision other)
        {
            magnetEvent?.Invoke(duration);
            Destroy(gameObject);
        }
    }
}