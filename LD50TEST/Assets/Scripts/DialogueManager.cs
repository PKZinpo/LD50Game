using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    [SerializeField] private Text nameText;
    [SerializeField] private Text dialogueText;
    [SerializeField] private Animator dialogueBox;
    
    private Queue<string> names;
    private Queue<string> sentences;


    void Start() {
        names = new Queue<string>();
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue) {

        dialogueBox.SetTrigger("DialogueIn");

        names.Clear();
        sentences.Clear();

        foreach (string sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
        }
        foreach (string dialogueName in dialogue.name) {
            names.Enqueue(dialogueName);
        }

        DisplayNextSentence();

    }
    private void DisplayNextSentence() {
        
        if (sentences.Count == 0) {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        string name = names.Dequeue();

        nameText.text = name;

        StartCoroutine(TypeSentence(sentence));
    }
    private IEnumerator TypeSentence(string sentence) {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray()) {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.1f);
        }

    }
    private void EndDialogue() {

        dialogueBox.SetTrigger("DialogueOut");

    }
}
