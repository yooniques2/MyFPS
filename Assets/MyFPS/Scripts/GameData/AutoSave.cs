using UnityEngine;
using UnityEngine.SceneManagement;


namespace MyFPS
{
    //플레이씬이 시작하면 자동으로 게임데이터 저장
    public class AutoSave : MonoBehaviour
    {
        void Start()
        {
            //씬번호 저장
            AutoSaveData();
        }
        void AutoSaveData()
        {
            //현재 씬 저장
            int sceneNumber = PlayerStats.Instance.SceneNumber;
            //int sceneNumber = PlayerPrefs.GetInt("PlayerScene", 0);
            //Debug.Log($"저장 sceneNumber: {sceneNumber}");

            int playScene = SceneManager.GetActiveScene().buildIndex;
            Debug.Log($"저장 sceneNumber: {playScene}");

            //새로운씬인가 확인
            if (playScene > sceneNumber)
            {
                //Debug.Log($"저장 playSceneNumber: {sceneNumber}");
                //Debug.Log("새로플레이하는씬저장");
                //PlayerPrefs.SetInt("playScene", playScene);

                PlayerStats.Instance.SceneNumber = playScene;
                SaveLoad.SaveData();
            
            }

        }
    }

}