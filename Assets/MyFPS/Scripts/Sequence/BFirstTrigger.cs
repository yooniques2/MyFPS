using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace MyFPS
{

    public class BFirstTrigger : MonoBehaviour
    {
        #region Variables

        public GameObject thePlayer;

        //sequence UI
        public TextMeshProUGUI textBox;
        [SerializeField]
        private string sequence = "There is a weapon on the table.";

        //action UI
        public GameObject arrowUI;

        public GameObject ammoBox;

        #endregion

        private void OnTriggerEnter(Collider other)
        {
            //Debug.Log($"OnTriggerEnter: {other.name}");
            //오른쪽으로 힘을 준다,컬러를 빨간색으로 바꾼다

            StartCoroutine(PlaySquence());
        }
         
        IEnumerator PlaySquence()
        {
            //  0. 플레이 캐릭터 비 활성화(플레이 멈춤)
            thePlayer.SetActive(false);

            //2.화면 하단에 시나리오 텍스트 화면 출력(3초)
            textBox.gameObject.SetActive(true);
            textBox.text = sequence;

            //화살표 활성화
            arrowUI.SetActive(true);

            //1초 딜레이
            yield return new WaitForSeconds(1f);

            //3. 3초후에 시나리오 텍스트 없어진다
            textBox.text = "";
            textBox.gameObject.SetActive(false);

            //4.플레이 캐릭터 활성화
            thePlayer.SetActive(true);

            //트리거 충돌체 비활성화
            transform.GetComponent<BoxCollider>().enabled = false;

        }
    }

}