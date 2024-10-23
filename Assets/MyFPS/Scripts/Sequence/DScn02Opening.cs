using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
//using StarterAssets;

namespace MyFPS
{

    public class DScn02Opening : MonoBehaviour
    {
        #region Variables
        public GameObject thePlayer;
        public SceneFader fader;

        //sequence UI
        public TextMeshProUGUI textBox;
        [SerializeField] private string sequence03 = "Where should I go?";

        #endregion

        // Start is called before the first frame update
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            StartCoroutine(PlaySquence02());
        }

        IEnumerator PlaySquence02()
        {
            //  0. 플레이 캐릭터 비 활성화
            thePlayer.GetComponent<FirstPersonController>().enabled = false;

            //배경음 시작
            AudioManager.Instance.PlayBgm("PlayBGM");

            //시퀀스 텍스트 초기화
            textBox.text = "";

            //1.페이드인 연출(1초 대기후 페인드인 효과)
            yield return new WaitForSeconds(1f);
            fader.FromFade();

            //2.화면 하단에 시나리오 텍스트 화면 출력(3초) 
            textBox.gameObject.SetActive(true);
            textBox.text = sequence03;

            //3. 3초후에 시나리오 텍스트 없어진다
            yield return new WaitForSeconds(3f);
            textBox.text = "";
            textBox.gameObject.SetActive(false);

            //4.플레이 캐릭터 활성화
            thePlayer.GetComponent<FirstPersonController>().enabled = true;

        }
    }

}