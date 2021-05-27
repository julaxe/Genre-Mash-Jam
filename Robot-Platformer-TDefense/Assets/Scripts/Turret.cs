using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int m_MaxHealth;
    private int m_CurrentHealth;

    private HealthBar healthbar;

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
