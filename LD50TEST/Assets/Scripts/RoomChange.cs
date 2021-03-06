using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomChange : MonoBehaviour, ITrigger {

    [SerializeField] private string cutsceneName;

    public void Trigger() {
        if (name.Contains("Cutscene")) {
            GameManager.inCutscene = true;
            GameObject.FindGameObjectWithTag("StoryManager").GetComponent<StoryManager>().SetDialogue(GetComponent<DialogueTrigger>().dialogue);
            GameObject.FindGameObjectWithTag("CutsceneManager").GetComponent<CutsceneManager>().StartCutscene(cutsceneName);
            return;
        }
        string objName = name.Substring(2);
        GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<MainCanvasManager>().FadeIn(objName);
    }
}
