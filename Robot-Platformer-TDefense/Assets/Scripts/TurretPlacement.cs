using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPlacement : MonoBehaviour
{
    [SerializeField] private GameObject turretOne;
    [SerializeField] private GameObject turretTwo;
    [SerializeField] private GameObject turretThree;
    [SerializeField] private TurretCooldown[] turrets;
   
    private KeyCode[] keyCodes = {
         KeyCode.Alpha1,
         KeyCode.Alpha2,
         KeyCode.Alpha3,
         KeyCode.Alpha4,
         KeyCode.Alpha5,
         KeyCode.Alpha6,
         KeyCode.Alpha7,
         KeyCode.Alpha8,
         KeyCode.Alpha9,
     };
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < keyCodes.Length; i++)
        {
            if (Input.GetKeyDown(keyCodes[i]))
            {
                int numberPressed = i + 1;
                if(!turrets[numberPressed -1].isCooldown && turrets[numberPressed - 1].possilbeToBuild)
                    whatTurretToPlace(numberPressed);
            }
        }
    }

    void whatTurretToPlace(int a)
    {
        switch (a)
        {
            case 1:
                Instantiate(turretOne, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.identity);
                turrets[a - 1].towerOn();
                break;
            case 2:
                Instantiate(turretTwo, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.identity);
                turrets[a - 1].towerOn();
                break;
            case 3:
                Instantiate(turretThree, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.identity);
                turrets[a - 1].towerOn();
                break;
            default:
                Debug.Log("TurretNumber Error");
                break;
        }
    }

}
