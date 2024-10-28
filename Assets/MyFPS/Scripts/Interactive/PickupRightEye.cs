using UnityEngine;

namespace MyFPS
{

    public class PickupRightEye : PickupPuzzleItem
    {
        #region Variables
        public GameObject fakeWall;
        public GameObject exitWall;
        #endregion

        protected override void DoAction()
        {
            StartCoroutine(GainPuzzleItem());

            ShowExitWall();
            
        }
        private void ShowExitWall()
        {
            if (PlayerStats.Instance.HasPuzzleItem(PuzzleKey.LEFTEYE_KEY) && PlayerStats.Instance.HasPuzzleItem(PuzzleKey.RIGHTEYE_KEY))
            {
                fakeWall.SetActive(false);
                exitWall.SetActive(true);
            }
        }
    }

}