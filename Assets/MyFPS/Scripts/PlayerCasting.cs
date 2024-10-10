using UnityEngine;

namespace MyFPS
{
    //정면에 있는 충돌체와의 거리 구하기
    public class PlayerCasting : MonoBehaviour
    {
        #region Variables
        public static float distanceFromTarget;
        [SerializeField]private float toTarget; //거리 숫자 보기

        #endregion

        // Update is called once per frame
        void Update()
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {
                distanceFromTarget = hit.distance;
                toTarget = distanceFromTarget;
            }
                //OnDrawGizmosSelected();
        }
        //Gizmo 그리기 : 카메라 위치에서 앞에 충돌체 까지 레이저 쏘기
        void OnDrawGizmosSelected()
        {
            // Draws a 5 unit long red line in front of the object
            float maxDistance = 100f;
            RaycastHit hit;
            bool isHit = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, maxDistance);

            Gizmos.color = Color.red;
                if (isHit)
            {
                Gizmos.DrawRay(transform.position, transform.forward * hit.distance);
            }
                else
            {
                Gizmos.DrawRay(transform.position, transform.forward * maxDistance);
            }

/*
            Gizmos.color = Color.red;
            Vector3 direction = transform.TransformDirection(Vector3.forward) * 5;
            Gizmos.DrawRay(transform.position, direction);
*/
        }
    }


}