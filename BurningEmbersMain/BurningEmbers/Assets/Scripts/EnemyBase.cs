using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{

    public int currentHp;
    
    public abstract void Awake();

    public virtual void Wander()
    {
        print("wandering");
    }

    public abstract void SearchWalkPoint();
    
    public abstract void Hunt();

    public abstract void Attack();
    
    public abstract void TakeDamage();

    
    public abstract void Die();


}
