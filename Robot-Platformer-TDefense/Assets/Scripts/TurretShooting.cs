using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletObeject;
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private float nextFire = 0.0f;
    [SerializeField] private Vector3 enemyLoc;
    private Transform bulletSpawmLocation;
    private Vector3 shootDirection;
    
    // Start is called before the first frame update
    void Start()
    {
        
        bulletSpawmLocation = transform;
        bulletSpawmLocation.position = new Vector2(transform.position.x, transform.position.y);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {        
        if (collision.gameObject.tag == "Enemy")
        {
            enemyLoc = collision.gameObject.GetComponent<Transform>().position;
        }


        if (Time.time > nextFire)
        {
            GameObject temps;
            nextFire = Time.time + fireRate;
            temps = Instantiate(bulletObeject, bulletSpawmLocation, false);
            temps.GetComponent<BulletMovement>().checkDirectionOfEnemy(enemyLoc);
        }
    }
}
