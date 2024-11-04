using UnityEngine;

namespace MyFPS
{
    public enum PuzzleKey
    {
        ROOM01_KEY,
        LEFTEYE_KEY,
        RIGHTEYE_KEY,
        MAX_KEY             //퍼즐 아이템 갯수


    }

    //플레이어의 속성값을 관리하는 (싱글톤,DontDestroy) 클래스.. ammo
    public class PlayerStats : PersistentSingleton<PlayerStats>
    {
        #region Variables
        //저장된 sceneNumber
        private int sceneNumber;
        public int SceneNumber
        {
            get
            {
                return sceneNumber;
            }
            set
            {
                sceneNumber = value;
            }
        }

        //지금 플레이 하고 잇는 sceneNumber
        private int nowSceneNumber;
        public int NowSceneNumber
        {
            get
            {
                return nowSceneNumber;
            }
            set
            {
                nowSceneNumber = value;
            }
        }



        //탄환 갯수
        [SerializeField] private int ammoCount;
        public int AmmoCount
        {
            get
            {
                return ammoCount;
            }
            private set
            {
                ammoCount = value;
            }
        }

        //무기 소지 여부
        private bool hasGun;
        public bool HasGun
        {
            get
            {
                return hasGun;
            }
            set
            {
                hasGun = value;
            }
        }

        //게임 퍼즐 아이템 키
        private bool[] puzzleKeys;

        #endregion
        private void Start()
        {
            //속성값/Data Reset
            //AmmoCount = 0;
            puzzleKeys = new bool[(int)PuzzleKey.MAX_KEY];
        }
        public void PlayerStatInit(PlayData playData)
        {
            if (playData != null)
            {
                SceneNumber = playData.sceneNumber;
                AmmoCount = playData.ammoCount;
                hasGun = playData.hasGun;
            }
            else    //저장된 데이터가 없을떄
            {
                SceneNumber = 0;
                AmmoCount = 0;
                hasGun = false;
            }
            
        }

        public void Addammo(int amount)
        {
            AmmoCount += amount;
        }
        public bool UseAmmo(int amount)
        {
            //소지갯수 체크
            if (AmmoCount < amount)
            {
                Debug.Log("No more Ammo");
                return false;   //사용량보다 부족하다
            }

            AmmoCount -= amount;
            return true;
        }
        public void AcquirePuzzleItem(PuzzleKey key)
        {
            puzzleKeys[(int)key] = true;
        }
        //퍼즐 아이템을 소지여부
        public bool HasPuzzleItem(PuzzleKey key)
        {
            return puzzleKeys[(int)key];
        }
        //무기 획득 셋팅
        public void SetHasGun(bool value)
        {
            HasGun = value;
        }
    }
}