using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPlacement : MonoBehaviour
{
    [SerializeField] private GameObject turretOne;
    [SerializeField] private GameObject turretTwo;
    [SerializeField] private GameObject turretThree;
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
                break;
            case 2:
                Instantiate(turretTwo, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.identity);
                break;
            case 3:
                Instantiate(turretThree, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.identity);
                break;
            default:
                Debug.Log("TurretNumber Error");
                break;
        }
    }

}
