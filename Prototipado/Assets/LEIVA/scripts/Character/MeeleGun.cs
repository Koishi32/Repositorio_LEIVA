using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleGun : MonoBehaviour
{
    public float damage;
  //  public Rigidbody My_RGD; 
    bool Esta_Atacando;
    public ControlInput ataca_meele;
    public float impactforce;
    Transform PlayerCamaraFPS;
    // Start is called before the first frame update
    public void Start()
    {
        PlayerCamaraFPS = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        recive = true;
    }
    public void Update()
    {
        Esta_Atacando = ataca_meele.is_Atacking;
    }
    private void OnTriggerEnter(Collider collision) // Toca al enemigo llama a su funcion Damageable
    {
        if (Esta_Atacando && collision.gameObject.tag == "Enemy") {
            Damageable target = collision.transform.GetComponent<Damageable>();
            if (target != null && DoDamage())
            {
                target.takeDamage(damage); // Si el objeto golpeado por el arma Meele
                collision.gameObject.GetComponent<Rigidbody>().AddForce(PlayerCamaraFPS.transform.forward.normalized*impactforce,ForceMode.Impulse);
            }
           
        }
    }

    public float reciveDaño_tiempo;
    public bool recive;
    public bool DoDamage() {
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
}
