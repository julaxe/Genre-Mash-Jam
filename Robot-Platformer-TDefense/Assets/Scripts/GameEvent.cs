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
    public static string name;

    [SerializeField] private Text scrap;
    [SerializeField] private Text leg;
    [SerializeField] private Text arm;
    [SerializeField] private Text brain;

    // Start is called before the first frame update
    void Start()
    {
        name = "";
        legs = 0;
        arms = 0;
        brains = 0;
        scraps = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scrap.text = "Scraps x " + scraps.ToString();
        leg.text = "Legs x " + legs.ToString();
        arm.text = "Arms x " + arms.ToString();
        brain.text = "Brains x " + brains.ToString();
    }
}
