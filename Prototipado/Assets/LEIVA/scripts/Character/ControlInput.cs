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
    public float wait_painEnd; //tiempo antes de que haga otra animacion de dolor
    public string state;
    public GameObject efecto_arma;
    public static bool Not_beingAtacked;
    // Start is called before the first frame update
    void Start()
    {
        efecto_arma.SetActive(false);
        Moviento_Personaje = GameObject.Find("Jugador").GetComponent<Movimiento>();
        valor_anterior = Moviento_Personaje.vel;
    //    Atack_intervalAnt = Atack_Interval;
        is_Atacking = false;
        state = "NoA";
        Not_beingAtacked = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Movimiento.Is_playable && Not_beingAtacked)
        {
            revisa_Input_Ataque();
            print(Moviento_Personaje.vel);
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
    public void recibe_Damague() { // es llamada desde el Damageable del player
        if (Not_beingAtacked && !is_Atacking) {
            Not_beingAtacked = false;
            is_Atacking = false;
            /*state = "NoA";
            animacion_FPS.SetBool("Atack1", false);
            animacion_FPS.SetBool("Atack2", false);
            animacion_FPS.SetBool("Atack3", false);*/
            Moviento_Personaje.vel = 0;
            animacion_FPS.SetTrigger("Is_Hurt");
        } // Evita que se llame dos veces
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
    public void restaurar4()
    {
        Moviento_Personaje.vel = valor_anterior;
        StartCoroutine("espera2");
    }
    IEnumerator espera2()
    {
        print("waiting");
        yield return new WaitForSeconds(wait_painEnd); // Tiempo que espera para hacer otra animacion de dolor
        Not_beingAtacked = true;
    }
    public void empujon() {
       // print("envio");
        SendMessage("Dar_salton");
    }

    IEnumerator espera()
    {
        efecto_arma.SetActive(true); //muestra al jugador momento para atacar
        yield return new WaitForSeconds(Atack_Interval); // Tiempo que espera para continuar combo tiene que ser mas corto que el ataque
        efecto_arma.SetActive(false);
        if (is_Atacking==false) {
            state = "NoA";
            Moviento_Personaje.vel = valor_anterior;//Restaura velocidad , personaje puede volver a moverse
        }
    }
    

}



