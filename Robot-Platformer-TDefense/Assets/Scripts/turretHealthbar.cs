using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretHealthbar : MonoBehaviour
{
    [SerializeField] private float amountOfHealth = 100;
    [SerializeField] private GameObject healthBar;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void healthChange(float a)
    {
        amountOfHealth += a;
        healthBar.GetComponent<Transform>().localScale = new Vector3( 2* (amountOfHealth/ 100), 0.2f, 0f);   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            healthChange(-10);
        } 
    }
}
