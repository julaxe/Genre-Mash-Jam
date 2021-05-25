using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeterialBehavior : MonoBehaviour
{
    
    private float timecounter;
    [SerializeField]
    private string meterialName;
    [SerializeField]
    private float radius;
    [SerializeField]
    private float ispeed;
    private bool isCollision;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        isCollision = false;
        timecounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCollision)
        {
            if (radius < 0.1f)
            {
                switch (meterialName)
                {
                    case "scraps":
                        ++GameEvent.scraps;
                        break;
                    case "arms":
                        ++GameEvent.arms;
                        break;
                    case "brains":
                        ++GameEvent.brains;
                        break;
                    case "legs":
                        ++GameEvent.legs;
                        break;

                }
                Destroy(gameObject);
            }
            timecounter += Time.deltaTime * ispeed;
            radius -= Time.deltaTime * 0.4f;
            float x = player.transform.position.x + Mathf.Cos(timecounter) * radius;
            float y = player.transform.position.y + Mathf.Sin(timecounter) * radius;
            transform.position = new Vector2(x, y);

        }
    }
    private void FixedUpdate()
    {
  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("collision");
            isCollision = true;
            player = collision.transform;            
        }
    }
}
