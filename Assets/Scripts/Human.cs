using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Human : MonoBehaviour
{
    protected PointOfInterest targetPlace;
    protected NavMeshAgent agent;
    private readonly float baseSpeed = 65;

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

    protected void FixedUpdate()
    {
        agent.speed = baseSpeed * Time.fixedDeltaTime / TimeManager.Scale();
    }

    public void SetTargetPlace(PointOfInterest targetPlace)
    {
        this.targetPlace = targetPlace;
    }

    public void Move(Vector2 vector2)
    {
        agent.SetDestination(vector2);
    }
}
