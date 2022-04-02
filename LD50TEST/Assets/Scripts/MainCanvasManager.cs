using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvasManager : MonoBehaviour {

    [SerializeField] private Animator fade;
    [SerializeField] private Animator cutscene;
    [SerializeField] private Animator dialogueBox;
    [SerializeField] private Animator gradient;

    private CutsceneManager cm;
    private string fadeTrigger;
    private string cutsceneName;

    void Start() {
        cm = GameObject.FindGameObjectWithTag("CutsceneManager").GetComponent<CutsceneManager>();

        cm.OnTriggerCutscene += ToCutscene;
    }

    void Update() {

    }

    public void ToCutscene(object sender, CutsceneManager.OnTriggerCutsceneEventArgs e) {
        cutsceneName = e.cutsceneName;
        cutscene.SetTrigger("ToCutscene");
    }
    public void FromCutscene() {
        cutscene.SetTrigger("FromCutscene");
        GameManager.noPlayerMove = false;
    }
    public void FadeIn(string room) {
        fade.SetTrigger("FadeIn");
        GameManager.noPlayerMove = true;
        fadeTrigger = room;
    }
    public void FadeOut() {
        fade.SetTrigger("FadeOut");
        GameManager.noPlayerMove = false;
    }
    public void DialogueIn() {
        fade.SetTrigger("DialogueIn");
    }
    public void DialogueOut() {
        fade.SetTrigger("DialogueOut");
    }
    public void GradientInDown() {
        gradient.SetTrigger("GradInDown");
    }
    public void GradientInUp() {
        gradient.SetTrigger("GradInUp");
    }
    public void GradientOutDown() {
        gradient.SetTrigger("GradOutDown");
    }
    public void GradientOutUp() {
        gradient.SetTrigger("GradOutDown");
    }
    public void FadeTrigger() {
        Camera.main.gameObject.GetComponent<CameraController>().MoveCameraToPosition(fadeTrigger);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().ChangePosition(fadeTrigger);
        FadeOut();
    }
    public void StartCutscene() {
        GameObject.FindGameObjectWithTag("StoryManager").GetComponent<StoryManager>().StartStory(cutsceneName);
    }

}
