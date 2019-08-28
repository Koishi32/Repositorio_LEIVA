using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MeeleGun : MonoBehaviour
{
    public float damage;
  //  public Rigidbody My_RGD; 
    public bool ataca_meele;
    public float impactforce;
    public string Nombre_Objetivo; //Nombre de la game object tag a la que se hara daño
    public Transform CharaForzeDir; //adelante del que hace daño para infligir fuerza
    
    // Start is called before the first frame update
    public virtual void Start()
    {
        CharaForzeDir = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        
    }
    public virtual void get_componenet() {
        ataca_meele = this.GetComponentInParent<ControlInput>().is_Atacking;
    }
    private void OnTriggerEnter(Collider collision) // Toca al enemigo llama a su funcion Damageable
    {
        get_componenet();
        if (ataca_meele && collision.gameObject.tag == Nombre_Objetivo) {
            Damageable target = collision.transform.GetComponent<Damageable>();
            if (target != null)
            {
                target.takeDamage(damage, "Meele"); // Si el objeto golpeado por el arma Meele
                if (collision.attachedRigidbody.velocity.magnitude == 0) { //si esta quieto
                    float tempImpactforze = impactforce / 2; //Reduce impacto entre dos para asegurar que no salga volando
                }
                collision.gameObject.GetComponent<Rigidbody>().AddForce(CharaForzeDir.transform.forward.normalized*impactforce,ForceMode.Impulse);
            }
           
        }
    }

    

 
}
