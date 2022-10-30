using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshBehavior : MonoBehaviour
{
    public Transform playerT;
    
    public NavMeshAgent agent;

    private void Update()
    {
        agent.SetDestination(playerT.position);
    }
}
