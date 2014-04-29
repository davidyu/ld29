using UnityEngine;
using System.Collections;
using System;

public class BomberController : MonoBehaviour {

	public GameObject center;
	public float orbitRadius;
	public float rotation; // in radians
	public float drot; // rotation velocity in radians
	public float bomberMagnetMultiplier = 5f; // bomber's magnet is 5x powerful than player's
	public bool magnetIsActive = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		rotation += drot;
		// normalize
		if ( rotation > 2 * Math.PI ) {
			rotation = 0;
		}

		if ( center == null ) return;

		Vector2 c = new Vector2( center.transform.position.x, center.transform.position.y );
		transform.position = new Vector3( c.x + (float) Math.Cos( rotation ) * orbitRadius, c.y - (float) Math.Sin( rotation ) * orbitRadius, transform.position.z );
	}
}
