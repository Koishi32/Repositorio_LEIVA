using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Movimiento : MonoBehaviour
{
    //Variables para controlar la animacion y el rigid body
    public Animator animacion_FPS;
    public bool is_FPS;
    public Rigidbody my_rigid;
    public float vel;

    // Start is called before the first frame update
    void Start()
    {
        is_FPS = true;
        my_rigid = this.GetComponent<Rigidbody>();
        animacion_FPS.SetBool("Is_moving", false);
    }

    // Update is called once per frame
   void Update()
    {
        se_mueve(); // pregunta si se recive input
        salta(); // add force para saltars
    }

    //Funcion para saltar solo añade fuerza
    public void salta() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            my_rigid.AddForce(Vector3.up, ForceMode.Impulse); // Da el salton
        }
    }

    //Seccion Importante Controla movimiento 
    
    public void se_mueve() {
        float horizontal = CrossPlatformInputManager.GetAxis("Horizontal"); // para varias platadformas
        float vertical = CrossPlatformInputManager.GetAxis("Vertical");
        
        if (horizontal != 0 || vertical != 0)
        {
           animacion_FPS.SetBool("Is_moving", true); // se mueve
            empezar_movimiento(horizontal, vertical); // a moverse
        }
        else
        {
           animacion_FPS.SetBool("Is_moving", false); // no se mueve
        }
    }
    // Se encarga de mover al personaje con el rigid bdy
    public void empezar_movimiento(float Horizontal,float Vertical) {
        my_rigid.velocity = vel * (transform.forward * Vertical + transform.right * Horizontal);

    }

    // Cambia los booleanos deacuerdo a si es FPS o no
    public void cambio () { // Cambia los Booleanos para las animaciones
        is_FPS = !is_FPS;
        if (is_FPS == true)
        {
            animacion_FPS.SetBool("Is_3RD", false);
            animacion_FPS.SetBool("Is_FPS", true); // Activa animacion de apuntar
        }
        else
        {
            animacion_FPS.SetBool("Is_3RD", true); // Activa animacion de correr normal
            animacion_FPS.SetBool("Is_FPS", false);
        }

    }


}
