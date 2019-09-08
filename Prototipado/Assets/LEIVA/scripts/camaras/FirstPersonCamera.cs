using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FirstPersonCamera : Camera_I
{
    [Header("Camera_Angle")]
    public float ANGLE_MIN_FPS;
    public float ANGLE_MAX_FPS;
    public float delts;
    //[Range(0f,1f)]
    //public float clamp;
    // public float rotationX_speed; //velocidad del Giro de la camara
    private void LateUpdate() { // Rotea junto con el Mouse
                                /*Quaternion rotationMOD = Quaternion.Euler((-currentX), (currentY), transform.rotation.z);
                                Quaternion newRot = Quaternion.Lerp(this.transform.rotation, rotationMOD, 0);
                                rotationMOD = Quaternion.Euler(transform.rotation.x, (currentY),transform.rotation.z);
                                    this.transform.rotation= Quaternion.Lerp(newRot, rotationMOD, 0); ;*/

        Vector3 rotationMOD =new Vector3((-currentX), (currentY),0);
 
        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, Quaternion.Euler(rotationMOD), delts);
    } 
    public override void arreglo_angulos()
    {
        currentX = Mathf.Clamp(currentX, ANGLE_MIN_FPS, ANGLE_MAX_FPS); //Limita angulos en los que sube y baja cabeza
    }
}
