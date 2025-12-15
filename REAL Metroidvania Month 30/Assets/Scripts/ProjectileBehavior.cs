using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{

    public float speed = 4.5f;
    public float timer = 5.0f;

    private Rigidbody2D rb;

    public void Fire(float direction)
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(direction * speed, 0f);
    }

    private void FixedUpdate()
    {

        timer -= Time.fixedDeltaTime;

        if(timer <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<EnemyHealth>().Damage(1f);
            Destroy(gameObject);
        }
    }
}
