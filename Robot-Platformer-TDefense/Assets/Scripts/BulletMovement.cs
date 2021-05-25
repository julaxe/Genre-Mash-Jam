using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float lifeTime = 2;
    [SerializeField] private float bulletSpeed = 5;
    [SerializeField] private Rigidbody2D body;
    private Vector3 shootDirection; 
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        //Time.time need to be add on
        //https://docs.unity3d.com/ScriptReference/Time-time.html
        lifeTime = lifeTime + Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        //Unspawn bullet after certian anoumt of time
        if (Time.time > lifeTime)
        {
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        //Bullet movement
        body.velocity = shootDirection * bulletSpeed;
    }

    public void checkDirectionOfEnemy(Vector3 a)
    {
        if(transform.position.x < a.x)
        {
            shootDirection = new Vector3(1, 0, 0);
            return;
        }
        shootDirection = new Vector3(-1, 0, 0);
    }


}
