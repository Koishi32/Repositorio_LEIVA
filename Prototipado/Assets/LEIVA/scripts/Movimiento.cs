using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public Animator animacion_FPS;
    public bool is_FPS;
    public Rigidbody my_rigid;
    public float vel;
    // Start is called before the first frame update
    void Start()
    {
        is_FPS = true;
        my_rigid = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
   void Update()
    {
        se_mueve();
        salta();
    }
    public void salta() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            my_rigid.AddForce(Vector3.up, ForceMode.Impulse)    ;
        }
    }
    public void se_mueve() {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (horizontal != 0 || vertical != 0)
        {
           // animacion_FPS.SetBool("Is_moving", true);
            my_rigid.velocity = new Vector3(horizontal, my_rigid.velocity.y, vertical) * vel;
        }
        else
        {
           // animacion_FPS.SetBool("Is_moving", false);
        }
    }

    public void cambio () { //Booleanos para animaciones
        is_FPS = !is_FPS;
        if (is_FPS == true)
        {
            animacion_FPS.SetBool("Is_3RD", false);
            animacion_FPS.SetBool("Is_FPS", true); // Activa animacion de apuntar
        }
        else
        {
            animacion_FPS.SetBool("Is_3RD", true); // Activa animacion de correr normal
            animacion_FPS.SetBool("Is_FPS", false);
        }

    }


}
