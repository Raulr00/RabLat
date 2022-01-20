using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace PowerUps.Types
{
    public class Ghost : PowerUp
    {
        public float duration = 10;
        public Material ghostMat;
        public Material normalMat;
        private void OnCollisionEnter(Collision other)
        {
            if(!other.gameObject.name.Equals("player")) return;            
            SFXManager.Instance.PlaySound(SFXManager.Sound.PowerUp);
            GameObject.Find("Rat").transform.GetChild(0).GetComponent<Renderer>().material = ghostMat;
            SetLayerRecusively(other.gameObject, 10);
            StartCoroutine(ReturnToNormal(other.gameObject));
            HidePowerUp();
            // Animacion UI
            StartCoroutine(ponerAnim());
        }
        IEnumerator ponerAnim() {
            GameObject g = GameObject.Find("ghostAnim");
            g.GetComponent<Animator>().enabled = true;
            g.GetComponent<Animator>().Play("Entry");


            yield return new WaitForSeconds(10f);
            // g.GetComponent<Image>().enabled = false;

            // g.GetComponent<Image>().enabled=true;
            g.GetComponent<Animator>().enabled = false;
            g.GetComponent<Image>().enabled = false;

        }

        private IEnumerator ReturnToNormal(GameObject player)
        {
            Debug.Log("Ghost mode on");
            yield return new WaitForSeconds(duration);
            Debug.Log("Se comienza a cambiar la layer otra vez");
            SetLayerRecusively(player, 7);
            Debug.Log("Fin del ghost");
            GameObject.Find("Rat").transform.GetChild(0).GetComponent<Renderer>().material = normalMat;
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
                if(child == null || child.gameObject.CompareTag("Magnet")) continue;
                SetLayerRecusively(child.gameObject, newLayer);
            }
        }

       
    }
}