using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueOptionTrigger : MonoBehaviour ,Interacuable{

    public OptionDialogue dialogue;
    public DialogueManager dialogueManager;



    public void interactuar(){
        dialogueManager.StartDialogue(dialogue);
    }
}
