using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricPlayerMovementController : MonoBehaviour
{

    public float movementSpeed = 1f;
    IsometricCharacterRenderer isoRenderer;

    public Transform[] waypoints;
    public int waypointIndex = 0;

    Vector2 direction;
    Rigidbody2D rbody;

    public bool moveAllowed = false;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();
       
    }

    private void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
        isoRenderer.SetDirection(new Vector2(0f, -0.5f));

    }

    public void Move()
    {
        waypointIndex++;
        waypointIndex %= waypoints.Length;
        Vector2 nextPos = waypoints[waypointIndex].transform.position;
        rbody.MovePosition(nextPos);
    }

    
}
