using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NewWaypointPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    [Tooltip("укажи точку куда птица полетит сначала")]
    public Transform ToStart;
    [Tooltip("укажи масив для патруля")]
    public Transform[] waypoints;

    int m_CurrentWaypointIndex;

    void Start ()
    {
        //navMeshAgent.();  
     navMeshAgent.SetDestination(ToStart.position);
        //navMeshAgent.SetDestination (waypoints[0].position);
    }

    void Update ()
    {
       
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination (waypoints[m_CurrentWaypointIndex].position);
        }
    }
}
