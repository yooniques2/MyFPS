using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace MyFPS
{
    public class HEnemyZoneOutTrigger : MonoBehaviour
    {
        #region Variables
        public Transform gunMan;
        public GameObject enemyZoneIn;  //in 트리거

        #endregion


        private void OnTriggerEnter(Collider other)
        {
           if (other.tag == "Player")
            {
                if (gunMan != null)
                {
                gunMan.GetComponent<Enemy>().GoStartPosition();

                }
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Player")
            {
                this.gameObject.SetActive(false);
                enemyZoneIn.SetActive(true);
            }
        }
    }

}