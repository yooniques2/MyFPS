using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MySample
{

    public class AnimatorBlendTest : MonoBehaviour
    {
        #region Variables
        //이동
        [SerializeField] private float moveSpeed = 5f;

        //입력값
        private float moveX;
        private float moveY;

        private Animator animator;

        #endregion
        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            //앞뒤좌우입력 처리
            moveX = Input.GetAxis("Horizontal");
            moveY = Input.GetAxis("Vertical");

            //이동, 방향, 속도
            Vector3 dir = new Vector3(moveX, 0f, moveY);
            transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World);

            //
            //AnimatorStateTest();

            //
            AnimationBlenTest();

        }

        private void AnimationBlenTest()
        {
            animator.SetFloat("MoveX", moveX);
            animator.SetFloat("MoveY", moveY);
        }
        private void AnimatorStateTest()
        {

            if (moveX == 0f && moveY == 0f)
            {
                animator.SetInteger("MoveState", 0);    //대기
            }
            else if (moveY > 0f)
            {
                animator.SetInteger("MoveState", 1);    //앞
            }
            else if (moveY < 0f)
            {
                animator.SetInteger("MoveState", 2);    //뒤

            }
            else if (moveX < 0f)
            {
                animator.SetInteger("MoveState", 3);    //좌

            }
            else if (moveX > 0f)
            {
                animator.SetInteger("MoveState", 4);    //우

            }


        }

    }



}

