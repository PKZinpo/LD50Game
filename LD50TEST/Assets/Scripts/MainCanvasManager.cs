using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvasManager : MonoBehaviour {

    [SerializeField] private Animator fade;
    [SerializeField] private Animator cutscene;
    [SerializeField] private Animator dialogueBox;

    void Start() {
        
    }

    void Update() {

    }

    public void ToCutscene() {
        cutscene.SetTrigger("ToCutscene");
    }
    public void FromCutscene() {
        cutscene.SetTrigger("FromCutscene");
    }
    public void FadeIn() {
        fade.SetTrigger("FadeIn");
    }
    public void FadeOut() {
        fade.SetTrigger("FadeOut");
    }
    public void DialogueIn() {
        fade.SetTrigger("DialogueIn");
    }
    public void DialogueOut() {
        fade.SetTrigger("DialogueOut");
    }




}
