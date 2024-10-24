using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace MyFPS
{

    public class DoorKeyOpen : Interactive
    {

        #region Variables
        public TextMeshProUGUI textBox;
        //sequence UI
        [SerializeField]
        private string sequence = "I need a key";
        #endregion
        protected override void DoAction()
        {
            if (PlayerStats.Instance.HasPuzzleItem(PuzzleKey.ROOM01_KEY))
            {
                OpenDoor();
            }

            else
            {
                StartCoroutine( LockedDoor());
            }

        }
        void OpenDoor()
        {
            //문열기
            this.GetComponent<BoxCollider>().enabled = false;

            this.GetComponent<Animator>().SetBool("IsOpen", true);
            AudioManager.Instance.Play("DoorOpen");
        }

        IEnumerator LockedDoor()
        {
            //문 잠긴 소리

            unInteractive = true;   //인터랙티브 기능 정지
            //Debug.Log("I need a Key");
            AudioManager.Instance.Play("DoorLocked");

            yield return new WaitForSeconds(1f);

            textBox.gameObject.SetActive(true);
            textBox.text = sequence;

            yield return new WaitForSeconds(2f);

            textBox.gameObject.SetActive(false);
            textBox.text = "";

            unInteractive = false;      //인터랙티브 기능 복원

        }
    }

}