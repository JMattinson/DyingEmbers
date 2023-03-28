using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;


public class EnemyBipedBehavior : EnemyBase

{
    [Header("Entity Management")]
    public UnityEvent dieEvent, attackEvent,damageEvent, EnableEvent,RespawnEvent;
    public IntData bipedMaxHp, EnCurrentHp;
    public IntData playerCurrentDamage;
    

    [Header("Navigation")]
    public Transform playerPos; 
    private NavMeshAgent agent;
    public LayerMask Ground, Player;


    public float sightRange, attackRange;
    public bool PlayerInSight, PlayerInAttack;
    

    public override void Start()
    {

        EnCurrentHp.value = bipedMaxHp.value;
        agent = GetComponent<NavMeshAgent>();
        playerPos = GameObject.Find("Player").transform;
        PlayerInSight = true;
        
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
        EnCurrentHp.value -= playerCurrentDamage.value;
        damageEvent.Invoke();
        if (EnCurrentHp.value <= 0)
        {
            Die();
        }
    }

    public override void Regen()
    {
        if (EnCurrentHp.value >= bipedMaxHp.value)
        {
            Respawn();
        }
        EnCurrentHp.value += 1;
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
        
        PlayerInAttack = Physics.CheckSphere(transform.position, attackRange,Player);
        if (PlayerInSight) Hunt();
        //if (PlayerInAttack) Attack();

    }

    public void OnEnable()
    {
        EnCurrentHp.value = bipedMaxHp.value;
        print(EnCurrentHp);
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
