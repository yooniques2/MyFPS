using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFPS
{

    public class GEnemyZoneInTrigger : MonoBehaviour
    {
        #region Variables
        public Transform gunMan;

        public GameObject enemyZoneOut;
        #endregion
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                if (gunMan != null)
                {
                gunMan.GetComponent<Enemy>().SetState(EnemyState.E_Chase);

                }

            }

        }
        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Player")
            {
                //gunMan제자리로 다시
                this.gameObject.SetActive(false);
                enemyZoneOut.SetActive(true);

            }
        }
    }

}