using UnityEngine;
using System.Collections;

public class FlowerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D( Collider2D other ) {
		if ( other.gameObject.name == "Rose" ) {
			print( "WIN" );
		}
	}
}
