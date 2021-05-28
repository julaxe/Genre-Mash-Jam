using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpaceCheck : MonoBehaviour
{
    public SpriteRenderer renderer;
    protected playerMovement player;
    [SerializeField] private Turret[] turrets;
    bool iscollision = false;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<playerMovement>();
        renderer = GetComponent<SpriteRenderer>();
        renderer.color = new Color(0, 1, 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (player.isGrounded)
        {
            if(!iscollision)
            {
                renderer.color = new Color(0, 1, 0, 1);
                if (Input.GetMouseButtonDown(0))
                {
                    whatTurretToPlace(player.name);
                    player.SetMode(playerMovement.PlayerMode.Play);
                }

            }
            else
            {
                renderer.color = new Color(1, 0, 0, 1);
            }
        }
        else
        {
            renderer.color = new Color(1, 0, 0, 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            iscollision = true;            
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            iscollision = false;           
        }
    }
    void whatTurretToPlace(string a)
    {
        switch (a)
        {
            case "Tower1":
                Turret tower1;
                tower1 = (Turret)Instantiate(turrets[0], new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.identity);
               
                break;
            case "Tower2":
                Instantiate(turrets[1], new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.identity);
                break;
            case "Tower3":
                Instantiate(turrets[2], new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.identity);
                break;
            case "Tower4":
                Instantiate(turrets[3], new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.identity);
                break;

        }
    }
}
