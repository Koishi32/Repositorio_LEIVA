using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Manager : MonoBehaviour
{
    public MeeleGun meeleGun;
    public GuN Gun_dist;
    public Movimiento vida_player;
    public Text miVidaUI;
    public Text daño_armaGunUI;
    public Text daño_armaMeeleUI;
    public GameObject icono;
    public GameObject icono2;
    //bool shouldBeLock;
    // Start is called before the first frame update
    public void UI_actualiza() {
        daño_armaGunUI.text = "daño Meele: " + meeleGun.get_Damage();
        daño_armaMeeleUI.text = "daño Arma: " + Gun_dist.get_Damage();
        miVidaUI.text = "Vida: " + vida_player.my_life;
        if (Movimiento.is_FPS)
        {
            icono.SetActive(false);
            icono2.SetActive(true);
        }
        else {
            icono2.SetActive(false);
            icono.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        UI_actualiza();
        LockMouse();
    }
    public void LockMouse()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (Input.GetButtonDown("Fire1")) {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

    }
   /* private void Start()
    {
        shouldBeLock = true;
    }*/
}
