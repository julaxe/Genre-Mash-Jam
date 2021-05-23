using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float lifeTime = 2;
    [SerializeField] private float bulletSpeed = 5;
    [SerializeField] private Rigidbody2D body;
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
        //Bullet movement
        body.velocity = Vector3.left * bulletSpeed;
        
    }

    private void FixedUpdate()
    {
        //Unspawn bullet after certian anoumt of time
        if(Time.time > lifeTime)
        {
            Destroy(this.gameObject);
        }
    }

}
