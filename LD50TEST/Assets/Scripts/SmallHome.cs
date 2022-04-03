using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallHome : MonoBehaviour {

    public void NextStory() {
        GameObject.FindGameObjectWithTag("StoryManager").GetComponent<StoryManager>().SetDialogue(GetComponent<DialogueTrigger>().dialogue);
    }
}
