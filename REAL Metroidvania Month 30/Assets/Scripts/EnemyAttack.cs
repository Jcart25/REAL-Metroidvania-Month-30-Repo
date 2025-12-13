using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] public GameObject HitBox;
    [SerializeField] public bool AttackActive = false;
    [SerializeField] public float AttackDuration;
    [SerializeField] private float AttackTimer = 0;

    private void Awake()
    {
        HitBox.SetActive(AttackActive);
    }

    private void FixedUpdate()
    {
        if (AttackActive)
        {
            HitBox.SetActive(AttackActive);
            AttackTimer -= Time.fixedDeltaTime;
        }

        if (AttackTimer < 0)
        {
            AttackActive = false;
            HitBox.SetActive(AttackActive);
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AttackActive = true;
            AttackTimer = AttackDuration;
        }
    }

}
