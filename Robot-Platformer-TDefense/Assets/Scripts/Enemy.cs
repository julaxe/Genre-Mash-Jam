using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int m_MaxHealth;
    private int m_CurrentHealth;

    private newHealthBar healthbar;

    void Start()
    {
        healthbar = transform.Find("CanvasHealth").Find("HealthBar").GetComponent<newHealthBar>();
        //healthbar.slider = transform.Find("CanvasHealth").Find("HealthBar").GetComponent<HealthBar>().GetComponent<Slider>();
        m_CurrentHealth = m_MaxHealth;
        healthbar.SetMaxHealth(m_MaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage(int damage)
    {
        m_CurrentHealth -= damage;
        healthbar.SetHealth(m_CurrentHealth);
    }
}
