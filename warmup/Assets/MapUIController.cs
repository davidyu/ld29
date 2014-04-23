using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class MapUIController : MonoBehaviour {

	private MapManager manager;
	public List<GameObject> highlightedCells = new List<GameObject>();

	// Use this for initialization
	void Start () {
		manager = GetComponent<MapManager>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = -Camera.main.transform.position.z; // why? I don't know! Otherwise nothing works
		Vector3 worldPos = Camera.main.ScreenToWorldPoint( mousePos );
		int gridx = (int) Math.Ceiling( worldPos.x / ( MapManager.margin.x ) ) - 1,
				gridy = (int) Math.Ceiling( worldPos.y / ( MapManager.margin.y ) );
		if ( gridx % 2 == 0 && gridy % 2 == 0 ) { // hack to only process cells and not margins
			print( gridx / 2 + "," + gridy / 2 );
			int index = (int) ( gridy / 2 + ( gridx / 2 ) * manager.GridSize.x );
			GameObject target = manager.grid[ index ];
			if ( !highlightedCells.Exists( x => x == target ) ) {
				highlightedCells.Add( target );
			}
		} // ignore otherwise
		// TODO clear all but the last highlighted cells
		while ( highlightedCells.Count > 1 ) {
			GameObject cell = highlightedCells[ 0 ];
			cell.GetComponent<Tile>().state = TileState.NORMAL;
			highlightedCells.RemoveAt(0);
		}

		// highlight cells
		highlightedCells.ForEach( x => x.GetComponent<Tile>().state = TileState.HILIGHTED );

		
	}
}
