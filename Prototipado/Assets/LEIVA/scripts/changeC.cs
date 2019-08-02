using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeC : MonoBehaviour
{
   public  Camera cam1;
   public Camera cam2;
    public GameObject Arma;
    public ControlInput FPS_valor;
    bool activado;
    private void Start()
    {
        cam1.enabled = true;
        cam2.enabled = false;
        activado = true;
        Arma.SetActive(activado);
    }
    // Este efecto se puede lograr mas elegantemente con Cine machine , creo
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            cam1.enabled = !cam1.enabled; // Voltea los activos de la camara (se cambia de camara)
            cam2.enabled = !cam2.enabled;
            activado = ! activado;
            Arma.SetActive(activado); //Activa el arma de fuego
            FPS_valor.cambio();
        }
    }
}
