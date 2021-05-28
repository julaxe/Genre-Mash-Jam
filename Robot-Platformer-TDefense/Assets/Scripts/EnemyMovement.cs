using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float m_speed;
    [Range(0,1)]
    [SerializeField] private float m_acceleration; // 0 to 1
    [SerializeField] private float m_JumpTime;


    private Transform m_EnergyCoreTransform;
    private Rigidbody2D m_rb;

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
    }

    // Update is called once per frame
    void Update()
    {
        if(m_grounded)
        {
            float distance = m_EnergyCoreTransform.position.x - transform.position.x;
            if(distance > 0)
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
        if(collision.gameObject.tag == "Platform")
        {
            Grounded();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "JumpPoint")
        {
            //point where he is going to land
            m_targetJump = collision.transform.parent.transform.Find("Point3");
            m_middlePointJump = collision.transform.parent.transform.Find("Point2");
            m_startJump =transform.position;

            Jump();

            m_jumping = true;
            m_grounded = false;
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

    public void changeMovementSpeed(float a)
    {
        m_speed = a;
    }

    public float getMovementSpeed()
    {
        return m_speed;
    }

    private void OnDrawGizmos()
    {
        
    }
}
