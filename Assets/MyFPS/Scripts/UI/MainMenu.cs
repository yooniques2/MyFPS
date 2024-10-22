using MyDefence;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFPS
{

    public class MaiMenu : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;
        [SerializeField] private string loadToScene = "PlayScene";

        private AudioManager audioManager;
        #endregion
        // Start is called before the first frame update
        void Start()
        {
            // 씬 페이드인 효과
            //페이드인 효과
            fader.FromFade();

            audioManager = AudioManager.Instance;

            AudioManager.Instance.Play("MenuBGM");
        }

        public void NewGame()
        {
            audioManager.Stop(audioManager.BgmSound);
            audioManager.Play("MenuButton");

            fader.FadeTo(loadToScene);
        }
        public void LoadGame()
        {
            Debug.Log("Goto LoadGame");
        }
        public void Options()
        {
            audioManager.Play("PlayBGM");
            Debug.Log("Show Options");

        }
        public void Credits()
        {
            Debug.Log("Show Credits");

        }
        public void QuitGame()
        {
            Debug.Log("QuitGame");
            Application.Quit();

        }
    }

}