using UnityEngine;
using StarterAssets;

namespace MyFPS
{

    public class PauseUI : MonoBehaviour
    {
        #region Variables
        public GameObject pauseUI; // UI 패널을 참조합니다.

        public SceneFader fader;
        [SerializeField] private string loadToScene = "MainMenu";

        public GameObject thePlayer;

        #endregion

        private void Start()
        {
            //참조
            thePlayer = GameObject.Find("Player");

            //pauseUI.SetActive(false);
        }
        void Update()
        {
            // 'P' 키를 눌렀을 때 일시정지 상태를 토글합니다.
            if (Input.GetKeyDown(KeyCode.Escape))   //&&!isSequence
            {
                //Debug.Log("Escape key pressed.");

                    Toggle();
                
                /*else
                {
                    Resume(); // 일시정지 해제
                }*/
            }
        }

        // 게임을 재개합니다.
        public void Toggle()
        {
            pauseUI.SetActive(!pauseUI.activeSelf);

            if (pauseUI.activeSelf)     //pause 창이  오픈 될때
            {
                thePlayer.GetComponent<FirstPersonController>().enabled = false;

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                Time.timeScale = 0f;
            }
            else
            { 
                thePlayer.GetComponent<FirstPersonController>().enabled = true;

                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

                Time.timeScale = 1f;

            }

        }
        public void Menu()
        {
            Time.timeScale = 1f;

            //씬 종료 처리
            AudioManager.Instance.StopBgm();

            Debug.Log("Goto Menu");
            fader.FadeTo(loadToScene);

        }

    }

}