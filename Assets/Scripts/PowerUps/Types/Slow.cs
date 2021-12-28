using System;
using UnityEngine;

namespace PowerUps.Types
{
    public class Slow : PowerUp
    {
        public delegate void SlowEvent(float f);
        public static event SlowEvent slowEvent;

        public float slow = 4;

        private void OnCollisionEnter(Collision other)
        {
            slowEvent?.Invoke(slow);
            Destroy(gameObject);
        }
    }
}