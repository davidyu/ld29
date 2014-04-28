using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(TextMesh))]
public class DialogData : MonoBehaviour {

	public List<string> lines; //unused for now
	public int lineSwapInterval = 3;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
}
