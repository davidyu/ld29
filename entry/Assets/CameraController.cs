using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject target = null;
	public float cameraZ = -10.0f;

	// Use this for initialization
	void Start () {
		// acquire player
	}

	// Update is called once per frame
	void Update () {
		if ( target != null ) {
			this.transform.position = new Vector3( target.transform.position.x, target.transform.position.y, cameraZ );
			this.transform.rotation = target.transform.rotation;
		}
	}
}
