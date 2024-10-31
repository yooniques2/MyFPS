using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

namespace MyFPS
{

    public class MainMenu : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;
        [SerializeField] private string loadToScene = "PlayScene";

        private AudioManager audioManager;

        [SerializeField] private GameObject mainMenuUI;
        [SerializeField] private GameObject optionUI;
        [SerializeField] private GameObject creditsUI;

        //Audio
        public AudioMixer audioMixer;

        public Slider BGMSlider;
        public Slider SFXSlider;
        #endregion
        // Start is called before the first frame update
        void Start()
        {
            //게임 저장데이터, 저장된 옵션값 불러오기
            LoadOptions();

            // 씬 페이드인 효과
            //페이드인 효과
            fader.FromFade();

            audioManager = AudioManager.Instance;

            audioManager.PlayBgm("MenuBGM");

            mainMenuUI.SetActive(true);
            optionUI.SetActive(false);
        }

        public void NewGame()
        {
            audioManager.Stop(audioManager.BgmSound);
            Debug.Log("New Game");
            audioManager.Play("MenuBtn");

            fader.FadeTo(loadToScene);
        }
        public void LoadGame()
        {
            Debug.Log("Goto LoadGame");
        }
        public void Options()
        {
            audioManager.Play("MenuBtn");
            showOptions();
            //Debug.Log("Show Options");

        }
        private void showOptions()
        {
            mainMenuUI.SetActive(false);
            optionUI.SetActive(true);
        }
        public void OptionsExit()
        {
            //옵션값 저장하기
            SaveOptions();

            audioManager.Play("MenuBtn");
            mainMenuUI.SetActive(true);
            optionUI.SetActive(false);
        }

        
        public void Credits()
        {
            //Debug.Log("Show Credits");
            showCredits();
        }

        private void showCredits()
        {
            mainMenuUI.SetActive(false);
            creditsUI.SetActive(true);
        }

        public void QuitGame()
        {
            //cheating
            PlayerPrefs.DeleteAll();

            Debug.Log("QuitGame");
            Application.Quit();

        }

        //audioMix 셋팅
        public void SetBGMVolume(float value)
        {
            audioMixer.SetFloat("BGMVolume", value);
        }
        //audioMix 셋팅
        public void SetSFXVolume(float value)
        {
            audioMixer.SetFloat("SFXVolume", value);
        }

        //옵션값 저장하기
        private void SaveOptions()
        {
            PlayerPrefs.SetFloat("BGMVolume", BGMSlider.value);
            PlayerPrefs.SetFloat("SFXVolume", SFXSlider.value);
        }

        //옵션값 로드하기
        private void LoadOptions()
        {
            //배경음 볼륨
            float BGMVolume = PlayerPrefs.GetFloat("BGMVolume",0);
            Debug.Log($"BGMVolume:{BGMVolume}");
            SetBGMVolume(BGMVolume);        //사운드 볼륨 조절
            BGMSlider.value = BGMVolume;    //UI 셋팅

            //효과음 볼륨
            float SFXVolume = PlayerPrefs.GetFloat("SFXVolume", 0);
            SetSFXVolume(SFXVolume);        //사운드 볼륨 조절
            SFXSlider.value = SFXVolume;    //UI 셋팅

            //기타
        }
    }

}