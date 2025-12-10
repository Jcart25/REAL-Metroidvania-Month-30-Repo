using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttackScript : MonoBehaviour
{
    [SerializeField] public float AttackPower = 1f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided with: " + collision.name);

        if (collision.CompareTag("Enemy"))
        {
            
            collision.GetComponent<EnemyHealth>().Damage(AttackPower);
        }
    }

}
