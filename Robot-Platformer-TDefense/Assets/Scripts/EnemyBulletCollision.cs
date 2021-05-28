using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Turret")
        {
            collision.gameObject.GetComponent<Turret>().TakeDamage(10);
        }
        Destroy(this.gameObject);
    }
}
