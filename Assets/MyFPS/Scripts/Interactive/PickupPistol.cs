using TMPro;
using UnityEngine;

namespace MyFPS
{
    public class PickupPistol : Interactive
    {
        #region Variables
        //action
        public GameObject realPistol;
        public GameObject arrow;
        
        public GameObject enemyTrigger;

        public GameObject ammoUI;
        public GameObject ammoBox;
        public GameObject ammoArrow;

        #endregion
        protected override void DoAction()
        {
            //Action
            arrow.SetActive(false);
            ammoBox.SetActive(true);
            ammoArrow.SetActive(true);

            enemyTrigger.SetActive(true);

            PlayerStats.Instance.SetHasGun(true);
            ammoUI.SetActive(true );
            realPistol.SetActive(true);

            Destroy(gameObject);



        }

    }
}

/*
public class PickupPistol : MonoBehaviour
{
        #region Variables
        private float theDistance;

        //action UI
        public GameObject actionUI;
        public TextMeshProUGUI actionText;
        [SerializeField] private string action = "Pick Up the Pistol";
        public GameObject extraCross;

        //Action
        public GameObject realPistol;
        public GameObject arrow;

        #endregion

        private void Update()
        {
        theDistance = PlayerCasting.distanceFromTarget;

        }
        private void OnMouseOver()
        {
            //거리가 2이하 일때
            if (theDistance <= 2f)
            {
                showActionUI();

                if (Input.GetButtonDown("Action"))
                {
                    HideActionUI();

                    DoAction();
                }
            }
            else
            {
                HideActionUI();
            }

        }
        private void OnMouseExit()
        {

        }
        void showActionUI()
        {
            actionUI.SetActive(true);
            actionText.text = action;
            extraCross.SetActive(true);
        }

        void HideActionUI()
        {
            actionUI.SetActive(false);
            actionText.text = "";
            extraCross.SetActive(false);

        }
        void DoAction()
        {
            //Action
            realPistol.SetActive(true);
            arrow.SetActive(false);
            Destroy(gameObject);
        }
    }*/

