using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBox : MonoBehaviour {

    public void StartDialogueText() {
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
    }
    public void EndCutscene() {
        GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<MainCanvasManager>().FromCutscene();
    }
}
