using System;
using UnityEngine;

namespace PowerUps.Types
{
    public class PointsX2 : PowerUp
    {
        public static event PowerUpEvent ptsx2Event; 
        private void OnCollisionEnter(Collision other)
        {
            SFXManager.Instance.PlaySound(SFXManager.Sound.PowerUp);
            ptsx2Event?.Invoke();
            Destroy(gameObject);
        }
    }
}