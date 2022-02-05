using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerFuego : MonoBehaviour
{

    public GameObject Jugador;
    public GameObject EfectoAgua;
    public GameObject EfectoFuego;
    private Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = anim = Jugador.GetComponent<Animator>(); 
    }


    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fuego")
        {
            Destroy(Jugador,1);
            Instantiate(EfectoFuego);
            anim.SetBool("Muerte", true);
            anim.SetTrigger("Morir");

        }

        else if (collision.gameObject.tag == "Agua")
        {
            Instantiate(EfectoAgua);
            anim.SetBool("Agua", true);
        }


    }
}