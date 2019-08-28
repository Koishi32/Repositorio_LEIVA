using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEnemy : MeeleGun
{
    // Start is called before the first frame update
    public override void  Start()
    {
        CharaForzeDir = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>();
    }
    public override void get_componenet()
    {
        ataca_meele = this.GetComponentInParent<NPCcontroller>().is_atacking;
    }
}
