using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Se_danmagea : Damageable
{
    public MeeleGun Arma_cuerpo;
    public GuN Arma_Distancia;
    public float plus_Arma_cuerpo;
    public float plus_Distancia;
    public float plus_life;
    public string A_modificar;
    public float speed_rot;
    public override void Die()
    {
        switch (A_modificar)
        {
            case "Daño_Meele":
                Arma_cuerpo.damage += plus_Arma_cuerpo;
                break;
            case "Daño_Distancia":
                Arma_Distancia.damage += plus_Distancia;
                break;
            case "Vida":
                GameObject.FindGameObjectWithTag("Player").GetComponent<Movimiento>().my_life += plus_life;
                break;
        }
        Destroy(this.gameObject);
    }
    private void Update()
    {
        transform.Rotate(Vector3.up, speed_rot * Time.deltaTime,Space.World);
    }
}
