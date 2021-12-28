using System;
using UnityEngine;

namespace PowerUps
{
    public class PowerUp: MonoBehaviour
    {
        public string id;
        
        public delegate void PowerUpEvent();
    }
}