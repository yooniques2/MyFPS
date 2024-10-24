using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

namespace MyFPS
{

    public class BreakableObject : MonoBehaviour, IDamageable
    {
        #region Variables
        public GameObject fakeObject;   //온전한 오브젝트
        public GameObject breakObject;  //깨진 오브젝트
        public GameObject effectObject;    //꺠지는 효과
        
        public GameObject hiddenItem;       //히든 아이템

        private bool isBreak = false;

       [SerializeField] private bool unBreakable = false;       //true : unbreakable
        #endregion

        //총 맞으면
        //fake->breakable
        //소리

        public void TakeDamage(float damage)
        {
            if (unBreakable)
            {
                return;
            }
            //1 shot 1 kill
            if (!isBreak)
            {
                StartCoroutine(BreakObject());

            }

        }
        IEnumerator BreakObject()
        {
            isBreak = true;
            this.GetComponent<BoxCollider>().enabled = false;

            fakeObject.SetActive(false);
            yield return new WaitForSeconds(0.05f);

            AudioManager.Instance.Play("PotterySmash");
            breakObject.SetActive(true);

            if (effectObject != null)
            {
                effectObject.SetActive(true);
                yield return new WaitForSeconds(0.05f);
                effectObject.SetActive(false);
            }
            //숨겨진 아이템이 있으면 보여주기
            if (hiddenItem != null)
            {
            hiddenItem.SetActive(true);
            }
        }
    }
}


