using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float m_speed;
    [SerializeField] private float m_acceleration; // 0 to 1

    private Transform m_EnergyCoreTransform;
    private Rigidbody2D m_rb;

    private Vector2 m_desiredVelocity;
    private bool m_grounded = false;

    // Start is called before the first frame update
    void Start()
    {
        m_EnergyCoreTransform = GameObject.Find("EnergyCore").transform;
        m_rb = transform.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
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

    private void FixedUpdate()
    {
        if(m_grounded)
        {
            m_rb.velocity = Vector2.Lerp(m_rb.velocity, m_desiredVelocity, m_acceleration);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            m_grounded = true;
        }
    }

}
