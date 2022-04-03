using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAction : MonoBehaviour, IMainTrigger {

    [SerializeField] private KeyCode input;

    private bool inTrigger = false;

    public void MainTrigger() {
        Time.timeScale = 0.2f;
        inTrigger = true;
    }

    public void MainTriggerLeave() {
        Time.timeScale = 1f;
        inTrigger = false;
    }

    public void Update() {
        if (!inTrigger) return;

        if (Input.GetKeyDown(input)) {
            MainTriggerLeave();
        }
        else if (Input.anyKeyDown) {
            MainTriggerLeave();
            Debug.Log("WRONG KEY");
        }
        
    }



}
