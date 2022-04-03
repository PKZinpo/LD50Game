using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour {

    public void StartCutscene() {
        GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<MainCanvasManager>().StartCutscene();
    }
}
