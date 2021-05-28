using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turret : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private int m_MaxHealth;
    private int m_CurrentHealth;

    public HealthBar healthbar;    

    void Start()
    {
        healthbar = transform.Find("CanvasHealth").Find("WallHealthBar").GetComponent<HealthBar>();
        healthbar.slider = healthbar.GetComponent<Slider>();
        m_CurrentHealth = m_MaxHealth;
        healthbar.SetMaxHealth(m_MaxHealth);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        m_CurrentHealth -= damage;        
        healthbar.SetHealth(m_CurrentHealth);        
    }
}
