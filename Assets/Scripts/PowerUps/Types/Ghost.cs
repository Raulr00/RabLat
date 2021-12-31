﻿using System;
using System.Collections;
using System.Net.NetworkInformation;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace PowerUps.Types
{
    public class Ghost : PowerUp
    {
        public float duration = 10;
        private void OnCollisionEnter(Collision other)
        {
            if(!other.gameObject.name.Equals("player")) return;
            SetLayerRecusively(other.gameObject, 10);
            StartCoroutine(ReturnToNormal(other.gameObject));
            HidePowerUp();
        }
        
        private IEnumerator ReturnToNormal(GameObject player)
        {
            Debug.Log("Ghost mode on");
            yield return new WaitForSeconds(duration);
            Debug.Log("Se comienza a cambiar la layer otra vez");
            SetLayerRecusively(player, 7);
            Debug.Log("Fin del ghost");
            Destroy(gameObject);
        }

        private void HidePowerUp()
        {
            GetComponent<Collider>().enabled = false;
            foreach (Transform child in gameObject.transform)
            {
                child.gameObject.SetActive(false);
            }
        }

        private void SetLayerRecusively(GameObject obj, int newLayer)
        {
            if(obj == null) return;
            obj.layer = newLayer;
            foreach (Transform child in obj.transform)
            {
                if(child == null) continue;
                SetLayerRecusively(child.gameObject, newLayer);
            }
        }

       
    }
}