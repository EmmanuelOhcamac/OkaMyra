using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Scr_Trigo : MonoBehaviour
{
    public int estado;
    public float tiempoEspera = 5f;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine (CambiarEstado());
    }

    private IEnumerator CambiarEstado()
    {
        while (estado < 4)
        {
            animator.SetInteger("estado", estado);
            estado ++;
            yield return new WaitForSeconds(tiempoEspera);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
