using System.Collections;
using TMPro;
using UnityEngine;

namespace MyFPS
{

    public class OpenHiddenDoor : Interactive
    {

        #region Variables

        public GameObject emptyPicture;
        public GameObject fullPicture;

        public Animator exitWallAnimator;

        public TextMeshProUGUI textBox;
        //sequence UI
        [SerializeField]
        private string puzzleStr = "I need to find all puzzle pieces";

        public GameObject exitTrigger;
        #endregion
        protected override void DoAction()
        {
            //퍼즐조각을 모두 모았는지 확인
            if (PlayerStats.Instance.HasPuzzleItem(PuzzleKey.LEFTEYE_KEY) && PlayerStats.Instance.HasPuzzleItem(PuzzleKey.RIGHTEYE_KEY))
            {
                //gameObject.
                StartCoroutine(OpenExitWall());
            }
            else
            {
                //메세지 출력
                StartCoroutine(LockedExitWall());
            }

        }
        IEnumerator OpenExitWall()
        {
            //완성본 그림 보이기

            emptyPicture.SetActive(false);
            fullPicture.SetActive(true);

            yield return new WaitForSeconds(1f);

            exitWallAnimator.SetBool("IsOpen", true);
            yield return new WaitForSeconds(0.5f);


            //exit 트리거 활성화
            exitTrigger.SetActive(true);

        }

        IEnumerator LockedExitWall()
        {
            unInteractive = true;

            textBox.gameObject.SetActive(true);
            textBox.text = puzzleStr;

            yield return new WaitForSeconds(1f);

            textBox.text = "";
            textBox.gameObject.SetActive(false);

            unInteractive = false;

        }
    }
}