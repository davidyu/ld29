using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public enum RoseState {
	REQUEST_HELP,
	FLYING,
	HELP_ACQUIRED
}

[Serializable]
public class LineState {
	public List<string> lines;
	public RoseState state;
}

public class RoseDialogData : DialogData {
	public RoseState currentState = RoseState.REQUEST_HELP;
	public List<LineState> roseLines;

	// Update is called once per frame
	void Update () {
	}
}
