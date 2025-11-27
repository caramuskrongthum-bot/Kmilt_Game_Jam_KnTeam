using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HorseKillerAi : MonoBehaviour
{
    [Header("Patrol Settings")]
    public Transform[] patrolPoints;
    public float waitTime = 2f;

    [Header("Chase Settings")]
    public float detectionRange = 10f;
    public float losePlayerRange = 15f;

    [Header("Attack Settings")]
    public float attackRange = 2f;
    public float attackCooldown = 1.5f;

    private NavMeshAgent agent;
    public Animator animator;
    private int currentPoint = 0;
    private float lastAttackTime = 0f;

    public enum State { Patrol, Chase, Attack }
    public State currentState = State.Patrol;

    private bool isWaiting = false;
    private float waitCounter = 0f;

    public GameObject PlayerModel;

    public bool ChaseingPlayer;
    public bool HaveToChaseingPlayer;

    public GameObject BGM;

    public bool goingToA = false;

    public void SetCharacterPlayer(GameObject Player_)
    {
        PlayerModel = Player_;
    }

    public void SetGoToA(bool GoToA_)
    {
        goingToA = GoToA_;
    }

    public void GoToPositionA(Transform P)
    {
        goingToA = true;
        currentState = State.Patrol;
        agent.isStopped = false;
        agent.SetDestination(P.position);
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (patrolPoints.Length > 0)
            agent.SetDestination(patrolPoints[0].position);
    }

    void Update()
    {
        if (BGM != null)
            BGM.SetActive(ChaseingPlayer);

        if (PlayerModel != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, PlayerModel.transform.position);

            float speed = agent.velocity.magnitude;
            animator.SetFloat("Speed", speed);

            if (distanceToPlayer <= attackRange)
            {
                currentState = State.Attack;
                AttackPlayer();
            }
            else if (distanceToPlayer <= detectionRange)
            {
                currentState = State.Chase;
                ChasePlayer();
            }
            else if (distanceToPlayer > losePlayerRange && currentState != State.Patrol)
            {
                currentState = State.Patrol;
                ReturnToPatrol();
            }

            if (!goingToA && currentState == State.Patrol && patrolPoints.Length > 0)
            {
                Patrol();
            }
        }

        if (goingToA)
        {
            if (!agent.pathPending && agent.remainingDistance <= 0.5f)
            {
                goingToA = false;
                ReturnToPatrol();
            }
        }
    }
    public void Patrol()
    {
        agent.isStopped = false;

        if (isWaiting)
        {
            waitCounter += Time.deltaTime;
            if (waitCounter >= waitTime)
            {
                isWaiting = false;
                waitCounter = 0f;
                MoveToNextPoint();
            }
            return;
        }

        if (!agent.pathPending && agent.remainingDistance <= 0.5f)
        {
            isWaiting = true;
        }
    }

    public void MoveToNextPoint()
    {
        currentPoint = (currentPoint + 1) % patrolPoints.Length;
        agent.SetDestination(patrolPoints[currentPoint].position);
    }

    public void ChasePlayer()
    {
        ChaseingPlayer = true;
        agent.isStopped = false;
        isWaiting = false;

        if (PlayerModel != null)
        {
            agent.SetDestination(PlayerModel.transform.position);
        }
    }
    public void AttackPlayer()
    {
        agent.isStopped = true;

        if (PlayerModel != null)
        {
            Vector3 direction = (PlayerModel.transform.position - transform.position).normalized;
            direction.y = 0;

            if (direction != Vector3.zero)
            {
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
            }

            if (Time.time >= lastAttackTime + attackCooldown)
            {
                animator.Play("Attack");
                lastAttackTime = Time.time;
            }
        }
    }

    public void ReturnToPatrol()
    {
        if (!HaveToChaseingPlayer)
        {
            ChaseingPlayer = false;
            agent.isStopped = false;

            if (patrolPoints.Length > 0)
            {
                int closestPoint = GetClosestPatrolPoint();
                currentPoint = closestPoint;
                agent.SetDestination(patrolPoints[currentPoint].position);
            }
        }
    }

    int GetClosestPatrolPoint()
    {
        float minDistance = Mathf.Infinity;
        int closestIndex = 0;

        for (int i = 0; i < patrolPoints.Length; i++)
        {
            float distance = Vector3.Distance(transform.position, patrolPoints[i].position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestIndex = i;
            }
        }

        return closestIndex;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, losePlayerRange);

        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
