using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Vector2 panSpeed = new Vector2( 0.2f, 0.2f );
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxis( "Horizontal" );
		float v = Input.GetAxis( "Vertical" );

		if( h < 0 ) {
			transform.position = new Vector3( transform.position.x - panSpeed.x, transform.position.y, transform.position.z );
		}

		if ( h > 0 ) {
			transform.position = new Vector3( transform.position.x + panSpeed.x, transform.position.y, transform.position.z );
		}

		if ( v < 0 ) {
			transform.position = new Vector3( transform.position.x, transform.position.y - panSpeed.y, transform.position.z );
		}
	
		if ( v > 0 ) {
			transform.position = new Vector3( transform.position.x, transform.position.y + panSpeed.y, transform.position.z );
		}
	}
}
