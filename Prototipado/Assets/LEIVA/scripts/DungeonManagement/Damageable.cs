using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public float vida=50;
    public void takeDamage(float amount)
    {
        vida -= amount;
        if (vida <= 0f)
        {
            Die();
        }
    }
  
    void Die() => Destroy(gameObject);


}
