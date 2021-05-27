using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    // Start is called before the first frame update
    public int m_MaxHealth = 100;
    private int m_CurrentHealth;

    protected HealthBar healthbar;
    

    void Start()
    {
        healthbar = transform.Find("CanvasHealth").Find("HealthBar").GetComponent<HealthBar>();                
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
