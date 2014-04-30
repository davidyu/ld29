using UnityEngine;
using System.Collections;
using System;

public enum PlayerPole { // hmmm...hacky
	SOUTH,
	NORTH
}

[RequireComponent(typeof(PlanetaryGravity))]
public class PlayerController : MonoBehaviour {

	public PlayerPole pole;

	public static float PoleToCharge( PlayerPole p ) {
		return p == PlayerPole.SOUTH ? 1f : -1f;
	}

	public Vector2 moveSpeed = new Vector2( 0.4f, 0.4f );
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if ( Input.GetButtonDown( "South" ) ) {
			pole = PlayerPole.SOUTH;
		}

		if ( Input.GetButtonDown( "North" ) ) {
			pole = PlayerPole.NORTH;
		}
	}

	void FixedUpdate() {
		float h = Input.GetAxis( "Horizontal" );
		var target = GetComponent<PlanetaryGravity>().planet;
		if ( target == null ) {
			return;
		}

		// left and right tangent to surface of planet
		Vector3 diff = transform.position - target.transform.position;
		Vector2 left = (new Vector2( -diff.y, diff.x )).normalized;
		Vector2 right = (new Vector2( diff.y, -diff.x )).normalized;

		if( h < 0 ) {
			// get left vector relative to center
			rigidbody2D.velocity = left * moveSpeed.x;
		}

		if ( h > 0 ) {
			rigidbody2D.velocity = right * moveSpeed.x;
		}

		if ( Math.Abs( h ) < 0.05 ) {
			rigidbody2D.velocity = new Vector2( 0, 0 );
		}
	}
}
