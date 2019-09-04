using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public float vida; //Vida del jefe , item o enemigo comun
    public float reciveDaño_tiempo;
    public bool recive;
    public bool lives;
    
    // Recordar hacer este script hederable por el amor de dios 
    public virtual void Start()
    {
        recive = true;
        lives = true;
       
    }
    public float get_life() {
        return vida;
    }
    public virtual void Acciones_extra()
    {}
    public virtual void inflijirDañosMeele(float amount) {
        if (this.tag == "Enemy")
        {
            SendMessage("cancelar_acciones", false); //daña pero no muere permite stun
            vida -= amount;

        }
        else
        {
            vida -= amount;
        }
    }
    public virtual void inflijirDañosDist(float amount) {
        vida -= amount;
    }
    public  void takeDamage(float amount,string gun_type)
    {
        if (lives)
        {
            switch (gun_type)
            {
                case "Meele":
                    if (DoDamage()) //hay un conteo para el daño que se puede inflijir
                    {
                        inflijirDañosMeele(amount);
                    }
                    break;
                case "Gun":
                    inflijirDañosDist(amount);
                    break;
            }
            checkLife();
            Acciones_extra();
        }
    
    }

    public virtual void checkLife() { //chekea la vida
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
            return true;// Puede volver a dañar
        }
        return false; //No puede dañar otra vez
    }

    IEnumerator espera()
    {
        yield return new WaitForSeconds(reciveDaño_tiempo);
        recive = true;
    }

   // Animator trigger_deaht

    public virtual void Die() {
        lives = false;
        if (this.tag == "Enemy") {
            SendMessage("cancelar_acciones",true); //daña y muere
        }
  
    }

    public void desaparcer() {
        if (this.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }

}
