using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour {

    [SerializeField] private Animator camera;

    private MainCanvasManager mcm;

    private Dialogue dialogue;

    private int index;
    private string sceneName;

    private void Awake() {
        mcm = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<MainCanvasManager>();
    }

    private void ResetVariables() {
        index = 0;
        dialogue = null;
    }

    public void StartStory(string s) {
        sceneName = s;
        NextSceneInStory();
    }

    public void NextSceneInStory() {
        switch (sceneName) {

            case "Ladder":
                if (index == 0) {

                }
                break;

            case "Flashback":

                break;

            case "Fishing":

                break;

            case "Ending":

                break;
        }
    }

    public bool IsStoryDone() {
        switch (sceneName) {

            case "Ladder":
                if (index == 0) {

                }
                break;

            case "Flashback":

                break;

            case "Fishing":

                break;

            case "Ending":

                break;
        }
        return false;
    }
}
