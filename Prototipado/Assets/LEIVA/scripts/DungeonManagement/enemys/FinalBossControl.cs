using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossControl : NPCcontroller
{
    public override void elegir_atack()
    { // se pueden meter mas cases para mas animaciones
        opcion = Mathf.RoundToInt(Random.Range(0,4));
        print(opcion);
        switch (opcion)
        {
            case 0:
                mis_animaciones.SetBool("Atack1", true);
                break;
            case 1:
                mis_animaciones.SetBool("Atack2", true);
                break;
            case 2:
                mis_animaciones.SetBool("Atack3", true);
                break;
            case 3:
                mis_animaciones.SetBool("Atack4", true);
                break;
        }
    }
    public override void revert()
    { //Acaba la animacion de ataque 
        switch (opcion) //esta asi para permitir mas ataque en el futuro
        {
            case 0:
                mis_animaciones.SetBool("Atack1", false);
                break;
            case 1:
                mis_animaciones.SetBool("Atack2", false);
                break;
            case 2:
                mis_animaciones.SetBool("Atack3", false);
                break;
            case 3:
                mis_animaciones.SetBool("Atack4", false);
                break;
        }
        canHarm = false;
        StartCoroutine("espera");//Espera antes de que de otro golpe
    }
}
