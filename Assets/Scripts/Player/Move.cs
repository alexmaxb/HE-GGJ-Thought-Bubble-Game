using UnityEngine;
using System.Collections;
using System;
using Unity.VisualScripting;


public enum Directions
{
	Up,
	Right,
	Down,
	Left,
}

public enum KeyGroups
{
	ArrowKeys,
	WASD,
}


[AddComponentMenu("Playground/Movement/Move With Arrows")]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Move : MonoBehaviour
{

	[HideInInspector]
	public new Rigidbody2D rigidbody2D;

	public SpriteRenderer spriteRenderer;

	void Awake ()
	{
		rigidbody2D = GetComponent<Rigidbody2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		cachedDirection = Vector2.zero;
	}

	// [Header("Input keys")]
	// public KeyGroups typeOfControl = KeyGroups.ArrowKeys;

	[Header("Movement")]
	[Tooltip("Speed of movement")]
	public float speed = 5f;

	[Header("Orientation")]
	public bool orientToDirection = false;
	// The direction that will face the player
	public Directions lookAxis = Directions.Up;

	private Vector2 movement;
	public Vector2 cachedDirection {get; private set;}
	private float moveHorizontal;
	private float moveVertical;



	// Update gets called every frame
	void Update ()
	{	
		moveHorizontal = Input.GetAxis("Horizontal");
		moveVertical = Input.GetAxis("Vertical");
			
		movement = new Vector2(moveHorizontal, moveVertical);


		//rotate the GameObject towards the direction of movement
		//the axis to look can be decided with the "axis" variable
		if(orientToDirection)
		{
			if(movement.sqrMagnitude >= 0.01f)
			{
				cachedDirection = movement.normalized;
			}
			// SetAxisTowards(lookAxis, transform, cachedDirection);

			if(Math.Abs(movement.x) >= 0.01f)
				spriteRenderer.flipX = movement.x > 0;
		}
	}



	// FixedUpdate is called every frame when the physics are calculated
	void FixedUpdate ()
	{
		// Apply the force to the Rigidbody2d
		rigidbody2D.AddForce(movement * speed * 10f);
	}

	private static void SetAxisTowards(Directions axis, Transform t, Vector2 direction)
	{
		switch(axis)
		{
			case Directions.Up:
				t.up = direction;
				break;
			case Directions.Down:
				t.up = -direction;
				break;
			case Directions.Right:
				t.right = direction;
				break;
			case Directions.Left:
				t.right = -direction;
				break;
		}
	}
}