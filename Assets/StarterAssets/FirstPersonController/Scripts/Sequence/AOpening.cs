using MyDefence;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace MyFPS
{

    public class AOpening : MonoBehaviour
    {

        #region Variables
        public GameObject thePlayer;
        public SceneFader fader;

        //sequence UI
        public TextMeshProUGUI textBox;
        [SerializeField] 
        private string sequence = "I gotta get out of here...";
        #endregion
        // Start is called before the first frame update
        void Start()
        {

            StartCoroutine(PlaySquence());
        }

        //오프닝 시퀀스
        IEnumerator PlaySquence()
        {
            //  0. 플레이 캐릭터 비 활성화
            thePlayer.SetActive(false);

            //1.페이드인 연출(1초 대기후 페인드인 효과)
            //yield return new WaitForSeconds(1f);
            fader.FromFade(1f); //2초동안 fade효과

            //2.화면 하단에 시나리오 텍스트 화면 출력(3초) (I need get out of here)
            textBox.gameObject.SetActive(true);
            textBox.text = sequence;

            //3. 3초후에 시나리오 텍스트 없어진다
            yield return new WaitForSeconds(3f) ;
            textBox.gameObject.SetActive(false);
            //textBox.text = "";

            //4.플레이 캐릭터 활성화
            thePlayer.SetActive(true);


        }
    }

}