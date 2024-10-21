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
            //초기화: 시작히 화면을 검정색으로 시작
            image.color = new Color(0f, 0f, 0f, 1f);
            //FromFade();

            //씬시작시 페이드인 효과
            //StartCoroutine(FadeIn());
            //StartCoroutine(FadeOut());

        }
        public void FromFade(float delayTime = 0f)
        {
            StartCoroutine (FadeIn(delayTime));
        }

        IEnumerator FadeIn(float delayTime)
        {
            if (delayTime > 0f)
            {
            yield return new WaitForSeconds(delayTime);

            }

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
