using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MySample
{

public class CameraController : MonoBehaviour
{
        #region Variables
        public Transform thePlayer;

        [SerializeField] private Vector3 offset;

        #endregion
        private void LateUpdate()
        {
            this.transform.position = thePlayer.position + offset;
        }
    }

}