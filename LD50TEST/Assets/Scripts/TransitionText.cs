using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionText : MonoBehaviour {

    public void NextCutscene() {
        StoryManager sm = GameObject.FindGameObjectWithTag("StoryManager").GetComponent<StoryManager>();
        sm.SetDialogue(GetComponent<DialogueTrigger>().dialogue);
        sm.StartStory("Flashback");
    }
}
