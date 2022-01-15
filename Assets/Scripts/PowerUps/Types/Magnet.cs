using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace PowerUps.Types
{
    public class Magnet : PowerUp
    {
        public delegate void MagnetEvent(float f);
        public static event MagnetEvent magnetEvent;

        public float duration = 10;
        private void OnCollisionEnter(Collision other)
        {
            SFXManager.Instance.PlaySound(SFXManager.Sound.PowerUp);
            magnetEvent?.Invoke(duration);
            Destroy(gameObject);
        }

    }
}