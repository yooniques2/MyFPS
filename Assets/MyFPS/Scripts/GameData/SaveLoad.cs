using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MyFPS
{
    //게임 데이터 파일 저장/가져오기 구현 - 이진화 저장
    public static class SaveLoad
    {
        private static string fileName = "/playData.arr";
        public static void SaveData()
        {
            //파일 이름, 경로 지정
            string path = Application.persistentDataPath + "/playData.arr";

            //저장할 데이터를 이진화 준비
            BinaryFormatter formatter = new BinaryFormatter();

            //파일접근 - 존재하면 파일 가져오기, 존재하지 않으면 파일 새로 생성
            FileStream fs = new FileStream(path, FileMode.Create);

            //저장할 데이터 셋팅
            PlayData playData = new PlayData();
            //Debug.Log($"Save {playData.sceneNumber}");

            //준비한 데이터를 이진화 저장
            formatter.Serialize(fs, playData);

            //파일 클로즈
            fs.Close();

        }

        public static PlayData LoadData()
        {
            PlayData playData;

            string path = Application.persistentDataPath + "/playData.arr";

            //지정된 경로에 저장된 파일이 있는지 없는지 체크
            if (File.Exists(path) == true)
            {
                //파일이 있음
                //가져올 데이트를 이진화 준비
                BinaryFormatter formatter = new BinaryFormatter();

                FileStream fs = new FileStream(path, FileMode.Open);

                //파일에 이진화로 저장된 데이터를 역 이진화해서 가져온다
                playData = formatter.Deserialize(fs) as PlayData;
                //Debug.Log($"Load SceneNumber : {playData.sceneNumber}");

                fs.Close() ;
            }
            else
            {
                //파일이 없음
                Debug.Log("Not Found Load File");
                playData = null;
            }

            return playData;

        }
        public static void DeleteFile()
        {
            string path = Application.persistentDataPath + fileName;
            File.Delete(path);
        }
    }

}