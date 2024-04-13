using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Human : MonoBehaviour
{
    protected GameObject targetPlace;
    protected NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        if (targetPlace != null )
        {
            Move(targetPlace.transform.position);
        }
    }

    public void SetTargetPlace(GameObject targetPlace)
    {
        this.targetPlace = targetPlace;
    }

    public void Move(Vector2 vector2)
    {
        agent.SetDestination(vector2);
    }
}
