using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PirateShip
{
	protected override void Start()
	{
        base.Start();
	}
	
	protected override void Update()
    {
        base.Update();

        Move();
        Rotate();
        Anchor();

        if (Input.GetKeyDown(KeyCode.S))
        {
            // drop anchor
        }
    }

    /// <summary>
    /// Moves the player ship
    /// </summary>
    protected override void Move()
    {
        if (Input.GetKey(KeyCode.W) && !anchorDropped)
        {
            CalculateAcceleratingSpeed();
        }
        else
        {
            if (currentSpeed > 0 && !anchorDropped)
            {
                CalculateDecelerationSpeed(1f);
            }
            else if (currentSpeed > 0 && anchorDropped)
            {
                CalculateDecelerationSpeed(3f);
            }
            else
            {
                currentSpeed = 0;
            }
        }
        transform.Translate(Vector2.down * currentSpeed * Time.deltaTime);
        Debug.Log(currentSpeed);
    }

    private void Rotate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, rotationSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, -rotationSpeed);
        }
    }

    private void Anchor()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (anchorDropped)
            {
                anchorDropped = false;
            }
            else
            {
                anchorDropped = true;
            }
        }
    }
}