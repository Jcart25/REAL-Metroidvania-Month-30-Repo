using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] public Transform pointA;
    [SerializeField] public Transform pointB;

    [SerializeField] public EnemyAttack detectBox;
    [SerializeField] public float speed = 4f;

    [SerializeField] public float PauseDuration;
    public float PauseTimer = 0;


    public bool isAttacking;

    public Vector3 target;

    private void Start()
    {
        target = pointA.transform.position;
    }

    private void FixedUpdate()
    {
        if(detectBox.AttackActive)
        {
            PauseTimer = PauseDuration;
        }
        
        if(PauseTimer < 0.0f)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.fixedDeltaTime);

            if (Vector2.Distance(transform.position, target) < 0.1f)
            {
                target = (target == pointA.position) ? pointB.position : pointA.position;
                Flip();
            }
        } else
        {
           PauseTimer -= Time.fixedDeltaTime;
        } 
    }

    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
}
