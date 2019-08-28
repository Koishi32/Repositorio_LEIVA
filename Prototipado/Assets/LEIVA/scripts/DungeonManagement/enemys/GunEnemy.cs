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

    // Update is called once per frame
    public override void Update()
    {
        ataca_meele = this.GetComponentInParent<NPCcontroller>().is_atacking;
    }
    

}
