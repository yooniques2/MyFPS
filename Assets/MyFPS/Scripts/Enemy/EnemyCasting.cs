using UnityEngine;

namespace MyFPS
{

    public class EnemyCasting : MonoBehaviour
    {
        #region Variables

        public Transform thePlayer;
        public float detectionRange = 20f;
        private GameObject gunMan;

        [SerializeField] private float toTarget; //거리 숫자 보기
        #endregion

        private void Update()
        {
            // 플레이어와의 거리 계산
            float distanceToPlayer = Vector3.Distance(transform.position, thePlayer.position);

            if (distanceToPlayer <= detectionRange)
            {
                Debug.Log("Player detected within range!");
                if (gunMan != null)
                {
                    gunMan.GetComponent<Enemy>().SetState(EnemyState.E_Chase);

                }
            }
        }

        // 감지 범위를 빨간색으로 그리기 위해 Gizmos 사용
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, detectionRange);
        }
    }
}

