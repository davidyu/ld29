using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Vector2 moveSpeed = new Vector2( 0.4f, 0.4f );
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate() {
		float h = Input.GetAxis( "Horizontal" );
		if( h < 0 ) {
			rigidbody2D.velocity = new Vector2( -moveSpeed.x, 0 );
		}

		if ( h > 0 ) {
			rigidbody2D.velocity = new Vector2( moveSpeed.x, 0 );
		}
	}
}
