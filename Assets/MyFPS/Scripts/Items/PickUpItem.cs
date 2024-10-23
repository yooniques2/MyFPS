using UnityEngine;

namespace MyFPS
{

    public class PickUpItem : MonoBehaviour
    {
        #region Variables
        [SerializeField] private float verticalBobFrequency = 1.0f;     //이동 속도
        [SerializeField] private float bobingAmount = 1.0f;     //이동 거리
        [SerializeField] private float rotateSpeed = 360f;     //이동 거리

        private Vector3 startPosition;      //시작위치
        #endregion
        void Start()
        {
            //처음위치
            startPosition = transform.position;
        }
        private void Update()
        {
            //위아래로 흔들림
            float bobinganimationPhase = Mathf.Sin(Time.time * verticalBobFrequency) * bobingAmount;
            transform.position = startPosition + Vector3.up * bobinganimationPhase;

            //
            transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.World);

        }

        private void OnTriggerEnter(Collider other)
        {
            //플레이어 체크
           if (other.tag == "Player")
            {
                //아이템획득
                Debug.Log("아이템획득");

                //
                if (OnPickUp() == true) 
                {
                 //성공효과, 사운드, 이펙튼

                    //킬
                    Destroy(gameObject);
                }
            }
        }
        //아이템 획득 성공,실패 반환
        protected virtual bool OnPickUp()
        {
            //탄환 7개 지급
            //HP, MP
            //.. ...
            return true;
        }
    }
}

