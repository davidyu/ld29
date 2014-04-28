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
		var q1 = PlayerController.PoleToCharge( player.GetComponent<PlayerController>().pole );
		var q2 = PoleToCharge( pole );
		Vector3 diff = player.transform.position - transform.position;
		Vector2 dir = new Vector2( diff.x, diff.y );
		Vector2 force = dir * q1 * q2 * LevelSettings.coloubConstant / dir.magnitude;
		rigidbody2D.AddForce( force );
	}
}
