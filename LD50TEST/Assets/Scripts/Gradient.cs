using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gradient : MonoBehaviour {

    private bool transition = false;

    public void ToGradientOutUp() {
        GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<MainCanvasManager>().GradientOutUp();
    }
    public void ToGradientOutDown() {
        GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<MainCanvasManager>().GradientOutDown();
    }
    public void ToIdle() {
        GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<MainCanvasManager>().GradientToIdle();
    }
    public void ToTransitionText() {
        if (!transition) {
            GameObject.FindGameObjectWithTag("TransitionText").GetComponent<Animator>().SetTrigger("TransitionText");
            transition = true;
            GameObject.FindGameObjectWithTag("StoryManager").GetComponent<StoryManager>().NextSceneInStory();
        }
        else {
            GameObject.FindGameObjectWithTag("TransitionText2").GetComponent<Animator>().SetTrigger("TransitionText");
        }
        
    }
}
