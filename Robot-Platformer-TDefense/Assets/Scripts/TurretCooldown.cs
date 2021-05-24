using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretCooldown : MonoBehaviour
{
    [SerializeField]
    private Image turretCooldown;
    [SerializeField]
    private Image blocking;
    [SerializeField]
    private Text textCooldown;
    [SerializeField]
    private int amountOfScraps;
    [SerializeField]
    private int amountOfLegs;
    [SerializeField]
    private int amountOfBrains;
    [SerializeField]
    private int amountOfArms;
    
    public bool possilbeToBuild = false;
    public bool isCooldown = false;
    private float coolDownTime = 5.0f;
    private float coolDownTimer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        blocking.gameObject.SetActive(false);
        textCooldown.gameObject.SetActive(false);
        turretCooldown.fillAmount = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        checkingMeterials();

        if (possilbeToBuild)
        {
            
            if (isCooldown)
                countingCooldown();
        }
        else
        {
            blocking.gameObject.SetActive(true);
        }
    }

    void checkingMeterials()
    {
        if (amountOfScraps <= GameEvent.scraps &&
            amountOfArms <= GameEvent.legs &&
            amountOfLegs <= GameEvent.brains &&
            amountOfBrains <= GameEvent.brains)
        {
            blocking.gameObject.SetActive(false);
            possilbeToBuild = true;
        }
        else
            possilbeToBuild = false;
        
    }

    void countingCooldown()
    {
        coolDownTimer -= Time.deltaTime;

        if(coolDownTimer < 0.0f)
        {
            isCooldown = false;
            textCooldown.gameObject.SetActive(false);
            turretCooldown.fillAmount = 0.0f;
        }
        else
        {
            textCooldown.text = Mathf.RoundToInt(coolDownTimer).ToString();
            turretCooldown.fillAmount = coolDownTimer / coolDownTime;
        }

    }

    public void towerOn()
    {       
        if(!isCooldown)
        {
            isCooldown = true;
            textCooldown.gameObject.SetActive(true);
            coolDownTimer = coolDownTime;
            GameEvent.arms -= amountOfArms;
            GameEvent.brains -= amountOfBrains;
            GameEvent.scraps -= amountOfScraps;
            GameEvent.legs -= amountOfLegs;
           
        }
    }
}
