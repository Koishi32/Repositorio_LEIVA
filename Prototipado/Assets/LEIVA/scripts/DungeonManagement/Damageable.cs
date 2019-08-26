using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public float vida=50;
    public float reciveDaño_tiempo=0.50f;
    public bool recive=true;
    bool lives=true;
    public void takeDamage(float amount,string gun_type)
    {
        if (lives)
        {
            switch (gun_type)
            {
                case "Meele":
                    if (DoDamage())
                    {
                        vida -= amount;
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
            Destroy(this.GetComponentInChildren<NPCcontroller>());
            trigger_deaht = this.GetComponentInChildren<Animator>();
            trigger_deaht.SetTrigger("Is_Death");
        }
    }
    public void desaparcer() {
        if (this.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }

}
