using UnityEngine;

namespace MyFPS
{

    public class PickupKey : Interactive
    {
        #region Variables


        #endregion
        protected override void DoAction()
        {
            //pickup item 저장
            PlayerStats.Instance.AcquirePuzzleItem(PuzzleKey.ROOM01_KEY);

            //킬
            Destroy(gameObject);

        }
    }

}