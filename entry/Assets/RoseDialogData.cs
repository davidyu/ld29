using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public enum RoseState {
	REQUEST_HELP,
	FLYING,
	GRATEFUL
}

[Serializable]
public class StateLineData {
	public List<string> lines;
	public RoseState state;
}

[Serializable]
public class DialogState {
	public int lineIndex;
	public RoseState state;

	public DialogState( int sli, RoseState ss ) {
		lineIndex = sli;
		state = ss;
	}
}

public class RoseDialogData : DialogData {
	public DialogState currentState = new DialogState( 0, RoseState.REQUEST_HELP );
	public List<StateLineData> roseLines;

	private DateTime lastUpdated;

	void Start() {
		lastUpdated = DateTime.Now;
	}

	// Update is called once per frame
	void Update () {
		for ( int i = 0; i < Enum.GetNames( typeof( RoseState ) ).Length; i++ ) {
			if ( (RoseState) i == currentState.state && (DateTime.Now - lastUpdated).Seconds >= lineSwapInterval ) {
				currentState.lineIndex = ( currentState.lineIndex + 1 ) % roseLines[i].lines.Count;
				lastUpdated = DateTime.Now;
			}
		}


		GetComponent<TextMesh>().text = roseLines[ (int) currentState.state ].lines[ currentState.lineIndex ];
	}
}
