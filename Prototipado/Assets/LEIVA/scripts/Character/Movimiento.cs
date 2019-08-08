using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Movimiento : MonoBehaviour
{
    //Variables para controlar la animacion y el rigid body
    public Animator animacion_FPS;
    public static bool is_FPS;
    public Rigidbody my_rigid;
    public float vel;
    public float currentX;
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
       
        rotea(); 
   
    }

    //Funcion para saltar solo añade fuerza
    public void salta() {
        if (Input.GetKeyDown(KeyCode.Space)) { //Arreglar vectores movimineto
           // my_rigid.AddForce(Vector3.up, ForceMode.Impulse); // Da el salton
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
    //Lee se el jugador mueve el Mouse X
    public void rotea() {
        currentX += CrossPlatformInputManager.GetAxis("Mouse X");
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
    //Control de la rotacion del jugador

    private void FixedUpdate()
    {
        Quaternion rotation_Player = Quaternion.Euler(0, currentX, 0); //Rotacion depende del Mouse
        this.transform.rotation = rotation_Player;
    }
   
}
