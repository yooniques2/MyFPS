using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace MyFPS
{
    public enum EnemyState
    {
        E_Idle,         //대기
        E_Walk,         //걷기
        E_Attack,       //공격
        E_Death,        //죽음
        E_Chase,        //추격(걷기) - 적을 타격한 후

    }
    public class Enemy : MonoBehaviour, IDamageable
    {
        #region Variables

        private Transform thePlayer;
        private Animator animator;
        private NavMeshAgent agent;

        //적 현재 상태
        private EnemyState currentState;
        //적 이전 상태
        private EnemyState beforeState;

        //체력
        [SerializeField] private float maxHealth = 20;
        private float currentHealth;

        private bool isDeath = false;

        //공격

        [SerializeField] private float attackRange = 1.5f;      //공격 가능 범위
        [SerializeField] private float attackDamage = 5f;    //공격 데미지


        //패트롤
        public Transform[] wayPoints;
        private int nowWayPoint = 0;

        private Vector3 startPosition;  //시작위치, 타겟을 잃어버렸을 때 돌아오는 지점

        //적감지
        private bool isAiming = false;
        public bool IsAiming
        {
            get 
            { 
                return isAiming; 
            }
            set 
            { 
                isAiming = value; 
            }
        }
        [SerializeField] private float detectDistance = 20f;
        #endregion
        private void Start()
        {
            //참조
            thePlayer = GameObject.Find("Player").transform;
            animator = GetComponent<Animator>();
            agent = GetComponent<NavMeshAgent>();

            //초기화
            currentHealth = maxHealth;
            isDeath = false;
            startPosition = transform.position;
            nowWayPoint = 0;

            if (wayPoints.Length > 0)
            {
                SetState(EnemyState.E_Walk);
                GoNextPoint();
            }
            else
            {
                SetState(EnemyState.E_Idle);
            }


        }
        private void Update()
        {
            if (isDeath)
            {
                return;
            }
            
            
            float distance = Vector3.Distance(thePlayer.transform.position, transform.position);
            if ((detectDistance > 0))
                IsAiming = distance <= detectDistance;
            {
                
            }
            if (distance <= attackRange)
            {
                SetState(EnemyState.E_Attack);
            }
            else if ( detectDistance >0)
            {
                if (IsAiming)
                {
                    SetState(EnemyState.E_Chase);
                }
            }

            switch (currentState)
            {
                case EnemyState.E_Idle:
                    break;

                case EnemyState.E_Walk:
                    //도착판정
                    if (agent.remainingDistance <= 0.2f)
                    {
                        if (wayPoints.Length > 0)
                        {
                        GoNextPoint();

                        }
                        else
                        {
                            SetState(EnemyState.E_Idle);
                        }
                    }
                        break;

                case EnemyState.E_Attack:
                    transform.LookAt(thePlayer.position);
                    if (distance > attackRange)
                    {
                        SetState(EnemyState.E_Chase);
                    }
                    break;

                case EnemyState.E_Chase:
                    if (detectDistance > 0 && !IsAiming)
                    {
                        GoStartPosition();
                        return;
                    }

                    //플레이어 위치 업데이트
                    agent.SetDestination(thePlayer.position);
                    break;
            }
        }


        //적의 상태 변경
        public void SetState(EnemyState newState)
        {
            if (isDeath)
            {
                return;
            }

            //현재 상태 체크
            if (currentState == newState)
                return;

            //이전상태 저장
            beforeState = currentState;
            //상태 변경
            currentState = newState;

            if (currentState == EnemyState.E_Chase)
            {
                animator.SetInteger("EnemyState", 1);
                animator.SetLayerWeight(1,1f);
            }
            else
            {
                //상태 변경에 따른 구현 내용
                animator.SetInteger("EnemyState", (int)newState);
                animator.SetLayerWeight(1, 0f);

            }
            //agent 초기화
            agent.ResetPath();


        }

        private void Attack()
        {

            Debug.Log("플레이어에게 데미지를 준다");
            IDamageable damageable = thePlayer.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(attackDamage);
            }
        }
        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            Debug.Log($"Enemy Health: {currentHealth}");


            if (currentHealth <= 0 && !isDeath)
            {
                Die();
            }
        }
        private void Die()
        {
            Debug.Log("Enemy Dead");
            SetState(EnemyState.E_Death);

            isDeath = true;
            //충돌체 제거
            transform.GetComponent<BoxCollider>().enabled = false;
            //킬
            Destroy(gameObject, 4f);

        }
        //다음 목표 지점으로 이동
        private void GoNextPoint()
        {
            nowWayPoint++;
            if (nowWayPoint >= wayPoints.Length)
            {
                nowWayPoint = 0;
            }
            agent.SetDestination(wayPoints[nowWayPoint].position);
        }
        //제자리로 돌아가기
        public void GoStartPosition()
        {
            if (isDeath)
            {
                return;
            }
            SetState(EnemyState.E_Walk);
            nowWayPoint = 0;
            agent.SetDestination(startPosition);
        }

        //적 감지 반경
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, detectDistance);
        }
    }

}