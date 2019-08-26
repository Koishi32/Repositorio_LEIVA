using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlInput : MonoBehaviour
{
    public Animator animacion_FPS;
    float vel_walk;
    Movimiento Moviento_Personaje; // Para que todos sepan si es FPS o no
    float valor_anterior;
  //  float Atack_intervalAnt;
    public float Atack_Interval; // tiempo que espera para que el jugador haga el siguiente ataque
    public bool is_Atacking;
    public string state;


    // Start is called before the first frame update
    void Start()
    {
        Moviento_Personaje = GameObject.Find("Jugador").GetComponent<Movimiento>();
        valor_anterior = Moviento_Personaje.vel;
    //    Atack_intervalAnt = Atack_Interval;
        is_Atacking = false;
        state = "NoA";
    }

    // Update is called once per frame
    void Update()
    {
        if (Movimiento.Is_playable)
        {
            revisa_Input_Ataque();
        }
       
    }
   // public int Input_count;
    //Contar Inputs
    public void revisa_Input_Ataque() {
        if (Input.GetKeyDown(KeyCode.E) && Movimiento.is_FPS == false) { // si se presiona e 
            switch (state) {
                case "NoA":
                    animacion_FPS.SetBool("Atack1",true); // Activa primera animacion de ataque
                    is_Atacking = true;
                    Moviento_Personaje.vel = 0; // paraliza al personaje
                    break;
                case "Comb1":
                    animacion_FPS.SetBool("Atack2",true);
                    is_Atacking = true;
                    Moviento_Personaje.vel = 0;
                    break;
                case "Comb2":
                    animacion_FPS.SetBool("Atack3",true);
                    is_Atacking = true;
                    Moviento_Personaje.vel = 0;
                    break;
            }
        }
    }
    public void restaurar1() {
        animacion_FPS.SetBool("Atack1", false);
        is_Atacking = false;
        state = "Comb1";
        StartCoroutine("espera");
    }
    public void restaurar2()
    {
        animacion_FPS.SetBool("Atack2", false);
        is_Atacking = false;
        state = "Comb2";
        StartCoroutine("espera");
    }
    public void restaurar3()
    {
        animacion_FPS.SetBool("Atack3", false);
        is_Atacking = false;
        state = "NoA";
        Moviento_Personaje.vel = valor_anterior; //El tercer golpe es el ultimo ataque no necesita esperar por mas Input
    }
    public void empujon() {
       // print("envio");
        SendMessage("Dar_salton");
    }

    IEnumerator espera()
    {
        yield return new WaitForSeconds(Atack_Interval); // Tiempo que espera para continuar combo tiene que ser mas corto que el ataque
        if (is_Atacking==false) {
            state = "NoA";
            Moviento_Personaje.vel = valor_anterior;//Restaura velocidad , personaje puede volver a moverse
        }
    }
    

}



