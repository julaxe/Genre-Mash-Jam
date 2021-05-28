using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBulletCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(10);
        }
        Destroy(this.gameObject);
    }
}
