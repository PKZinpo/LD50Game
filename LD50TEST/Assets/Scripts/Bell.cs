using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bell : MonoBehaviour {

    public void PlayStoryBell() {
        Invoke("PlayBell", 2f);
    }

    private void PlayBell() {
        FindObjectOfType<AudioManager>().Play("Bell");
        GameObject.FindGameObjectWithTag("StoryManager").GetComponent<StoryManager>().SetDialogue(GetComponent<DialogueTrigger>().dialogue);
        Invoke("NextStory", 2f);
    }

    private void NextStory() {
        GameObject.FindGameObjectWithTag("StoryManager").GetComponent<StoryManager>().NextSceneInStory();
    }

    public void PlayDoubleBell() {
        Invoke("PlayTransitionBell", 2f);
        Invoke("PlayTransitionBell", 4f);
        Invoke("StartEnding", 8f);
    }

    private void PlayTransitionBell() {
        FindObjectOfType<AudioManager>().Play("Bell");
    }

    public void StartEnding() {
        GameObject.Find("Ending").GetComponent<Ending>().StartStory();
    }
}
