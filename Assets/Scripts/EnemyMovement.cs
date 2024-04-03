using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform currentWavepoint;
    private int wavepointIndex = 0;
    private Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();
        currentWavepoint = Waypoints.waypoints[wavepointIndex];
    }

    void Update()
    {
        Vector3 goTo = currentWavepoint.position - transform.position;
        transform.Translate(goTo.normalized * enemy.speed * Time.deltaTime, Space.World);
        if(goTo.magnitude <= 0.3f)
        {
            GetNextWaypoint();
        }
        enemy.speed = enemy.startSpeed;
    }

    void GetNextWaypoint()
    {
        if(wavepointIndex >= Waypoints.waypoints.Length-1)
        {
            EndPath();
            return; 
        }

        wavepointIndex++;
        currentWavepoint = Waypoints.waypoints[wavepointIndex];
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
}
