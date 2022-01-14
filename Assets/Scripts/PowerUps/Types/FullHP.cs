using System;
using UnityEngine;

namespace PowerUps.Types
{
    public class FullHP : PowerUp
    {
        public static event PowerUpEvent fullHpEvent;

        private void OnCollisionEnter(Collision other)
        {
            fullHpEvent?.Invoke();
            Destroy(gameObject);
        }
    }
}