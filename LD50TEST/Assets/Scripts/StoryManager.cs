using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryManager : MonoBehaviour {

    [SerializeField] private Sprite sleepingBag;

    private CameraController cc;
    private MainCanvasManager mcm;

    private Dialogue dialogue;

    private int index;
    private string sceneName;

    private AudioSource track;

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
                    FindObjectOfType<AudioManager>().Play("Violin");
                    index++;
                }
                else if (index == 2) {
                    mcm.GradientInUp();
                    cc.FromMainRoom();
                    GameObject.FindGameObjectWithTag("Father").GetComponent<SpriteRenderer>().enabled = true;
                    GameObject.FindGameObjectWithTag("Dad Sitting").GetComponent<SpriteRenderer>().enabled = true;
                    GameObject.FindGameObjectWithTag("SleepingDad").GetComponent<SpriteRenderer>().sprite = sleepingBag;
                    //GameObject spawnPositions = GameObject.FindGameObjectWithTag("SpawnPositions");
                    //for (int i = 0; i < spawnPositions.transform.childCount; i++) {
                    //    if (spawnPositions.transform.GetChild(i).name.Substring(5) == "BasementLadder") {
                    //        GameObject.FindGameObjectWithTag("Father").transform.position = spawnPositions.transform.GetChild(i).position;
                    //    }
                    //}
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
                    GameObject.FindGameObjectWithTag("Grandpa Sitting").GetComponent<SpriteRenderer>().enabled = true;
                    Debug.Log("[StoryManager] Ladder cutscene done");
                    ResetVariables();
                }
                break;

            case "Flashback":
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
                    GameObject.FindGameObjectWithTag("Grandpa Sitting").GetComponent<SpriteRenderer>().enabled = false;
                    Debug.Log("[StoryManager] Flashback cutscene done");
                    ResetVariables();
                }
                break;

            case "Fishing":
                if (index == 0) {
                    cc.MoveCameraToPosition("Fishing");
                    mcm.GradientOutUp();
                    Invoke("NextSceneInStory", 1f);
                    index++;
                }
                else if (index == 1) {
                    FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                    index++;
                }
                else if (index == 2) {
                    GameObject.FindGameObjectWithTag("Bell").GetComponent<Bell>().PlayStoryBell();
                    index++;
                }
                else if (index == 3) {
                    FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                    FindObjectOfType<AudioManager>().Play("Track2");
                    index++;
                }
                else if (index == 4) {
                    mcm.FadeIn("SmallHome");
                    GameObject.FindGameObjectWithTag("SmallHome").GetComponent<SmallHome>().NextStory();
                    index++;
                }
                else if (index == 5) {
                    FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                    index++;
                }
                else if (index == 6) {
                    mcm.GradientInDownTransition();
                    Invoke("NextSceneInStory", 1f);
                    index++;
                }
                else if (index == 7) {
                    GameManager.inCutscene = false;
                    GameManager.isInFinal = true;
                    mcm.GradientOutUp();
                    mcm.FromCutscene();
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().ToFinal();
                    Debug.Log("[StoryManager] Fishing cutscene done");
                    ResetVariables();
                }
                break;

            case "Ending":
                if (index == 0) {
                    mcm.LongFadeOut();
                    GameObject cameraPositions = GameObject.FindGameObjectWithTag("CameraPositions");
                    for (int i = 0; i < cameraPositions.transform.childCount; i++) {
                        if (cameraPositions.transform.GetChild(i).name == "Main") {
                            Camera.main.transform.position = cameraPositions.transform.GetChild(i).position + new Vector3(0f, 0f, -10f);
                            break;
                        }
                    }
                    index++;
                }
                else if (index == 1) {
                    FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                    FindObjectOfType<AudioManager>().Play("Track3");
                    index++;
                }
                else if (index == 2) {
                    mcm.GradientInUp();
                    Debug.Log("[StoryManager] Ending cutscene done");
                }
                break;
        }
    }

    public void SetAudioSource(AudioSource source) {
        track = source;
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
                if (index >= 8) {
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
