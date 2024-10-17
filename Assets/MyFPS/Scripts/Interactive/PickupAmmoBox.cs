using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFPS
{

    public class PickupAmmoBox : Interactive
    {

        #region Variables

        public GameObject ammoArrow;
            
        //ammobox 아이템 획득시 지급하는 ammo 갯수
        [SerializeField]private int giveAmmo = 7;

        #endregion

        protected override void DoAction()
        {
            
            //Action
            Debug.Log("탄환 7개를 지급 얻었습니다");
            PlayerStats.Instance.Addammo(giveAmmo);

            //킬
            Destroy(gameObject);
            ammoArrow.SetActive(false);


            


        }

    }

}