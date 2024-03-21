using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemySpeed = 10f;
    private Transform currentWavepoint;
    private int wavepointIndex = 0;

    void Start()
    {
        currentWavepoint = Waypoints.waypoints[wavepointIndex];
    }

    void Update()
    {
        Vector3 goTo = currentWavepoint.position - transform.position;
        transform.Translate(goTo.normalized * enemySpeed * Time.deltaTime, Space.World);
        if(goTo.magnitude <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if(wavepointIndex >= Waypoints.waypoints.Length-1)
        {
            Destroy(gameObject);
            return; 
        }

        wavepointIndex++;
        currentWavepoint = Waypoints.waypoints[wavepointIndex];
    }
}
