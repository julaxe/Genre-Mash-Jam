using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpaceCheck : MonoBehaviour
{
    protected SpriteRenderer renderer;
    bool iscollision = false;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            renderer.color = new Color(1, 0, 0, 1);
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            renderer.color = new Color(0, 1, 0, 1);
        }
    }
}
