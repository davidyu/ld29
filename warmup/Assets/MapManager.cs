using UnityEngine;
using System.Collections;
using System;

public class MapManager : MonoBehaviour {

	public Vector2 TileSize = new Vector2( 0.5f, 0.5f );
	public Vector2 GridSize = new Vector2( 10, 10 );

	// Use this for initialization
	void Start () {
		System.Random r = new System.Random();
		for ( int i = 0; i < GridSize.x; i++ ) {
			for ( int j = 0; j < GridSize.y; j++ ) {
				GameObject go = (GameObject) Instantiate( Resources.Load( "Tile" ) );
				int n = r.Next( 0, Enum.GetNames( typeof( TileType ) ).Length );
				go.GetComponent<Tile>().type = (TileType) n;
				go.transform.position = new Vector3( i * TileSize.x, j * TileSize.y, 0.0f );
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
