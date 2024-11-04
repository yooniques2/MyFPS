using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyFPS
{

    public class GameOver : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;
        [SerializeField] private string loadToScene = "MainMenu";
        #endregion
        private void Start()
        {
            //마우스 커서 상태 설정
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            //페이드인 효과
            fader.FromFade();
        }

        public void Retry()
        {
            fader.FadeTo(PlayerStats.Instance.SceneNumber);
        }

        public void Menu()
        {
            Debug.Log("Goto Menu!!!");
            fader.FadeTo(loadToScene);
        }

    }

}