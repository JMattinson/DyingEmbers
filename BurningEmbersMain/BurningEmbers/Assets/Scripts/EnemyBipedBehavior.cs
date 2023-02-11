using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;


public class EnemyBipedBehavior : EnemyBase

{
    [Header("Entity Management")]
    public UnityEvent dieEvent, attackEvent;
    public IntData bipedMaxHp;
    public IntData playerCurrentDamage;
    

    [Header("Navigation")]
    public Transform playerPos,homePos; 
    private NavMeshAgent agent;
    public LayerMask Ground, Player;


    public float sightRange, attackRange;
    public bool PlayerInSight, PlayerInAttack;

    public override void Awake()
    {
        
        currentHp = bipedMaxHp.value;
        agent = GetComponent<NavMeshAgent>();
        playerPos = GameObject.Find("Player").transform;
        agent.SetDestination(homePos.position);
        PlayerInSight = false; 
    }

    public override void Wander()
    {
        
    }

    public override void SearchWalkPoint()
    {
    }

    public override void Hunt()
    {
        agent.SetDestination(playerPos.position);
        print(agent.destination);
    }

    public override void Attack()
    {
        agent.SetDestination(transform.position);
        attackEvent.Invoke();
    }

    public override void TakeDamage()
    {
        PlayerInSight = true;
        currentHp -= playerCurrentDamage.value;
        print(currentHp);
        if (currentHp <= 0)
        {
            Die();
        }
    }
    public override void Die()
    {
        dieEvent.Invoke();
    }
    public void Think()
    {
        PlayerInSight = Physics.CheckSphere(transform.position, sightRange,Player);
        if (PlayerInSight) Hunt();
        //if (PlayerInAttack) Attack();
        else
        {
            agent.SetDestination(homePos.position);
            PlayerInSight = false;
        }
    
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);

    }
}
