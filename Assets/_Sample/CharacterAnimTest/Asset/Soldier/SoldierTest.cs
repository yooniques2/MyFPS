using UnityEngine;

namespace MySample
{

    public class SoldierTest : MonoBehaviour
    {
        #region Variables
        private Animator animator;
        #endregion
        // Start is called before the first frame update
        void Start()
        {
            //참조 
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            //w키 입력
            bool isRun = animator.GetBool("IsRun");
            bool isWalk = animator.GetBool("IsWalk");
            bool walkPressed = Input.GetKey(KeyCode.W);
            bool runPressed = Input.GetKey(KeyCode.LeftShift);


            if (walkPressed && !isWalk)

            {
                animator.SetBool("IsWalk", true);
            }
            if (!walkPressed && isWalk)
            {
                animator.SetBool("IsWalk", false);
            }
            if ((walkPressed && runPressed) &&!isRun) 
            {
                animator.SetBool("IsRun", true);
            }
            if (!walkPressed || !runPressed&& isRun)
            {
                animator.SetBool("IsRun", false);
            }
        }
    }

}