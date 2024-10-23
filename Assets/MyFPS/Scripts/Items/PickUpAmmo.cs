using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFPS
{
public class PickUpAmmo : PickUpItem
{
        #region Variables
        [SerializeField] private int giveAmount = 7;
        #endregion

        protected override bool OnPickUp()
        {
            //탄환 7개 지급 
            PlayerStats.Instance.Addammo(giveAmount);

            return true;

        }
    }

}