using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject target = null;

	// Use this for initialization
	void Start () {
		// acquire player
	}
	
	// Update is called once per frame
	void Update () {
		// get entity with tag (player)
		if ( target != null ) {
			this.transform.position = target.transform.position;
		}
	}
}
