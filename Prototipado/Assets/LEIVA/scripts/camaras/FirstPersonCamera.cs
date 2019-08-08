using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityStandardAssets.CrossPlatformInput;
public class FirstPersonCamera : MonoBehaviour
{
    [Header("Camera_Angle")]
    public float ANGLE_MIN;
    public float ANGLE_MAX;
    float currentX;
    float currentY;

    private void Update()
    {
        currentX += CrossPlatformInputManager.GetAxis("Mouse Y");
        currentY += CrossPlatformInputManager.GetAxis("Mouse X");
        currentX = Mathf.Clamp(currentX, ANGLE_MIN, ANGLE_MAX);
    }
    private void FixedUpdate() {
        Quaternion rotation = Quaternion.Euler(-currentX,currentY,0); //Rotacion depende del Mouse
        this.transform.rotation = rotation;
    }
}
