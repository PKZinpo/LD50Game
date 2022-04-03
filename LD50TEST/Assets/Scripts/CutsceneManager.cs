using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour {

    public event EventHandler<OnTriggerCutsceneEventArgs> OnTriggerCutscene;

    public class OnTriggerCutsceneEventArgs : EventArgs {
        public string cutsceneName;
    }

    private bool ladderCutscene = false;
    private bool flashbackCutscene = false;
    private bool fishingCutscene = false;
    private bool endingCutscene = false;

    void Start() {
        GameManager.noPlayerMove = true;
    }

    public void StartCutscene(string csName) {
        OnTriggerCutscene?.Invoke(this, new OnTriggerCutsceneEventArgs { cutsceneName = csName });
    }
    public bool StoryDone(string s) {
        switch (s) {

            case "Ladder":
                ladderCutscene = true;
                break;

            case "Flashback":
                flashbackCutscene = true;
                break;

            case "Fishing":
                fishingCutscene = true;
                break;

            case "Ending":
                endingCutscene = true;
                break;
        }
        return false;
    }
    private void StartLadderCutscene() {
        
    }
    private void FlashbackCutscene() {

    }
    private void FishingCutscene() {

    }
    private void EndingCutscene() {

    }
}
