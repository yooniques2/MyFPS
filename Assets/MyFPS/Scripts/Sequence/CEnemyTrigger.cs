using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFPS
{

    public class CEnemyTrigger : MonoBehaviour
    {
        #region Variables
        public GameObject theDoor;  //문
        public AudioSource doorBang;    //문 열기 사운드

        public AudioSource bgm01;   //메인씬 1 배경음
        public AudioSource bgm02;   //적 등장 사운드
        public GameObject theRobot; //적
        #endregion

        private void OnTriggerEnter(Collider other)
        {
            StartCoroutine(PlaySequence());
        }

        IEnumerator PlaySequence()
        {
            //문열기
            theDoor.GetComponent<Animator>().SetBool("IsOpen", true);
            theDoor.GetComponent<BoxCollider>().enabled = false;

            //문 사운드
            doorBang.Play();
            //enemy 활성화
            theRobot.SetActive(true);

            yield return new WaitForSeconds(1f);

            //enemy 등장 사운드
            bgm02.Play();

            //Enemy 타겟을 향해 걷기
            RobotController robot = theRobot.GetComponent<RobotController>();
            if (robot != null)
            {
                //<==================
                robot.SetState(RobotState.R_Walk);
            }
            //트리거 킬
            Destroy(this.gameObject);
        }
    }
}