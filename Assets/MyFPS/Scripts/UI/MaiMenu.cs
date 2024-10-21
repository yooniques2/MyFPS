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
        #endregion
        // Start is called before the first frame update
        void Start()
        {
            //페이드인 효과
            fader.FromFade();
        }

        public void NewGame()
        {
            fader.FadeTo(loadToScene);
        }
        public void LoadGame()
        {
            Debug.Log("Goto LoadGame");
        }
        public void Options()
        {
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