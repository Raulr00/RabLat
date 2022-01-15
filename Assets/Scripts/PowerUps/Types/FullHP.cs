using System;
using UnityEngine;

namespace PowerUps.Types
{
    public class FullHP : PowerUp
    {
        public static event PowerUpEvent fullHpEvent;

        private void OnCollisionEnter(Collision other)
        {
            SFXManager.Instance.PlaySound(SFXManager.Sound.PowerUp);
            fullHpEvent?.Invoke();
            Destroy(gameObject);
        }
    }
}