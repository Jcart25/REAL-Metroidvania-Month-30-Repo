using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public float MaxHealth = 3f;

    public float currentHealth;

    private void Awake()
    {
        currentHealth = MaxHealth;
    }

    private void Update()
    {
        if(currentHealth == 0)
        {
            Destroy(gameObject);
        }
    }

    public void Damage(float damage)
    {
        currentHealth -= damage;
    }
}
