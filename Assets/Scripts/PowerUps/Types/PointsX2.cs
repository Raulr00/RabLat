using System;
using UnityEngine;

namespace PowerUps.Types
{
    public class PointsX2 : PowerUp
    {
        public delegate void PointsX2Even();
        public static event PointsX2Even ptsx2Event; 
        private void OnCollisionEnter(Collision other)
        {
            ptsx2Event?.Invoke();
            Destroy(gameObject);
        }
    }
}