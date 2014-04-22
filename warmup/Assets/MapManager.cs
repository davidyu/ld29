using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class MapManager : MonoBehaviour {

	public static Vector2 margin = new Vector2( 1.0f, 1.0f ); // not very data-driven; code is brittle and depends on this special value of 1.0 for margins
	public Vector2 GridSize = new Vector2( 5, 5 );
	public List<GameObject> grid = new List<GameObject>();

	// Use this for initialization
	void Start () {
		System.Random r = new System.Random();
		for ( int i = 0; i < GridSize.x; i++ ) {
			for ( int j = 0; j < GridSize.y; j++ ) {
				GameObject go = (GameObject) Instantiate( Resources.Load( "Tile" ) );
				int n = r.Next( 0, Enum.GetNames( typeof( TileType ) ).Length );
				go.GetComponent<Tile>().type = (TileType) n;
				go.transform.position = new Vector3( i * ( margin.x ), j * ( margin.y ), 1.0f );
				grid.Add( go );
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
