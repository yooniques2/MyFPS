using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using StarterAssets;

namespace MyFPS
{

    public class AOpening : MonoBehaviour
    {

        #region Variables
        public GameObject thePlayer;
        public SceneFader fader;

        //sequence UI
        public TextMeshProUGUI textBox;
        [SerializeField] private string sequence01 = "...where am I?";
        [SerializeField] private string sequence02 = "I need to get out of here...";

        public AudioSource line01;
        public AudioSource line02;
        #endregion
        // Start is called before the first frame update
        void Start()
        {
            //마우스 커서 상태 설정
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            StartCoroutine(PlaySquence());
        }

        //오프닝 시퀀스
        IEnumerator PlaySquence()
        {
            //  0. 플레이 캐릭터 비 활성화
            thePlayer.GetComponent<FirstPersonController>().enabled = false;
            //thePlayer.SetActive(false);

            //1.페이드인 연출(1초 대기후 페인드인 효과)
            //yield return new WaitForSeconds(1f);
            fader.FromFade(4f); //4초동안 fade효과

            //2.화면 하단에 시나리오 텍스트 화면 출력(3초) (..where am I?)
            textBox.gameObject.SetActive(true);
            textBox.text = sequence01;
            line01.Play();

            //I need to get out of here...
            yield return new WaitForSeconds(3f);
            textBox.text = sequence02;
            line02.Play();


            //3. 3초후에 시나리오 텍스트 없어진다
            yield return new WaitForSeconds(3f) ;
            textBox.text = "";
            textBox.gameObject.SetActive(false);

            //4.플레이 캐릭터 활성화
            thePlayer.GetComponent<FirstPersonController>().enabled = true;

        }
    }

}