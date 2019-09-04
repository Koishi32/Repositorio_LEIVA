using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossDameage : Damageable
{
    public GameObject titulo_ganador;
    public timeManager tiempo;
    public override void Start()
    {
        recive = true;
        lives = true;
        titulo_ganador = GameObject.Find("GanarUI");
        titulo_ganador.SetActive(false);
        tiempo = GameObject.Find("Manager").GetComponent<timeManager>();
        life_Proportion = vida / segmentsOfLife; // un numero multiplo de la vida original
        original_life = get_life();
        times_surprassed = 1; // veces que rebaso la proporcio
    }

    public float segmentsOfLife; // porciones en las que se partira la vida total
    float original_life;
    public float life_Proportion;
    int times_surprassed; // veces que se completa la life_proportion
    public override void Acciones_extra()
    {
        float diferencia;
        diferencia = original_life - vida; // diferencia de vida con el daño ya hecho
        if (diferencia > life_Proportion * times_surprassed) {
            times_surprassed++;
            tiempo.aumenta_tiempo();
        }
        else {
            print("No amerita aumento de tiemop");
        }
    }
    public override void Die()
    {
        lives = false;
        if (this.tag == "Enemy")
        {
            SendMessage("cancelar_acciones", true); //daña y muere
            tiempo.boos_victory = true;
           /* Movimiento.Is_playable = false;
            if (Movimiento.is_FPS == true)
            {
                GameObject.FindGameObjectWithTag("Player").SendMessage("cambia_camaras");
                Movimiento.is_FPS = false;
            }*/
            titulo_ganador.SetActive(true);
        }
    }
}
