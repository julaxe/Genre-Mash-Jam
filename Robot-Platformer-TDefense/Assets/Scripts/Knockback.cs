using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    [SerializeField] private float knockbackForce = 2;
    [SerializeField] private float knockbackTimer = 3;
    private float nextKnockback = 0;
    private bool canKnockback = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextKnockback)
        {
            nextKnockback = Time.time + knockbackTimer;
            canKnockback = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
         if (collision.gameObject.tag == "Enemy" && canKnockback == true)
        {
            if (transform.position.x > collision.gameObject.GetComponent<Transform>().position.x)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 0.3f) * -knockbackForce, ForceMode2D.Impulse);
            }
            else
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 0.3f) * knockbackForce, ForceMode2D.Impulse);
            }
        }
    }
}
