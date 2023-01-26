using UnityEngine.Events;


public class EnemyBipedBehavior : EnemyBase

{
    public UnityEvent DieEvent;
    public IntData bipedMaxHp;
    public IntData playerCurrentDamage;

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
        if (currentHp <= 0)
        {
            Die();
        }
    }

    public override void Die()
    {
        DieEvent.Invoke();
    }
}
