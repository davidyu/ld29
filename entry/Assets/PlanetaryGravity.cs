using UnityEngine;
using System.Collections;
using System;

public class PlanetaryGravity : MonoBehaviour {

	public GameObject planet;
	public float gravity = 1f;

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
		float rot = Vector2.Angle( planet.transform.position, transform.position );

		// check cases;
		GameObject player = GameObject.FindWithTag( "Player" );
		if ( gameObject == player ) {
			print( rot );
		}

		transform.eulerAngles = new Vector3( 0, 0, rot );
	}
}
