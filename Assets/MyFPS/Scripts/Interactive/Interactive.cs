using TMPro;
using UnityEngine;

namespace MyFPS
{
    //인터렉티브 액션을 구현하는 클래스
    public abstract class Interactive : MonoBehaviour
    {
        protected abstract void DoAction(); 

        #region Variables
        private float theDistance;

        //action UI
        public GameObject actionUI;
        public TextMeshProUGUI actionText;
        [SerializeField] private string action = "Action Text";
        public GameObject extraCross;


        //true면 interactive 기능을 정지
        protected bool unInteractive = false;
        #endregion

        private void Update()
        {
            theDistance = PlayerCasting.distanceFromTarget;
            
        }
       private void OnMouseOver()
        {
            //거리가 2이하 일때
            if (theDistance <= 2f && !unInteractive)
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
            HideActionUI();
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
    }
}

