using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controles : MonoBehaviour {

    public GameObject Jugador;
    public GameObject SonidoSalto;
    public GameObject Trigger;
    public GameObject Camara;
    //public GameObject Mapa;
    public bool x,y,z;
    public float ejeY;
    public float Velocidad;
    public float Salto;
    private Rigidbody2D rigidbody2;
    private Animator anim;
    SpriteRenderer sprite;


    // Use this for initialization
    void Start () {
        rigidbody2 = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        
        		
	}
	

    private void FixedUpdate()
    {
        if (anim.GetBool("Muerte") == false && anim.GetBool("Choque") == false)
        {
            Jugador.transform.Translate(Velocidad, 0, 0);
            if (Camara.transform.position.x < 15)
            {
                Camara.transform.Translate(Velocidad, 0, 0);
            }

            if (Velocidad > 0)
            {
                anim.SetBool("Corriendo", true);
            }

            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }

        }
        
    }

    private void Update()
    {
        if (anim.GetBool("Muerte") == false && anim.GetBool("Choque") == false )
        {

            if (Input.GetKey(KeyCode.UpArrow) && x)
            {
                Instantiate(SonidoSalto);
                anim.SetBool("Corriendo", false);
                anim.SetBool("Agua", true);
                anim.SetBool("Fuego", false);
                rigidbody2.gravityScale = -3;
                x = false;
                sprite.flipY = true;


            }

            else if (Input.GetKey(KeyCode.DownArrow) && x)
            {
                Instantiate(SonidoSalto);
                anim.SetBool("Corriendo", false);
                anim.SetBool("Agua", false);
                anim.SetBool("Fuego", true);
                rigidbody2.gravityScale = 3;
                x = false;
                sprite.flipY = false;


            }

            if (Input.GetKey(KeyCode.Space) && y)
            {
                anim.SetBool("Corriendo", false);
                anim.SetBool("Girar", true);
                anim.SetTrigger("Giro");
                Instantiate(SonidoSalto);

                if ( z== false)
                {
                    Trigger.transform.Rotate(180, 0, 0);
                }

                if (rigidbody2.gravityScale > 0)
                {

                    ejeY = Jugador.transform.position.y;
                    rigidbody2.AddForce(Vector2.up * Salto);
                    y = false;

                }

                else if (rigidbody2.gravityScale < 0)
                {
                    ejeY = Jugador.transform.position.y;
                    rigidbody2.AddForce(Vector2.down * Salto);
                    y = false;

                }



            }



        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        anim.SetBool("Girar", false);
        z = true;

        if (collision.gameObject.tag == "Fuego" || collision.gameObject.tag == "Agua")
        {
            

            anim.SetBool("Corriendo", true);
            x = true;
            y = true;
        }

        else
        {
            anim.SetBool("Choque", true);
            anim.SetTrigger("Chocar");
            Destroy(Jugador,1);
            
        }

       
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (z && y == false)
        {
            Trigger.transform.Rotate(180, 0, 0);
        }

        z = false;
    }

    private void OnBecameInvisible()
    {
       SceneManager.LoadScene("Menu");
    }






}
