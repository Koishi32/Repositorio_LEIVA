using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FirstPersonCamera : MonoBehaviour
{
    [Header("Camera_Angle")]
    public float ANGLE_MIN;
    public float ANGLE_MAX;
    public float rotationX_speed; //velocidad del Giro de la camara
    float currentX;
    float currentY;

    private void Update()
    {
        currentX += Input.GetAxis("Mouse Y");
        currentY += Input.GetAxis("Mouse X");
        currentX = Mathf.Clamp(currentX, ANGLE_MIN, ANGLE_MAX); //Limita angulos en los que sube y baja cabeza
        
    }
    private void LateUpdate() { // Rotea junto con el Mouse
     Quaternion rotation = Quaternion.Euler((-currentX), (currentY), transform.rotation.z);
     this.transform.rotation = rotation;
    }
}
