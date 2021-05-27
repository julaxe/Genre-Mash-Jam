using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementBySide : MonoBehaviour
{
    [SerializeField] private float m_speed;
    [Range(0, 1)]
    [SerializeField] private float m_acceleration; // 0 to 1
    [SerializeField] private float m_JumpTime;


    private Transform m_EnergyCoreTransform;
    private Rigidbody2D m_rb;
    private bool m_facingRight = true;

    //ground movement
    private Vector2 m_desiredVelocity;
    private bool m_grounded = false;

    //jumping
    private Transform m_targetJump;
    private Vector2 m_startJump;
    private Transform m_middlePointJump;
    private bool m_jumping = false;
    private float m_jumpTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        m_EnergyCoreTransform = GameObject.Find("EnergyCore").transform;
        m_rb = transform.GetComponent<Rigidbody2D>();

        float distance = m_EnergyCoreTransform.position.x - transform.position.x;
        if (distance > 0)
        {
            m_facingRight = true;
        }
        else
        {
            m_facingRight = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (m_grounded)
        {
            if (m_facingRight)
            {
                m_desiredVelocity = new Vector2(m_speed, 0.0f);
            }
            else
            {
                m_desiredVelocity = new Vector2(-m_speed, 0.0f);
            }

        }
    }

    private void FixedUpdate()
    {
        if (m_jumping)
        {
            JumpCalculations();
        }
        if (m_grounded)
        {
            m_rb.velocity = Vector2.Lerp(m_rb.velocity, m_desiredVelocity, m_acceleration);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            Grounded();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (m_grounded)
        {
            if (collision.tag == "JumpPoint")
            {

                m_targetJump = collision.transform.parent.transform.Find("Point3");
                m_middlePointJump = collision.transform.parent.transform.Find("Point2");
                m_startJump = transform.position;

                float distance = m_targetJump.position.x - m_startJump.x;
                //facing the same direction
                if ((m_facingRight && distance > 0) || (!m_facingRight && distance < 0))
                {
                    Jump();
                }
                Debug.Log("JumpPoint");
            }
            if (collision.tag == "TurnLeft")
            {
                m_facingRight = false;
            }
        }
        

    }
    private void Grounded()
    {
        m_grounded = true;
        m_jumping = false;
    }
    private void Jump()
    {
        m_grounded = false;
        m_jumping = true;
        m_jumpTimer = 0.0f;
    }

    private void JumpCalculations()
    {
        if (m_jumpTimer < m_JumpTime)
        {
            Vector2 jumpPosition = CurveMath.QuadraticCurve(m_startJump, m_middlePointJump.position, m_targetJump.position, m_jumpTimer / m_JumpTime);
            transform.position = jumpPosition;
            m_jumpTimer += Time.fixedDeltaTime;
        }
    }

    private void OnDrawGizmos()
    {

    }
}

