using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour {

    [SerializeField] private PlayerController pc;

    private void Start() {
        pc = transform.parent.GetComponent<PlayerController>();
    }

    public void TriggerAction() {
        pc.TriggerTrip();
    }
}
