using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour {

    private CameraController cc;
    private MainCanvasManager mcm;

    private Dialogue dialogue;

    private int index;
    private string sceneName;

    private void Awake() {
        cc = Camera.main.GetComponent<CameraController>();
        mcm = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<MainCanvasManager>();
    }

    private void ResetVariables() {
        index = 0;
        dialogue = null;
    }

    public void SetDialogue(Dialogue d) {
        dialogue = d;
    }

    public void StartStory(string s) {
        sceneName = s;
        NextSceneInStory();
    }
    
    public void NextSceneInStory() {
        switch (sceneName) {

            case "Ladder":
                if (index == 0) {
                    mcm.GradientInDown();
                    cc.FromLadder();
                    index++;
                }
                else if (index == 1) {
                    GameObject.FindGameObjectWithTag("Trapdoor").GetComponent<Animator>().SetTrigger("TrapdoorCutscene");
                    index++;
                }
                else if (index == 2) {
                    mcm.GradientInUp();
                    cc.FromMainRoom();
                    GameObject spawnPositions = GameObject.FindGameObjectWithTag("SpawnPositions");
                    for (int i = 0; i < spawnPositions.transform.childCount; i++) {
                        if (spawnPositions.transform.GetChild(i).name.Substring(5) == "BasementLadder") {
                            GameObject.FindGameObjectWithTag("Father").transform.position = spawnPositions.transform.GetChild(i).position;
                        }
                    }
                    index++;
                }
                else if (index == 3) {
                    mcm.GradientOutDown();
                    cc.ToLadder();
                    index++;
                }
                else if (index == 4) {
                    FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                    index++;
                }
                else if (index == 5) {
                    mcm.GradientInDownTransition();
                    cc.FromLadderTran();
                    index++;
                }
                else if (index == 6) {
                    Debug.Log("[StoryManager] Ladder cutscene done");
                    ResetVariables();
                }
                break;

            case "Flashback":
                Debug.Log(index);
                if (index == 0) {
                    mcm.GradientOutUp();
                    cc.ToMainRoom();
                    index++;
                }
                else if (index == 1) {
                    FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                    index++;
                }
                else if (index == 2) {
                    GameObject.FindGameObjectWithTag("Door").GetComponent<Animator>().SetTrigger("DoorOpen");
                    index++;
                }
                else if (index == 3) {
                    mcm.GradientInUp();
                    cc.FromMainRoom();
                    index++;
                }
                else if (index == 4) {
                    mcm.GradientOutDown();
                    cc.ToBasement();
                    index++;
                }
                else if (index == 5) {
                    FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                    index++;
                }
                else if (index == 6) {
                    mcm.GradientInDownTransition();

                }
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
                if (index >= 7) {
                    return true;
                }
                break;

            case "Flashback":
                if (index >= 7) {
                    return true;
                }
                break;

            case "Fishing":
                if (index >= 7) {
                    return true;
                }
                break;

            case "Ending":
                if (index >= 7) {
                    return true;
                }
                break;
        }
        return false;
    }
}
