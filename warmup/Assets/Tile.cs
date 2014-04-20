using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum TileType {
	GROUND,
	ABYSS
}

public class Tile : MonoBehaviour {

	public TileType type = TileType.GROUND;

	// Use this for initialization
	void Start () {
		Mesh mesh = GetComponent<MeshFilter>().mesh;

		float x = transform.position.x;
		float y = transform.position.y;
		float z = transform.position.z;

		List<Vector3> vertices = new List<Vector3>();
		vertices.Add( new Vector3( x, y, z ) );
		vertices.Add( new Vector3( x + 1, y, z ) );
		vertices.Add( new Vector3( x + 1, y - 1, z ) );
		vertices.Add( new Vector3( x, y - 1, z ) );

		List<int> triangles = new List<int>();
		triangles.Add( 0 );
		triangles.Add( 1 );
		triangles.Add( 3 );
		triangles.Add( 1 );
		triangles.Add( 2 );
		triangles.Add( 3 );

		mesh.Clear();
		mesh.vertices = vertices.ToArray();
		mesh.triangles = triangles.ToArray();
		mesh.Optimize();
		mesh.RecalculateNormals();
		GetComponent<MeshRenderer>().material.mainTexture = (Texture) Resources.Load( "tiles/walkable" );
	}

	// Update is called once per frame
	void Update () {
	}
}
