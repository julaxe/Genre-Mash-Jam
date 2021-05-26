using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyAttackingTurret : MonoBehaviour
{
    [SerializeField] private int damageToTurret = 5;
    [SerializeField] private float attackTimer = 3;
    private float nextAttack = 0;
    private bool canAttack = true;
    // Start is called before the first frame update
    void Start()
    {
        
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

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Turret" && canAttack == true)
        {
            canAttack = false;
            collision.gameObject.GetComponent<Turret>().TakeDamage(damageToTurret);

        }

    }
}
