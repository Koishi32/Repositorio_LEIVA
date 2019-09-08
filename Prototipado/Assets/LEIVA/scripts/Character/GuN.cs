using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GuN : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    
    public Camera FPSCAM;
    public ParticleSystem muzzleflash;
    public GameObject impactEffect;
    public float impactforce=100f;
    public float ShootInterval ;
    //public AudioSource disparoaudio;
    public bool canfire = true;

    // private float nextTimeTofire = 0f;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Movimiento.Is_playable)
        {
            Recive();
        }
    }
    void Recive() {
        if (Input.GetButton("Fire1") && canfire)
        {
            canfire = false;

            //nextTimeTofire = Time.time + 100f / firerate; // El fire rate es una decima de segundo 1/10
            Shoot();
            StartCoroutine("Firerate");
        }
    }
    //Espera una cantidad de tiempo antes de que el jugador puede disparar
    IEnumerator Firerate() {
        yield return new WaitForSeconds(ShootInterval);
        canfire = true;
    }
    void Shoot()
    {
		AkSoundEngine.PostEvent("disparo", this.gameObject);
		muzzleflash.Play();
        RaycastHit hit;
       // disparoaudio.Play();
        //Despues de los efectos de sonido y particulas, si el raycast detecta algo entonces imprime su nombre
        if (Physics.Raycast(FPSCAM.transform.position,FPSCAM.transform.forward,out hit,range)) {
            Damageable target = hit.transform.GetComponent<Damageable>();
            if (target != null) {
                target.takeDamage(damage,"Gun"); // Si el objeto golpeado por el ray cast tiene el script gamage entonces sufrira daño
            }
            if (hit.rigidbody != null) {
                hit.rigidbody.AddForce(-hit.normal*impactforce);
            }
        }
        // Instanci un efecto de impacto en el lugar que golpeo el raycast
        GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impactGO,2);
    }
    public float get_Damage()
    {
        return damage;
    }

}
