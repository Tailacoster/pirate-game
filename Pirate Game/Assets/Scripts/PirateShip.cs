using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PirateShip : MonoBehaviour
{
    [Tooltip("In unity units per second")] [SerializeField] protected float accelerationSpeed = 10f;
    [Tooltip("In unity units per second")] [SerializeField] protected float decelerationSpeed = 1f;
    [Tooltip("In unity units per second")][SerializeField] protected float maxSpeed = 20f;
    [SerializeField] protected float rotationSpeed = 2f;

    protected float currentSpeed = 0f;
    protected bool anchorDropped = false;

    Rigidbody2D rigidBody;

    protected virtual void Start()
	{
        rigidBody = GetComponent<Rigidbody2D>();
    }
	
	protected virtual void Update()
	{
		
	}

    /// <summary>
    /// Moves the ship (defaultly according to AI conditionals)
    /// </summary>
    protected virtual void Move()
    {

    }

    /// <summary>
    /// Calculates the speed the ship will be moving at while it is accelerating and
    /// sets the currentSpeed accordingly
    /// </summary>
    protected void CalculateAcceleratingSpeed()
    {
        currentSpeed += accelerationSpeed * Time.deltaTime;
        if (currentSpeed > maxSpeed)
        {
            currentSpeed = maxSpeed;
        }
    }

    /// <summary>
    /// Calculates the speed the ship will be moving at while it is decelerating and
    /// sets the currentSpeed accordingly
    /// </summary>
    /// <param name="scaleFactor">Factor to scale the rate of deceleration, 1 being normal speed, 2 double, 0.5 half</param>
    protected void CalculateDecelerationSpeed(float scaleFactor)
    {
        currentSpeed -= decelerationSpeed * Time.deltaTime * scaleFactor;
    }
}