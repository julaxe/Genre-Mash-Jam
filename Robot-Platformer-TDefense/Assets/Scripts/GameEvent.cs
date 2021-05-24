using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEvent : MonoBehaviour
{
    public static int scraps;
    public static int legs;
    public static int arms;
    public static int brains;

    [SerializeField] private Text scrap;
    [SerializeField] private Text leg;
    [SerializeField] private Text arm;
    [SerializeField] private Text brain;

    // Start is called before the first frame update
    void Start()
    {
        legs = 0;
        arms = 0;
        brains = 0;
        scraps = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
