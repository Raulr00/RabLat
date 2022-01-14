﻿using System;
using UnityEngine;

namespace PowerUps.Types
{
    public class PointsX2 : PowerUp
    {
        public static event PowerUpEvent ptsx2Event; 
        private void OnCollisionEnter(Collision other)
        {
            ptsx2Event?.Invoke();
            Destroy(gameObject);
        }
    }
}