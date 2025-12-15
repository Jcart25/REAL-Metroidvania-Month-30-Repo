using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] public GameObject HitBox;
    [SerializeField] public bool isMelee;
    [SerializeField] public bool AttackActive = false;
    [SerializeField] public float AttackDuration;
    [SerializeField] private float AttackTimer = 0;

    //Projectile
    [SerializeField] public ProjectileBehavior projectile;
    [SerializeField] public Transform launcher;
    public bool hasShot = false;

    private void Awake()
    {
        HitBox.SetActive(AttackActive);
    }

    private void FixedUpdate()
    {
        if (!AttackActive) return;
        {
            AttackTimer -= Time.fixedDeltaTime;
            
            if (isMelee)
            {
                HitBox.SetActive(AttackActive);
            } else
            {
                if(!hasShot)
                {
                    ProjectileBehavior proj = Instantiate(projectile, launcher.position, Quaternion.identity);
                    float direction = transform.localScale.x > 0 ? 1f : -1f;
                    proj.Fire(direction);
                    hasShot = true;
                }
                
            }
            
        }

        if (AttackTimer <= 0)
        {
            AttackEnd();
        }
    }

    private void AttackEnd()
    {
        AttackActive = false;
        hasShot = false;
        HitBox.SetActive(AttackActive);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !AttackActive)
        {
            AttackActive = true;
            AttackTimer = AttackDuration;
        }
    }

}
