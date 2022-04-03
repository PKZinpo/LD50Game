using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionTrigger : MonoBehaviour, IMainTrigger {
    public void MainTrigger() {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().DoAction();
    }

    public void MainTriggerLeave() {
        
    }
}
