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
		GameObject bomber = GameObject.FindWithTag( "Bomber" );

		Vector3 playerToMe = player.transform.position - transform.position;
		Vector2 pf = GetForceByCoulombsLaw( PlayerController.PoleToCharge( player.GetComponent<PlayerController>().pole ),
																				PoleToCharge( pole ),
																				new Vector2( playerToMe.x, playerToMe.y ) );
		rigidbody2D.AddForce( pf );

		// apply bomber force
		if ( gameObject != bomber && gameObject != player &&
				 bomber.GetComponent<BomberController>().magnetIsActive ) { // bomber does not affect itself or the player
			Vector3 bomberToMe =  transform.position - bomber.transform.position;
			Vector2 bf = GetForceByCoulombsLaw( PoleToCharge( bomber.GetComponent<Magnet>().pole ),
																					PoleToCharge( pole ),
																					new Vector2( bomberToMe.x, bomberToMe.y ) );

			rigidbody2D.AddForce( bf * bomber.GetComponent<BomberController>().bomberMagnetMultiplier );
		}
	}

	Vector2 GetForceByCoulombsLaw( float q1, float q2, Vector2 r ) {
		GameObject world = GameObject.FindWithTag( "World" );
		return r.normalized * q1 * q2 * world.GetComponent<LevelSettings>().coloubConstant / r.sqrMagnitude;
	}
}
