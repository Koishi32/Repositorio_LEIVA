using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Characters.FirstPerson;
public class ControlInput : MonoBehaviour
{
    public Animator animacion_FPS;
    public bool is_FPS;
    public float vel_walk;
    public FirstPersonController Controlador_personaje;
    // Start is called before the first frame update
    void Start()
    {
        is_FPS = true;
        animacion_FPS.SetBool("Is_moving", false);
       
    }

    // Update is called once per frame
    void Update()
    {
        revisa_movimiento();
        revisa_Input_Ataque();
    }
    public void revisa_Input_Ataque() {
        if (Input.GetKeyDown(KeyCode.E)) {
       //     float anterior = vel_anterior;
        //    vel_anterior = 0;
            animacion_FPS.SetTrigger("Atack");
        }
    }
    public void restaurar ()
    {

    }
    public void revisa_movimiento() {
        float horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        float vertical = CrossPlatformInputManager.GetAxis("Vertical");
        if (horizontal != 0 || vertical != 0)
        {
            animacion_FPS.SetBool("Is_moving", true);
        }
        else
        {
            animacion_FPS.SetBool("Is_moving", false);
        }
    }
    public void cambio () {
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
