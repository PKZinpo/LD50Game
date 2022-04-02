using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBox : MonoBehaviour {

    public void StartDialogueText() {
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
    }
}
