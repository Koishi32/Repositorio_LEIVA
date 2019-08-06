using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlInput : MonoBehaviour
{
    public Animator animacion_FPS;
    float vel_walk;
    Movimiento Moviento_Personaje;
    float valor_anterior;
    // Start is called before the first frame update
    void Start()
    {
        Moviento_Personaje = GameObject.Find("Jugador").GetComponent<Movimiento>();
    }

    // Update is called once per frame
    void Update()
    {
        revisa_Input_Ataque();
    }

    public void revisa_Input_Ataque() {
        if (Input.GetKeyDown(KeyCode.E)) { // si se presiona e 
            if (Moviento_Personaje.is_FPS == false) { // y si no se esta en primera persona
                animacion_FPS.SetTrigger("Atack"); // Activa animacion de ataque
                valor_anterior = Moviento_Personaje.vel; // paraliza al personaje
                Moviento_Personaje.vel = 0;
            }
          
        }
    }
    public void restaurar() {
        Moviento_Personaje.vel = valor_anterior; // Restaura velocidad anterior del personaje
    }

    }



