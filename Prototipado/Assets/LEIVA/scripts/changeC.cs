using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeC : MonoBehaviour
{
   public  Camera cam1; // Guarda camara FPS
   public Camera cam2; // Guarda camar Tercera persona
    public GameObject Arma; // prefab del arma para FPS
    public Movimiento FPS_valor; // Referencia para actiar animnaciones desde movimiento
    bool activado; // prende apaga camaras
    bool cambiando; //Indica si esta cambiando
    public float tiempo_espera; // intervalo en que cambia camaras para dar tiempo entre cambios
    private void Start()
    {
        activado = true;
        cam1.gameObject.SetActive(activado);
        cam2.gameObject.SetActive(!activado);
        cambiando = false;
        Arma.SetActive(activado); //Desactiva el arma de fuego
    }
    // Este efecto se puede lograr mas elegantemente con Cine machine , creo
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && cambiando==false)
        {
            cambiando = true;
            activado = !activado;
            cam1.gameObject.SetActive(activado); // cambia las camaras activas
            cam2.gameObject.SetActive(!activado);
            Arma.SetActive(activado); //Activa o desactiva el arma de fuego el arma de fuego
            FPS_valor.cambio();
            StartCoroutine("espera");
        }
    }
    IEnumerator espera ()
    {
        yield return new WaitForSeconds(tiempo_espera);
        cambiando = false;
    }
}
