using UnityEngine;

namespace MyFPS
{
    //파일에 저장할 게임 플레이 데이터 목록
    [System.Serializable]
    public class PlayData
    {
        public int sceneNumber;
        public int ammoCount;
        public bool hasGun;

        //...health

        //생성자 - payerstats에 있는 데이터
        public PlayData()
        {
            sceneNumber = PlayerStats.Instance.SceneNumber;
            ammoCount = PlayerStats.Instance.AmmoCount;
            hasGun = PlayerStats.Instance.HasGun;
        }
    }
}