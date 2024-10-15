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

        //연사 딜레이
        [SerializeField]private float fireDelay = 0.5f;
        private bool isFire = false;

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
            if (Input.GetButtonDown("Fire") &&!isFire)
            {
            StartCoroutine(Shoot());
            }

        }
        IEnumerator Shoot()
        {
            isFire = true;

            float maxDistance = 100f;
            RaycastHit hit;

            if( Physics.Raycast(firePoint.position, firePoint.TransformDirection(Vector3.forward), out hit, maxDistance))
            {
                Debug.Log("적에게 대미지");
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