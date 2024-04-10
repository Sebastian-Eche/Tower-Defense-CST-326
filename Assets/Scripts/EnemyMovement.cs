using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    public GameObject endPoint;
    // private Transform currentWavepoint;
    // private int wavepointIndex = 0;
    private Enemy enemy;
    private NavMeshAgent agent;


    void Start()
    {
        enemy = GetComponent<Enemy>();
        agent = GetComponent<NavMeshAgent>();
        // currentWavepoint = Waypoints.waypoints[wavepointIndex];
    }

    void Update()
    {
        agent.destination = endPoint.transform.position;
        if(transform.position.x == endPoint.transform.position.x)
        {
           EndPath(); 
        }
        // Vector3 goTo = currentWavepoint.position - transform.position;
        // transform.Translate(goTo.normalized * enemy.speed * Time.deltaTime, Space.World);
        // if(goTo.magnitude <= 0.3f)
        // {
        //     GetNextWaypoint();
        // }
        // enemy.speed = enemy.startSpeed;
    }

    // void GetNextWaypoint()
    // {
    //     if(wavepointIndex >= Waypoints.waypoints.Length-1)
    //     {
    //         EndPath();
    //         return; 
    //     }

    //     wavepointIndex++;
    //     currentWavepoint = Waypoints.waypoints[wavepointIndex];
    // }

    void EndPath()
    {
        PlayerStats.Lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}
