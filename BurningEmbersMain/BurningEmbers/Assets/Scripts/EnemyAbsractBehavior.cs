using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAbsractBehavior : MonoBehaviour
{
    public abstract void Start();

    public int Health = 10;
    public int damage = 3;

    public  void TakeDamage()
    {
        Health -= 1;
    }
    
    public virtual int DealDamage()
    {
        return damage;
    }

}
