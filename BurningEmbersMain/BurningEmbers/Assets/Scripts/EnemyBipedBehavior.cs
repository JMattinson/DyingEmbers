using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBipedBehavior : EnemyBase

{

    public IntData bipedMaxHp;
    public IntData playerCurrentDamage;
    // Start is called before the first frame update
    public override void Start()
    {
        currentHp = bipedMaxHp.value;
    }

    public override void Wander()
    {
        throw new System.NotImplementedException();
    }

    public override void Hunt()
    {
        throw new System.NotImplementedException();
    }

    public override void Attack()
    {
        throw new System.NotImplementedException();
    }

    public override void TakeDamage()
    {
        currentHp -= playerCurrentDamage.value;
        print(currentHp);
    }

    public override void Die()
    {
        throw new System.NotImplementedException();
    }
}
