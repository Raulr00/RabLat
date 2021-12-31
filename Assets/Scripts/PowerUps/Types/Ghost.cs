using System;
using System.Collections;
using System.Net.NetworkInformation;
using UnityEngine;

namespace PowerUps.Types
{
    public class Ghost : PowerUp
    {
        public float duration = 10;
        private void OnCollisionEnter(Collision other)
        {
            other.gameObject.layer = 10;
            Destroy(gameObject);
            StartCoroutine(ReturnToNormal(other.gameObject));
        }

        private IEnumerator ReturnToNormal(GameObject player)
        {
            yield return new WaitForSeconds(duration);
            player.layer = 7;
        }
    }
}