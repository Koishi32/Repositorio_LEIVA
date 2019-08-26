using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ThirPersonCamera : Camera_I
{
    public float ANGLE_MIN;
    public float ANGLE_MAX;
    //Variables para restringir camara
    [Header("Camera_Angle")]
    public float offset; // Offset en X para alinearse con la FPS camera
    public Transform Mirar_jugador; //localizacion del jugador
    public Transform camTransform; //transform de esta camara
    public float distancia; // Que tanto se aleja
   
    // Start is called before the first frame update
    void Start()
    {
        camTransform = transform;
    }
    private void LateUpdate()
    {
        //Offset de la camra con respecto al jugador
        
        Vector3 dir = new Vector3(0, 0, -distancia); // que tanto se aleja del jugador
        Quaternion rotation = Quaternion.Euler(-currentX + offset, currentY , 0); //Rotacion depende del Mouse
        camTransform.position = Mirar_jugador.position + rotation * dir;
        camTransform.LookAt(Mirar_jugador.position);    // Asegura que la rotacion sea  alrededor de ljugador
    }
    public override void arreglo_angulos() {
        currentX = Mathf.Clamp(currentX, ANGLE_MIN, ANGLE_MAX); //Limita angulos en los que sube y baja cabeza
    }
}
