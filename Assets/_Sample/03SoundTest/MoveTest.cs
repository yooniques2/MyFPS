using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;

    //Rigidbody에 가해지는 힘의 크기
    //[SerializeField] private float m_Thrust = 20f;

    // 큐브의 이동 속도
    //[SerializeField] private float moveSpeed = 5f; 
    [SerializeField] private float forwardForce = 10f;   //앞으로 미는 힘
    [SerializeField] private float sideForce = 5f;      //좌우로 미는 힘

    private float dx;       //좌우입력값

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        dx = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {

        rb.AddForce(0f, 0f, forwardForce, ForceMode.Acceleration);

        if (dx < 0f)
        {
            rb.AddForce(-sideForce, 0f, 0f, ForceMode.Acceleration);

        }
        if (dx > 0f)
        {
            rb.AddForce(sideForce, 0f, 0f, ForceMode.Acceleration);

        }


        /*
                // 좌우 방향으로 힘 추가

                // 좌우 입력 받기
                float moveHorizontal = Input.GetAxis("Horizontal"); // 왼쪽(A)/오른쪽(D) 또는 화살표 입력
                rb.AddForce(Vector3.right * moveHorizontal * moveSpeed);

                float moveVertical = Input.GetAxis("Vertical");     // 앞(W)/뒤(S) 입력 또는 위/아래 화살표
                rb.AddForce(Vector3.forward * moveVertical * moveSpeed);

                if (Input.GetButton("Jump"))
                {
                    //Apply a force to this Rigidbody in direction of this GameObjects up axis
                    rb.AddForce(transform.up * m_Thrust);
                }
               */
    }


}

