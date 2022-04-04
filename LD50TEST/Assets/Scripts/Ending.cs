using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour {

    public void StartStory() {
        GameObject.FindGameObjectWithTag("StoryManager").GetComponent<StoryManager>().SetDialogue(GetComponent<DialogueTrigger>().dialogue);
        GameObject.FindGameObjectWithTag("StoryManager").GetComponent<StoryManager>().StartStory("Ending");
    }
}
