using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionTextTwo : MonoBehaviour {

    public void NextCutsceneTwo() {
        StoryManager sm = GameObject.FindGameObjectWithTag("StoryManager").GetComponent<StoryManager>();
        sm.SetDialogue(GetComponent<DialogueTrigger>().dialogue);
        sm.StartStory("Fishing");
    }
}
