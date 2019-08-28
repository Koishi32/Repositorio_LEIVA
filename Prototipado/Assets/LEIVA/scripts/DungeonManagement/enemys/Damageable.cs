using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public float vida;
    public float reciveDaño_tiempo;
    public bool recive=true;
    bool lives=true;
    bool is_player=false;
    public void Start()
    {
        if (this.gameObject.tag == "Player") {
            vida = GetComponent<Movimiento>().my_life;
            is_player = true;
        }
    }
    public void takeDamage(float amount,string gun_type)
    {
        if (lives)
        {
            switch (gun_type)
            {
                case "Meele":
                    if (DoDamage())
                    {
                        if (is_player && ControlInput.Not_beingAtacked)
                        { //Se asegura que solo recibe un daño por animación
                            SendMessage("recibe_Damague");
                            vida -= amount;
                        }
                        else if (!is_player){
                            vida -= amount;
                        }
                    }
                    break;
                case "Gun":
                    vida -= amount;
                    break;

            }
            checkLife();
        }
    
    }

    void checkLife() {
        if (vida <= 0f)
        {
            Die();
        }
    }
     bool DoDamage() // No puede recibir daño de la misma arma por medio seg.
    {
        if (recive)
        {
            recive = false;
            StartCoroutine("espera");
            return true;
        }
        return false;
    }

    IEnumerator espera()
    {
        yield return new WaitForSeconds(reciveDaño_tiempo);
        recive = true;
    }

    Animator trigger_deaht;

    void Die() {
        lives = false;
        if (this.tag == "Enemy") {
            SendMessage("cancelar_acciones");
            trigger_deaht = this.GetComponent<Animator>();
            trigger_deaht.SetTrigger("Is_Death"); //Asegurar que todas las trigger de enemigos sean Is_Death
        }else if(is_player)
        {
            SendMessage("muerte");
        }
    }

    public void desaparcer() {
        if (this.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }

}
