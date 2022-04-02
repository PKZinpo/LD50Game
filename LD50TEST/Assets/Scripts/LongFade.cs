using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongFade : MonoBehaviour {



    private void StartGameCoroutine() {
        StartCoroutine(StartGame());
    }

    private IEnumerator StartGame() {
        yield return new WaitForSeconds(1f);
        GetComponent<DialogueTrigger>().TriggerDialogue();
    }
}
