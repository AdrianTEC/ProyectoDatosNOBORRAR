using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour ,Interacuable{

	public Dialogue dialogue;
	public DialogueManager dialogueManager;



	public void interactuar(){
		dialogueManager.StartDialogue(dialogue);
	}
}
