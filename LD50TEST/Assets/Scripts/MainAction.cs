using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAction : MonoBehaviour, IMainTrigger {

    [SerializeField] private KeyCode input;

    private bool pressedKey = false;
    private bool inTrigger = false;

    public void MainTrigger() {
        GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<MainCanvasManager>().ChangeActionKey(input);
        Time.timeScale = 0.2f;
        inTrigger = true;
    }

    public void MainTriggerLeave() {
        GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<MainCanvasManager>().DisableActionKey();
        Time.timeScale = 1f;
        inTrigger = false;
        if (!pressedKey) GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().IsActionFailed(true);
    }

    public void Update() {
        if (!inTrigger) return;

        if (Input.GetKeyDown(input)) {
            MainTriggerLeave();
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().IsActionFailed(false);
            pressedKey = true;
        }
        else if (Input.anyKeyDown) {
            MainTriggerLeave();
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().IsActionFailed(true);
            pressedKey = true;
        }
        
    }



}
