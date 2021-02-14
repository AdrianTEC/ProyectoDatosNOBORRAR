using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue {

	public string name;

	[TextArea(3, 10)]
	public string[] sentences;

}
[Serializable]

public class OptionDialogue:Dialogue{
	public List<DialogOption> options;
}

[Serializable]
public class DialogOption{
	public Activable target;
	public string text;
	[TextArea(3, 10)]
	public string sentenceInAction;

	public string textInAction;

}