using System;
using UnityEngine;

namespace PowerUps.Types
{
    public class Ghost : PowerUp
    {
        private void OnCollisionEnter(Collision other)
        {
            Debug.Log("Ghost mode on");
            Destroy(gameObject);
        }
    }
}