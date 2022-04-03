using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCanvasManager : MonoBehaviour {

    [SerializeField] private Animator fade;
    [SerializeField] private Animator cutscene;
    [SerializeField] private Animator dialogueBox;
    [SerializeField] private Animator gradient;
    [SerializeField] private Text transitionText;
    [SerializeField] private GameObject action;

    private CutsceneManager cm;
    private string fadeTrigger;
    private string cutsceneName;

    void Start() {
        cm = GameObject.FindGameObjectWithTag("CutsceneManager").GetComponent<CutsceneManager>();

        cm.OnTriggerCutscene += ToCutscene;
        action.SetActive(false);
    }

    public void ToCutscene(object sender, CutsceneManager.OnTriggerCutsceneEventArgs e) {
        cutsceneName = e.cutsceneName;
        cutscene.SetTrigger("ToCutscene");
        GameManager.noPlayerMove = true;
    }
    public void FromCutscene() {
        if (GameManager.inCutscene) return;
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
        if (!GameManager.inCutscene) GameManager.noPlayerMove = false;
        else GameObject.FindGameObjectWithTag("StoryManager").GetComponent<StoryManager>().NextSceneInStory();
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
    public void GradientInDownTransition() {
        gradient.SetTrigger("GradInDownTran");
    }
    public void GradientInUp() {
        gradient.SetTrigger("GradInUp");
    }
    public void GradientOutDown() {
        gradient.SetTrigger("GradOutDown");
    }
    public void GradientOutUp() {
        gradient.SetTrigger("GradOutUp");
    }
    public void GradientToIdle() {
        gradient.SetTrigger("ToIdle");
    }
    public void FadeTrigger() {
        Camera.main.gameObject.GetComponent<CameraController>().MoveCameraToPosition(fadeTrigger);
        if (fadeTrigger.Contains("Basement")) GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().ChangePosition(fadeTrigger);
        FadeOut();
        
    }
    public void StartCutscene() {
        GameObject.FindGameObjectWithTag("StoryManager").GetComponent<StoryManager>().StartStory(cutsceneName);
    }
    public void ChangeActionKey(KeyCode keycode) {
        action.SetActive(true);
        switch (keycode) {

            case KeyCode.Q:
                action.GetComponent<Animator>().SetTrigger("Q");
                break;

            case KeyCode.W:
                action.GetComponent<Animator>().SetTrigger("W");
                break;

            case KeyCode.E:
                action.GetComponent<Animator>().SetTrigger("E");
                break;

            case KeyCode.F:
                action.GetComponent<Animator>().SetTrigger("F");
                break;


        }

    }
    public void DisableActionKey() {
        action.SetActive(false);
    }
}
