using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Runtime.CompilerServices;

public class Scr_Bos : MonoBehaviour
{
    public bool dead;
    private bool recibeDamage;

    public float tiempoSiguienteEnemigo = 5f;
    public float tiempoDano = 10f;
    public float life = 500;

    private float minX, maxX, minY, maxY;
    [SerializeField] private Transform[] puntos;
    [SerializeField] private GameObject[] enemigos;
    [SerializeField] private float tiempoEnemigos;


    // Start is called before the first frame update
    void Start()
    {

        maxX = puntos.Max(punto => punto.position.x);
        minX = puntos.Min(punto => punto.position.x);
        maxY = puntos.Max(punto => punto.position.y);
        minY = puntos.Min(punto => punto.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        recibeDamage = false;
        if (!dead)       //vivo
        {
            tiempoSiguienteEnemigo += Time.deltaTime;
            if (tiempoSiguienteEnemigo >= tiempoEnemigos)
            {
                tiempoSiguienteEnemigo = 0;
                CrearEnemigo();
            }
        }
        else if (dead == true) //muerto
        {
            Destroy(gameObject);
        }
    }

    public void RecibeDamage(int damage)
    {
        if (!recibeDamage)
        {
            recibeDamage = true;
            life -= damage;
            if (life <= 0)
            {
                dead = true;
            }
        }
    }
    public void DesactiveDamage()
    {
        recibeDamage = false;
    }

    private void CrearEnemigo()
    {
        int numeroEnemigo = Random.Range(0, enemigos.Length);
        Vector2 posicionAleatoria = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

        Instantiate(enemigos[numeroEnemigo], posicionAleatoria, Quaternion.identity);
    }
}
