using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletObeject;
    private Transform bulletSpawmLocation;

    // Start is called before the first frame update
    void Start()
    {
        bulletSpawmLocation = transform;
        bulletSpawmLocation.position = new Vector2(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Shoot");
        Instantiate(bulletObeject, bulletSpawmLocation, false);

    }
}
