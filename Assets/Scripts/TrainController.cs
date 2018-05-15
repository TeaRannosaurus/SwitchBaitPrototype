﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TrainController : MonoBehaviour
{

    public float speed = 25.0f;
    public Transform waypointContainer = null;

    private int _waypointIndex;
    private Transform _currentTarget;
    private NavMeshAgent _agent;
    private List<Transform> _waypoints = new List<Transform>();

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = speed;

        for (int i = 0; i < waypointContainer.childCount; i++)
        {
            _waypoints.Add(waypointContainer.GetChild(i).transform);
        }

        _agent.SetDestination(_waypoints[0].position);
    }

    private void FixedUpdate()
    {
        NavigateToWaypoint();
    }

    public void NavigateToWaypoint()
    {
        if(!_agent.pathPending && !_agent.isStopped)
        {
            if(_agent.remainingDistance <= _agent.stoppingDistance)
            {
                if(!_agent.hasPath || _agent.velocity.sqrMagnitude == 0.5f)
                {
                    _waypointIndex++;
                }
            }
        }
    }

}