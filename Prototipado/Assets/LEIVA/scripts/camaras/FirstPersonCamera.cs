using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FirstPersonCamera : Camera_I
{
    [Header("Camera_Angle")]
    public float ANGLE_MIN_FPS;
    public float ANGLE_MAX_FPS;
    //[Range(0f,1f)]
    //public float clamp;
   // public float rotationX_speed; //velocidad del Giro de la camara
   
    private void LateUpdate() { // Rotea junto con el Mouse
    Quaternion rotation = Quaternion.Euler((-currentX), (currentY), transform.rotation.z);
        //this.transform.rotation = rotation;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation,0);
        
    } 
    public override void arreglo_angulos()
    {
        currentX = Mathf.Clamp(currentX, ANGLE_MIN_FPS, ANGLE_MAX_FPS); //Limita angulos en los que sube y baja cabeza
    }
}
