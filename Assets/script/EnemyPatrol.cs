using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float patrolSpeed = 2f;
    public float chaseSpeed = 4f;
    public float chaseDistance = 5f;
    public float attackRange = 1f; 
    public int attackDamage = 1; 

    private int currentPoint = 0;
    private Transform player;
    private Rigidbody2D rb;
    private Phealth phealth;

    public float attackCooldown = 2f; 
    private float nextAttackTime;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        phealth = player.GetComponent<Phealth>();

        nextAttackTime = Time.time;
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < chaseDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);

            if (distanceToPlayer < attackRange)
            {
                AttackPlayer();
                nextAttackTime = Time.time + attackCooldown;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPoint].position, patrolSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, patrolPoints[currentPoint].position) < 0.1f)
            {
                currentPoint = (currentPoint + 1) % patrolPoints.Length;
                Flip();
            }
        }
    }

    private void AttackPlayer()
    {
        phealth.TakeDamage(attackDamage);
    }

    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}





