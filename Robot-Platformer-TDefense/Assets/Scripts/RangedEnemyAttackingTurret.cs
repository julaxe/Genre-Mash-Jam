using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyAttackingTurret : MonoBehaviour
{
    [SerializeField] private GameObject bulletObeject;
    [SerializeField] private Vector3 enemyLoc;
    [SerializeField] private int damageToTurret = 5;
    [SerializeField] private float attackTimer = 3;   
    private Transform bulletSpawmLocation;
    private float nextAttack = 0;
    private bool canAttack = true;
    private Rigidbody2D body;
    private float savedMovementSpeed;


    // Start is called before the first frame update
    void Start()
    {
        bulletSpawmLocation = transform;
        bulletSpawmLocation.position = new Vector2(transform.position.x, transform.position.y);
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextAttack)
        {
            nextAttack = Time.time + attackTimer;
            canAttack = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Turret")
        {
            savedMovementSpeed = this.gameObject.GetComponent<EnemyMovement>().getMovementSpeed();
            this.gameObject.GetComponent<EnemyMovement>().changeMovementSpeed(0); 
        }

        if (collision.gameObject.tag == "Turret" && canAttack == true)
        {
            
            canAttack = false;
            enemyLoc = collision.gameObject.GetComponent<Transform>().position;
            GameObject temps;
            temps = Instantiate(bulletObeject, bulletSpawmLocation, false);
            temps.GetComponent<BulletMovement>().checkDirectionOfEnemy(enemyLoc);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Turret")
        {
            this.gameObject.GetComponent<EnemyMovement>().changeMovementSpeed(savedMovementSpeed);
        }
    }
}
