using UnityEngine;
using System.Collections;
using System;

public class PlanetaryGravity : MonoBehaviour {

	public GameObject planet;
	public float gravity = 1f;
	public bool rotate = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate() {
		// get vector from me to center of planet
		Vector3 diff = planet.transform.position - transform.position;
		Vector2 dir = new Vector2( diff.x, diff.y );
		// apply force towards center of planet
		rigidbody2D.AddForce( dir * gravity );

		// change rotation transform manually (this way it's less shaky)
		Vector2 rot = -( dir.normalized );
		double rad = Math.Atan2( -rot.y, rot.x );

		GameObject player = GameObject.FindWithTag( "Player" );
		if ( gameObject == player )
			print( MathHelper.ToDegrees( rad ) + 90 );

		if ( rotate )
			transform.eulerAngles = new Vector3( 0, 0, 90 - (float) MathHelper.ToDegrees( rad ) );
	}
}
