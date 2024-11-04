using System.Collections;
using UnityEngine;

namespace MyFPS
{

public class Title : MonoBehaviour
{
        #region Variables
        public SceneFader fader;
        [SerializeField] private string loadToScene = "MainMenu";

        private bool isAnyKey = false;
        public GameObject anykeyUI;

        //private AudioManager audioManager;
        #endregion

        private void Start()
        {
            //페이드인 효과
            fader.FromFade();
            //초기화
            isAnyKey = false;

            StartCoroutine(TitleProcess());

        }
        private void Update()
        {

            if (Input.anyKey && isAnyKey)
            {
                GotoMenu();
            }

        }

        //3초 뒤에 anykey show, 10초 뒤에 자동 넘김
        IEnumerator TitleProcess()
        {
            yield return new WaitForSeconds(4f);
            isAnyKey = true;
            anykeyUI.SetActive(true);
            //audioManager.Play("MenuBtn");

            yield return new WaitForSeconds(10f);
            GotoMenu();

        }

        private void GotoMenu()
        {
            StopAllCoroutines();

            fader.FadeTo(loadToScene);
        }
    }

}