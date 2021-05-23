using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float lifeTime = 2;
    [SerializeField] private float bulletSpeed = 5;
    [SerializeField] private Rigidbody2D body;

    float timer; 
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = Vector3.right * bulletSpeed;
        
    }

    private void FixedUpdate()
    {
        timer++;
        if(timer > lifeTime * 60)
        {
            Destroy(this.gameObject);
        }
    }


}
