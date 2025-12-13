using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttackScript : MonoBehaviour
{
    [SerializeField] public float AttackPower = 1f;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Enemy"))
        {
            
            collision.GetComponent<EnemyHealth>().Damage(AttackPower);
        }

        if (collision.CompareTag("Player"))
        {

            collision.GetComponent<EnemyHealth>().Damage(AttackPower);
        }
    }

}
