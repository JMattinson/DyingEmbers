using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;


public class EnemyBipedBehavior : EnemyBase

{
    [Header("Entity Management")]
    public UnityEvent dieEvent, attackEvent, EnableEvent,RespawnEvent;
    public IntData bipedMaxHp;
    public IntData playerCurrentDamage;
    

    [Header("Navigation")]
    public Transform playerPos,homePos; 
    private NavMeshAgent agent;
    public LayerMask Ground, Player;


    public float sightRange, attackRange;
    public bool PlayerInSight, PlayerInAttack;

    public override void Start()
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

    public override void Regen()
    {
        if (currentHp >= bipedMaxHp.value)
        {
            Respawn();
        }
        currentHp += 1;
    }

    public override void Die()
    {
        dieEvent.Invoke();
    }

    public override void Respawn()
    {
        RespawnEvent.Invoke();
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

    public void OnEnable()
    {
        currentHp = bipedMaxHp.value;
        print(currentHp);
        EnableEvent.Invoke();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);

    }
}
