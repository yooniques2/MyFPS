using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace MyDefence
{

    public class SceneFader : MonoBehaviour
    {
        #region Variables
        public Image image;
        public AnimationCurve curve;
        #endregion

        private void Start()
        {
            //씬시작시 페이드인 효과
            StartCoroutine(FadeIn());
            //StartCoroutine(FadeOut());

        }

        IEnumerator FadeIn()
        {
            //1초동안 image a1 -> 0
            //

            float t = 1f;
            while (t > 0)
            {
                t -= Time.deltaTime;
                float a = curve.Evaluate(t);
                image.color = new Color(0f, 0f, 0f, a);
                yield return 0f;
            }
        }
        public void FadeTo(string sceneName)
        {
            StartCoroutine(FadeOut(sceneName));
        }
        IEnumerator FadeOut(string sceneName)
        {
            //1초 동안 image a0 -> 1
            float t = 0f;

            while (t < 1f)
            {
                t += Time.deltaTime;
                float a = curve.Evaluate(t);
                image.color = new Color(0f, 0f, 0f, a);
                yield return 0f;
            }
            //다음씬 로드
            SceneManager.LoadScene(sceneName);

        }
    }
}
