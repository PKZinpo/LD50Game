using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour {

    public event EventHandler<OnTriggerCutsceneEventArgs> OnTriggerCutscene;

    public class OnTriggerCutsceneEventArgs : EventArgs {
        public string cutsceneName;
    }

    private bool ladderCutscene;
    private bool flashbackCutscene;
    private bool fishingCutscene;
    private bool endingCutscene;

    void Start() {
        GameManager.noPlayerMove = true;
    }

    public void StartCutscene(string csName) {
        OnTriggerCutscene?.Invoke(this, new OnTriggerCutsceneEventArgs { cutsceneName = csName });
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
