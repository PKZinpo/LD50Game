using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour {

    public void StartFadeTrigger() {
        GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<MainCanvasManager>().FadeTrigger();
    }

    public void NextStory() {
        GameObject.FindGameObjectWithTag("StoryManager").GetComponent<StoryManager>().NextSceneInStory();
    }

}
