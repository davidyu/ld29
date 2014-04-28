using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer), typeof(CircleCollider2D))]
public class Ground : MonoBehaviour {

	public int segments = 20;

	// Use this for initialization
	void Start () {
		// build circular mesh
		Mesh mesh = GetComponent<MeshFilter>().mesh;
		mesh.name = "Circle Mesh";

		float x = 0; // object space, not world space
		float y = 0; // object space, not world space
		float z = transform.position.z;

		float radius = GetComponent<CircleCollider2D>().radius;

		List<Vector3> vertices = new List<Vector3>();
		vertices.Add( new Vector3( x, y, z ) );
		float angleStep = (float) Math.PI * 2 / segments;
		for ( int i = 0; i <= segments; i++ ) {
			float a = i * angleStep;
			vertices.Add( new Vector3( x + (float) Math.Cos( a ) * radius, y - (float) Math.Sin( a ) * radius, z ) );
		}

		List<int> triangles = new List<int>();

		for ( int i = 1; i <= segments; i++ ) {
			triangles.Add( 0 );
			triangles.Add( i );
			triangles.Add( i+1 );
		}

		// last triangle
		triangles.Add( 0 );
		triangles.Add( segments - 1 );
		triangles.Add( 1 );

		List<Vector2> uvs = new List<Vector2>();
		uvs.Add( new Vector2( 0.5f, 0.5f ) );
		for ( uint i = 0; i <= segments; i++ ) {
			float a = i * angleStep;
			uvs.Add( new Vector2( 0.5f + (float) Math.Cos( a ) * 0.5f, 0.5f + (float) Math.Sin( a ) * 0.5f ) );
		}

		mesh.Clear();
		mesh.vertices = vertices.ToArray();
		mesh.triangles = triangles.ToArray();
		mesh.uv = uvs.ToArray();
		mesh.Optimize();
		mesh.RecalculateNormals();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
