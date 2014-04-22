using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum TileType {
	GROUND,
	ABYSS
}

public enum TileState {
	NORMAL,
	HILIGHTED,
}

public class Tile : MonoBehaviour {
	public static Vector2 size = new Vector2( 0.5f, 0.5f );
	public TileType type = TileType.GROUND;
	public TileState state = TileState.NORMAL;

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

		List<Vector2> uvs = new List<Vector2>();
		uvs.Add( new Vector2( 0, 1 ) );
		uvs.Add( new Vector2( 1, 1 ) );
		uvs.Add( new Vector2( 1, 0 ) );
		uvs.Add( new Vector2( 0, 0 ) );

		mesh.Clear();
		mesh.vertices = vertices.ToArray();
		mesh.triangles = triangles.ToArray();
		mesh.uv = uvs.ToArray();
		mesh.Optimize();
		mesh.RecalculateNormals();
	}

	// Update is called once per frame
	void Update () {
		// hot-swappable materials
		switch ( state ) {
			case TileState.NORMAL:
				GetComponent<MeshRenderer>().material = (Material) Resources.Load( "materials/unlit" );
				break;
			case TileState.HILIGHTED:
				GetComponent<MeshRenderer>().material = (Material) Resources.Load( "materials/highlight" );
				break;
		}
		// hot-swappable textures
		Material material = GetComponent<MeshRenderer>().material;
		Texture newTexture = material.mainTexture;
		switch ( type ) {
			case TileType.GROUND:
				newTexture = (Texture) Resources.Load( "tiles/walkable" );
				break;
			case TileType.ABYSS:
				newTexture = (Texture) Resources.Load( "tiles/abyss" );
				break;
		}

		if ( newTexture != material.mainTexture ) {
			material.mainTexture = newTexture;
		}
	}
}
