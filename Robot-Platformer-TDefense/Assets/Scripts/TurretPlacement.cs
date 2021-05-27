using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPlacement : MonoBehaviour
{
    [SerializeField] private GameObject[] turrets;
       
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            
        }        
    }

    void whatTurretToPlace(int a)
    {
        switch (a)
        {
            case 1:
                Instantiate(turrets[a - 1], new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.identity);
                
                break;
            case 2:
                Instantiate(turrets[a - 1], new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.identity);
                
                break;
            case 3:
                Instantiate(turrets[a - 1], new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.identity);
                
                break;
            default:
                Debug.Log("TurretNumber Error");
                break;
        }
    }

}
