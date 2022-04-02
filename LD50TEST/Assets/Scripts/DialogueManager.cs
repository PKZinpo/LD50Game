using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    [SerializeField] private Text nameText;
    [SerializeField] private Text dialogueText;
    [SerializeField] private Animator dialogueBox;
    [SerializeField] private GameObject continueText;
    [SerializeField] private float textTypeSpeed;
    
    private Queue<string> names;
    private Queue<string> sentences;


    private void Start() {
        names = new Queue<string>();
        sentences = new Queue<string>();
    }

    private void Update() {
        if (continueText.activeSelf) {
            if (Input.GetKeyDown(KeyCode.E)) {
                DisplayNextSentence();
            }
        }
    }

    public void StartDialogue(Dialogue dialogue) {

        continueText.SetActive(false);

        nameText.text = "";
        dialogueText.text = "";

        dialogueBox.SetTrigger("DialogueIn");

        names.Clear();
        sentences.Clear();

        foreach (string sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
        }
        foreach (string dialogueName in dialogue.name) {
            names.Enqueue(dialogueName);
        }

    }
    public void DisplayNextSentence() {

        continueText.SetActive(false);

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
            yield return new WaitForSeconds(textTypeSpeed);
        }
        continueText.SetActive(true);
    }
    private void EndDialogue() {

        dialogueBox.SetTrigger("DialogueOut");

    }
}
