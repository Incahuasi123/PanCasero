using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerAgua : MonoBehaviour {

    public GameObject Jugador;
    public GameObject EfectoAgua;
    public GameObject EfectoFuego;
    private Animator anim;
    
    void Start () {
       anim = Jugador.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fuego")
        {
            anim.SetBool("Fuego", true);
            Instantiate(EfectoFuego);

        }

        else if (collision.gameObject.tag == "Agua")
        {
            Destroy(Jugador,1);
            Instantiate(EfectoAgua);
            anim.SetBool("Agua", true);
            anim.SetBool("Muerte", true);
            anim.SetTrigger("Morir");
        }

        

    }

    
}
