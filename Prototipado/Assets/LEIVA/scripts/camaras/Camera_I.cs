using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_I : MonoBehaviour
{

    public float currentX;
    public float currentY;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Movimiento.Is_playable) {
            currentX += Input.GetAxis("Mouse Y") ;
            currentY += Input.GetAxis("Mouse X");
            arreglo_angulos();
        }
    }
    public virtual void arreglo_angulos() {

    }
}
