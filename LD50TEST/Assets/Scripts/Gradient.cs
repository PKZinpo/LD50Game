using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gradient : MonoBehaviour {

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
        GameObject.FindGameObjectWithTag("TransitionText").GetComponent<Animator>().SetTrigger("TransitionText");
        GameObject.FindGameObjectWithTag("StoryManager").GetComponent<StoryManager>().NextSceneInStory();
    }
}
