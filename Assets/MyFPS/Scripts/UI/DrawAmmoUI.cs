using TMPro;
using UnityEngine;

namespace MyFPS
{

    public class DrawAmmoUI : MonoBehaviour
    {
        #region Variables
        public TextMeshProUGUI ammoCount;
        #endregion

        // Update is called once per frame
        void Update()
        {
            ammoCount.text = PlayerStats.Instance.AmmoCount.ToString();

        }
    }

}