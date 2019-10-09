using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PirateShip : MonoBehaviour
{
    [Tooltip("In unity units per second")] [SerializeField] protected float accelerationSpeed = 10f;
    [Tooltip("In unity units per second")] [SerializeField] protected float decelerationSpeed = 1f;
    [Tooltip("In unity units per second")][SerializeField] protected float maxSpeed = 20f;
    [Tooltip("In unity units per second, negative meaning moving backward")] [SerializeField] protected float minSpeed = 0f;
    [Tooltip("In degrees per second, 360 being one full turn")][SerializeField] protected float rotationSpeed = 90f;

    [SerializeField] protected float maxHealth = 100f;
    protected float currentHealth;
    protected float healthToPercentileFactor; // the factor health needs to be multiplied by in order to change it to percentile out of 100

    [SerializeField] protected Sprite[] shipSprites = new Sprite[4];
    [Tooltip("The percentages out of 100 at which the different HP sprites will trigger. Going above or below each amount will trigger the appropriate sprite within the damage sequence.")]
    [SerializeField] protected int[] spritePercentages = new int[] { 80, 40, 0 };
    protected int currentSpriteCount = 0;

    protected float currentSpeed = 0f;
    protected bool anchorDropped = false;

    Rigidbody2D rigidBody;
    SpriteRenderer spriteRenderer;

    protected virtual void Start()
	{
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        currentHealth = maxHealth;
        healthToPercentileFactor = maxHealth / 100;
    }
	
	protected virtual void Update()
	{
        Move();
        Rotate();

        //
        CheckAndUpdateSprite(); // MOVE THIS to whenever the player takes damage or gains health
        //

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentHealth += 5;
            Debug.Log(currentHealth);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentHealth -= 5;
            Debug.Log(currentHealth);
        }
	}

    /// <summary>
    /// Moves the ship (defaultly according to AI conditionals)
    /// </summary>
    protected virtual void Move()
    {
        // AI movement code, player script overwrites this
    }

    /// <summary>
    /// Rotates the ship (defaultly according to AI conditionals)
    /// </summary>
    protected virtual void Rotate()
    {
        // AI rotation code, player script overwrites this
    }

    /// <summary>
    /// Calculates the speed the ship will be moving at while it is accelerating and
    /// sets the currentSpeed accordingly
    /// </summary>
    protected void CalculateAcceleratingSpeed()
    {
        if (currentSpeed < maxSpeed)
        {
            currentSpeed += accelerationSpeed * Time.deltaTime;
        }
        else
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
        if (currentSpeed > minSpeed)
        {
            currentSpeed -= decelerationSpeed * Time.deltaTime * scaleFactor;
        }
        else
        {
            currentSpeed = minSpeed;
        }
    }

    /// <summary>
    /// Changes the sprite of the ship to a different level of damage, specified by the amounts passed in.
    /// </summary>
    /// <param name="upOrDown">The direction to change the sprite in. 1 being gaining health and -1 being losing health.</param>
    /// <param name="numOfSpritesToChange">How many sprites to move through (usually only 1). Always put positive number.</param>
    protected void UpdateShipSpriteByAmount(int upOrDown, int numOfSpritesToChange)
    {
        currentSpriteCount -= upOrDown * numOfSpritesToChange;
        if (currentSpriteCount >= 0 && currentSpriteCount < shipSprites.Length) // stay in bounds of array
        {
            spriteRenderer.sprite = shipSprites[currentSpriteCount];
        }
        else // method called out of ship sprite array range, set sprite to the correct end of array
        {
            if (currentSpriteCount < 0)
            {
                currentSpriteCount = 0;
                spriteRenderer.sprite = shipSprites[currentSpriteCount];
            }
            else if (currentSpriteCount >= shipSprites.Length)
            {
                currentSpriteCount = shipSprites.Length - 1;
                spriteRenderer.sprite = shipSprites[currentSpriteCount];
            }
        }
    }
    
    /// <summary>
    /// Checks if the sprite needs to be updated based on the current health and changes it.
    /// </summary>
    protected void CheckAndUpdateSprite()
    {
        float currentHealthInPercentile = currentHealth / healthToPercentileFactor;

        if (currentHealthInPercentile > spritePercentages[0])
        {
            spriteRenderer.sprite = shipSprites[0];
        }
        else if (currentHealthInPercentile > spritePercentages[1])
        {
            spriteRenderer.sprite = shipSprites[1];
        }
        else if (currentHealthInPercentile > spritePercentages[2])
        {
            spriteRenderer.sprite = shipSprites[2];
        }
        else
        {
            spriteRenderer.sprite = shipSprites[3];
        }
    }
}