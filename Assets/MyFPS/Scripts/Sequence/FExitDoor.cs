using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFPS
{
    //메인 2번씬 클리어
public class FExitDoor : MonoBehaviour
{

        #region Variables
        public SceneFader fader;
        [SerializeField] private string loadToScene = "MainMenu";


        #endregion
        private void OnTriggerEnter(Collider other)
        {
            PlaySquence();
        }
        void PlaySquence()
        {
            //씬 클리어 처리
            //배경음 종료
            AudioManager.Instance.StopBgm();

            //씬 클리어 보상, 데이터 처리
            //...

            //메인 메뉴로 이동
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            fader.FadeTo(loadToScene);
        }
    }

}