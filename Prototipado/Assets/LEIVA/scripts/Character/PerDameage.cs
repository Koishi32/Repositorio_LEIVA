using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerDameage : Damageable
{
    public override void Start()
    {
        vida = 0; //No nos servira esta variable ya que se modificara la salid del player desde Movimiento
        recive = true;
        lives = true;
    }


    public override void inflijirDañosMeele(float amount)
    {
        if (ControlInput.Not_beingAtacked)
        { //Se asegura que solo recibe un daño por animación
            SendMessage("recibe_Damague");
            GetComponent<Movimiento>().my_life -= amount;
        }
    }

    public override void inflijirDañosDist(float amount)
    {
        GetComponent<Movimiento>().my_life -= amount;
    }

    public override void checkLife()
    {
        if (GetComponent<Movimiento>().my_life < 0f)
        {
            Die();
        }
    }

    public override void Die()
    {
        lives = false;
        SendMessage("muerte");
    }
}