using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_EnemyMovement : MonoBehaviour
{
    public Transform Player;
    public float detectionRadius = 5.0f;
    public float speed = 4.0f;

    private Rigidbody2D rb;
    private Vector2 movement;

    private bool playerAlive;

    // Start is called before the first frame update
    void Start()
    {
        playerAlive = true;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerAlive)
        {
            Movement();
        }
        
    }

    private void Movement()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, Player.position);
        if (distanceToPlayer < detectionRadius)
        {
            Vector2 direction = (Player.position - transform.position).normalized;

            movement = new Vector2(direction.x, direction.y);
        }
        else
        {
            movement = Vector2.zero;
        }

        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 directionDamage = new Vector2(transform.position.x, 0);
            
            collision.gameObject.GetComponent<Scr_PlayerMovement>().RecibeDamage(directionDamage, 10);
            playerAlive = !collision.gameObject.GetComponent<Scr_PlayerMovement>().dead;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
