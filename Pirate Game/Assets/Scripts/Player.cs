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

        Anchor();
    }

    protected override void Move()
    {
        if (Input.GetKey(KeyCode.W) && !anchorDropped) // may change to GetAxis and Anchor functionality
        {
            CalculateAcceleratingSpeed();
        }
        else
        {
            if (!anchorDropped)
            {
                CalculateDecelerationSpeed(1f);
            }
            else if (anchorDropped)
            {
                CalculateDecelerationSpeed(3f);
            }
        }

        transform.Translate(Vector2.down * currentSpeed * Time.deltaTime);
    }

    protected override void Rotate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
        }
    }

    // Drops the anchor - currently slows down deceleration speed by 3 (hard baked into code), will change later 
    // unless this functionality is maintained
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