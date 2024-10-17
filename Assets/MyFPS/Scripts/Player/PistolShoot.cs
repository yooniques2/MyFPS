using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFPS
{

    public class PistolShoot : MonoBehaviour
    {
        #region Variables
        private Animator animator;

        public ParticleSystem muzzle;
        public AudioSource pistolShot;

        //public Transform camera;
        public Transform firePoint;

        //공격
        [SerializeField]private float attackDamage = 5f;

        //연사 딜레이
        [SerializeField] private float fireDelay = 0.7f;
        private bool isFire = false;

        //임팩트
        public GameObject hitImpactPrefab;
        //[SerializeField] private float impactForce = 10f;

        #endregion

        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            //슛
            if (Input.GetButtonDown("Fire") && !isFire)
            {
                if (PlayerStats.Instance.UseAmmo(1) == true)
                {
                StartCoroutine(Shoot());

                }
            }

        }
        IEnumerator Shoot()
        {
            isFire = true;

            //내앞에 100안에 적이 있으면 적에게 데미지를 준다
            float maxDistance = 100f;
            RaycastHit hit;

            if (Physics.Raycast(firePoint.position, firePoint.TransformDirection(Vector3.forward), out hit, maxDistance))
            {
                //적에게 데미지를 준다
                Debug.Log($"{hit.transform.name}에게 데미지를 준다");

                //임펙트 효과
                GameObject eff = Instantiate(hitImpactPrefab, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(eff, 2f);
/*
                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * impactForce, ForceMode.Impulse);
                }
*/
                IDamageable damageable = hit.transform.GetComponent<IDamageable>();
                if (damageable != null)
                {
                    damageable.TakeDamage(attackDamage);

                }

                /*
                                RobotController robot = hit.transform.GetComponent<RobotController>();
                                if (robot != null)
                                {
                                    robot.TakeDamage(attackDamage);

                                }
                */
            }

            //슛효과 - VFX, SFX
            animator.SetTrigger("Fire");

            pistolShot.Play();
            muzzle.gameObject.SetActive(true);
            muzzle.Play();

            yield return new WaitForSeconds(fireDelay);
            muzzle.Stop();
            muzzle.gameObject.SetActive(false);

            isFire = false;
        }

        //Gizmo 그리기 : 총 위치에서 앞에 충돌체 까지 레이저 쏘기
        void OnDrawGizmosSelected()
        {
            float maxDistance = 100f;
            RaycastHit hit;

            bool isHit = Physics.Raycast(firePoint.position, firePoint.TransformDirection(Vector3.forward), out hit, maxDistance);

            Gizmos.color = Color.red;
            if (isHit)
            {
                Gizmos.DrawRay(firePoint.position, firePoint.forward * hit.distance);
            }
            else
            {
                Gizmos.DrawRay(firePoint.position, firePoint.forward * maxDistance);
            }
        }

    }
}