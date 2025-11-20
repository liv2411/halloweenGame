using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public Transform player;
    public float patrolSpeed = 2f;
    public float chaseSpeed = 4f;
    public float detectionDistance = 8f;
    public float loseSightDistance = 10f;
    public float patrolRadius = 10f;

    private Vector3 patrolTarget;
    private bool chasing = false;

    void Start()
    {
        SetNewPatrolTarget();
    }

    void Update()
    {
        Vector3 directionToPlayer = player.position - transform.position;
        float distanceToPlayer = directionToPlayer.magnitude;

        // Raycast from NPC to Player to simulate vision
        Ray ray = new Ray(transform.position + Vector3.up * 0.5f, directionToPlayer.normalized);
        RaycastHit hit;

        bool playerInSight = false;

        if (Physics.Raycast(ray, out hit, detectionDistance))
        {
            if (hit.transform == player)
            {
                playerInSight = true;
            }
        }

        // Debug ray in Scene view
        Debug.DrawRay(ray.origin, ray.direction * detectionDistance, Color.red);

        if (chasing)
        {
            if (!playerInSight || distanceToPlayer > loseSightDistance)
            {
                chasing = false;
                SetNewPatrolTarget();
            }
            else
            {
                ChasePlayer(directionToPlayer);
            }
        }
        else
        {
            if (playerInSight)
            {
                chasing = true;
            }
            else
            {
                Patrol();
            }
        }
    }

    void Patrol()
    {
        Vector3 dir = patrolTarget - transform.position;

        if (dir.magnitude < 1f)
        {
            SetNewPatrolTarget();
        }
        else
        {
            transform.position += dir.normalized * patrolSpeed * Time.deltaTime;
        }
    }

    void ChasePlayer(Vector3 direction)
    {
        transform.position += direction.normalized * chaseSpeed * Time.deltaTime;
    }

    void SetNewPatrolTarget()
    {
        float x = Random.Range(-patrolRadius, patrolRadius);
        float z = Random.Range(-patrolRadius, patrolRadius);
        patrolTarget = new Vector3(x, 0.5f, z);
    }
}

