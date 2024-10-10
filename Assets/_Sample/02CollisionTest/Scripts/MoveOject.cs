using UnityEngine;

namespace MySample
{

    public class MoveOject : MonoBehaviour
    {
        #region Variables
        //
        private Rigidbody rb;

        //좌우로 힘을 주어 이동
        [SerializeField] private float movePower = 5f;
        private float moveX;

        //색변경
        private Material material;
        private Color originColor; 
        #endregion

        // Start is called before the first frame update
        void Start()
        {
            //참조
            rb = GetComponent<Rigidbody>();
            material = GetComponent<Renderer>().material;
            //rb.AddForce(Vector3.right * movePower, ForceMode.Impulse);

            //초기화
            originColor = material.color;
            MoveRightByForce();
            //MoveLeftByForce();

        }

        // Update is called once per frame
        void Update()
        {
            //입력
            //moveX = Input.GetAxis("Horizontal");
        }
        private void FixedUpdate()
        {
            //좌우로 힘을 주어 기동
            //rb.AddForce(Vector3.right * moveX * movePower, ForceMode.Force);
        }
        public void MoveRightByForce()
        {
            rb.AddForce(Vector3.right * movePower, ForceMode.Impulse);

        }
        public void MoveLeftByForce()
        {
            rb.AddForce(Vector3.left * movePower, ForceMode.Impulse);

        }
        public void ChangeRedColor()
        {
            material.color = Color.red; 
        }
        public void ResetColor()
        {
            material.color = originColor;

        }
    }

}