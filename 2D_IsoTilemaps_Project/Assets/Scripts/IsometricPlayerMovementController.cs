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

    

    private void Move(int incrementValue)
    {
        Debug.Log(incrementValue);
        if (waypointIndex < waypoints.Length - 1)
        {
            rbody.MovePosition(waypoints[waypointIndex].transform.position);
            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }
        } else
        {
            waypointIndex = 0;
            rbody.MovePosition(waypoints[waypointIndex].transform.position);
            
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Move(RandomNumberGenerator());
        }
    }

    int RandomNumberGenerator()
    {
        return UnityEngine.Random.Range(1, 6);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

    }
}
