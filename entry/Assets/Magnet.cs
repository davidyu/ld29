using UnityEngine;
using System.Collections;

public enum Pole {
	SOUTH,
	NORTH
}

[RequireComponent(typeof(Rigidbody2D))]
public class Magnet : MonoBehaviour {
	public Pole pole;

	public static float PoleToCharge( Pole p ) {
		return p == Pole.SOUTH ? 1f : -1f;
	}

	void Update () {
		// only care about magnetic force between you and player
		GameObject player = GameObject.FindWithTag( "Player" );
		GameObject world = GameObject.FindWithTag( "World" );
		var q1 = PlayerController.PoleToCharge( player.GetComponent<PlayerController>().pole );
		var q2 = PoleToCharge( pole );
		Vector3 diff = player.transform.position - transform.position;
		Vector2 dir = new Vector2( diff.x, diff.y );
		Vector2 force = dir.normalized * q1 * q2 * world.GetComponent<LevelSettings>().coloubConstant / dir.sqrMagnitude;
		rigidbody2D.AddForce( force );
	}
}
