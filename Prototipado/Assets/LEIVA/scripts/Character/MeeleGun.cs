using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleGun : MonoBehaviour
{
    public float damage;
    public Rigidbody My_RGD; // Toca al enemigo llama a su funcion Damageable
    bool Esta_Atacando;
    public ControlInput ataca_meele;
    public float impactforce;
    // Start is called before the first frame update
    void Start()
    {
        My_RGD = GameObject.FindGameObjectWithTag("Meele_Gun").GetComponent<Rigidbody>();
    }
    public void Update()
    {
        Esta_Atacando = ataca_meele.is_Atacking;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (Esta_Atacando && collision.gameObject.tag == "Enemy") {
            Damageable target = collision.transform.GetComponent<Damageable>();
            if (target != null)
            {
                target.takeDamage(damage); // Si el objeto golpeado por el ray cast tiene el script gamage entonces sufrira daño
            }
            if (collision.rigidbody != null)
            {
                collision.rigidbody.AddForce(-collision.transform.forward * impactforce);
            }
        }
    }
}
