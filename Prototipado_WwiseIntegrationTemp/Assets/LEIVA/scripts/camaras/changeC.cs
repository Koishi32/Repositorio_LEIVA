using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeC : MonoBehaviour
{
   public  Camera cam1; // Guarda camara FPS
    public Camera cam2; // Guarda camar Tercera persona
    public GameObject Arma; // prefab del arma para FPS
    public GameObject Arma_Meele;
    public Movimiento FPS_valor; // Referencia para actiar animnaciones desde movimiento
    bool activado; // prende apaga camaras
    bool cambiando; //Indica si esta cambiando
    public float tiempo_espera; // intervalo en que cambia camaras para dar tiempo entre cambios
    public Image puntero;
    public Movimiento RevisaI;
    private void Start()
    {
        activado = true;
        cam1.gameObject.SetActive(activado);
        cam2.gameObject.SetActive(!activado);
        cambiando = false;
        Arma.SetActive(activado); //activa el arma de fuego
        puntero = GameObject.Find("Punteria").GetComponent<Image>(); // consigue el sprite del puntero
        puntero.enabled = activado;
        RevisaI = GameObject.Find("Jugador").GetComponent<Movimiento>();
        Arma_Meele.SetActive(!activado);
    }
    // Este efecto se puede lograr mas elegantemente con Cine machine , creo
    void Update()
    {
        if (Movimiento.Is_playable)
        {
            Recive();
        }
    }
    void Recive() {
        if ((Input.GetKeyDown(KeyCode.Q) || Input.GetMouseButtonDown(1)) && cambiando == false && RevisaI.vel != 0)
        {
            cambia_camaras();
        }
    }
    public void cambia_camaras() {
        cambiando = true;
        activado = !activado;
        cam1.gameObject.SetActive(activado); // cambia las camaras activas
        cam2.gameObject.SetActive(!activado);
        puntero.enabled = activado; // activa desactiva el puntero
        Arma.GetComponentInChildren<GuN>().canfire = activado; ;
        Arma.SetActive(activado); //Activa o desactiva el arma de fuego el arma de fuego
        Arma_Meele.SetActive(!activado);
        FPS_valor.cambio();
        StartCoroutine("espera");
    }
    IEnumerator espera ()
    {
        yield return new WaitForSeconds(tiempo_espera);
        cambiando = false;
    }
}
