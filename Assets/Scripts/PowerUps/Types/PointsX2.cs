using System;
using UnityEngine;

namespace PowerUps.Types
{
    public class PointsX2 : PowerUp
    {
        public delegate void ptsX2Event();

        public static event ptsX2Event ptsx2Picked; 
        private void OnCollisionEnter(Collision other)
        {
            ptsx2Picked?.Invoke();
            Destroy(gameObject);
        }
    }
}