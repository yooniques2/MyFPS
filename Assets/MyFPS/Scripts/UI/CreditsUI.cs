using UnityEngine;

namespace MyFPS
{

    public class CreditsUI : MonoBehaviour
    {
        #region Variables
        public GameObject mainMenuUI;

        #endregion

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                HideCredits();
            }
            }
            private void HideCredits()
        {
            mainMenuUI.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }

}