using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private float jumpForce = 10;

    private Rigidbody2D body;
    public Camera cam1;
    public Camera cam2;
    // Start is called before the first frame update
    void Start()
    {
        cam1.enabled = true;
        cam2.enabled = false;
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //player jumping
        if(Input.GetKeyDown(KeyCode.Space)) {
            body.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
        if(Input.GetKeyUp(KeyCode.G))
        {
            if (cam1.enabled == true)
            {
                cam1.enabled = false;
                cam2.enabled = true;
            }
            else
            {
                cam1.enabled = true;
                cam2.enabled = false;
            }
        }
        
    }
    private void FixedUpdate()
    {
        //player movement on x axis 
        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0);
    }
}


