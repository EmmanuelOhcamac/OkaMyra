using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class Scr_PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public int life = 50;

    private Rigidbody2D rb2D;
    private Vector2 movementInput;

    private bool recibeDamage;
    public float fuerzaRebote = 10f;
    public bool dead;

    private Animator animator;

    public GameObject preFabTrigo;
    public GameObject preFabJitomate;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead)
        {
            movementInput.x = Input.GetAxisRaw("Horizontal");
            movementInput.y = Input.GetAxisRaw("Vertical");

        }
        else
        {
            movementInput.x = 0;
            movementInput.y = 0;
        }
        if (!recibeDamage)

            movementInput = movementInput.normalized;

        animator.SetFloat("Horizontal", movementInput.x);
        animator.SetFloat("Vertical", movementInput.y);
        animator.SetFloat("Speed", movementInput.magnitude);
        animator.SetBool("recibeDamage", recibeDamage);
        
    }

    public void RecibeDamage(Vector2 direction, int damage)
    {
        if (!recibeDamage)
        {
            recibeDamage = true;
            life -= damage;
            if (life < 0)
            {
                dead = true;
            }
            if (!dead)
            {
                Vector2 rebote = new Vector2(transform.position.x - direction.x, transform.position.y - direction.y).normalized;
                rb2D.AddForce(rebote * fuerzaRebote, ForceMode2D.Impulse);
            }
        }
    }
    public void DesactiveDamage()
    {
        recibeDamage = false;
    }

    private void FixedUpdate()
    {
        rb2D.MovePosition(rb2D.position + movementInput * speed * Time.fixedDeltaTime);
    }

    public void SembrarTrigo(InputAction.CallbackContext contexto)
    {
        if (contexto.started)
        {
            Instantiate(preFabTrigo, transform.position, Quaternion.identity);
        }
    }

    public void SembrarJitomate(InputAction.CallbackContext contexto)
    {
        if (contexto.started)
        {
            Instantiate(preFabJitomate, transform.position, Quaternion.identity);
        }
    }
}
