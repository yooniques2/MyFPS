using UnityEngine;
using TMPro;

namespace MyFPS
{

    public class DoorCellOpen : MonoBehaviour
    {
        #region Variables
        private float theDistance;

        //action UI
        public GameObject actionUI;
        public TextMeshProUGUI actionText;
        [SerializeField] private string action = "Open The Door";
        public GameObject ExtraCross;

        //action
        private Animator animator;
        private Collider m_collider;
        public AudioSource audioSource;
        #endregion

        private void Start()
        {
            animator = GetComponent<Animator>();
            m_collider = GetComponent<BoxCollider>();
        }

        private void Update()
        {
            theDistance = PlayerCasting.distanceFromTarget;
        }


        //마우스를 가져가면 액션 UI를 보여준다
        private void OnMouseOver()
        {
            //거리가 2이하 일때
            if (theDistance <= 2f)
            {
                showActionUI();

                if (Input.GetButtonDown("Action"))
                {
                    HideActionUI();

                    //문이 열리는 액션
                    animator.SetBool("IsOpen", true);
                    m_collider.enabled = false;
                    audioSource.Play();
                }
            }
            else
            {
                HideActionUI();
            }
        }


        //마우스가 벗어나면 액션 UI를 감춘다
        private void OnMouseExit()
        {
            HideActionUI();
        }

        void showActionUI()
        {
            actionUI.SetActive(true);
            actionText.text = action;
            ExtraCross.SetActive(true);
        }

        void HideActionUI()
        {
            actionUI.SetActive(false);
            actionText.text = "";
            ExtraCross.SetActive(false);

        }
    }

}