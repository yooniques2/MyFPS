using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFPS
{

    public class EnemyZoneInTrigger : MonoBehaviour
    {
        #region Variables
        public Transform gunMan;
        #endregion
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                gunMan.GetComponent<Enemy>().SetState(EnemyState.E_Chase);
                //
            }
            
        }
    }

}