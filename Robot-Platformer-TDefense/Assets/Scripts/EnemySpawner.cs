using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject MeleeEnemy;
    [SerializeField] private GameObject RangeEnemy;
    [SerializeField] private float m_Cooldown;
    private float m_timer;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(m_timer > m_Cooldown)
        {
            if(Random.Range(0,2) == 0)
            {
                GameObject temp = Instantiate(MeleeEnemy);
                temp.transform.position = transform.position;
            }
            else
            {
                GameObject temp = Instantiate(RangeEnemy);
                temp.transform.position = transform.position;
            }
            m_timer = 0;
        }
        m_timer += Time.deltaTime;
    }
}
