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
    public void ToEnding() {
        GameManager.isInFinal = false;
        //GameObject.FindGameObjectWithTag("OpeningTrapDoor").GetComponent<SpriteRenderer>().enabled = true;
        GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<MainCanvasManager>().FadeIn(false);
        GameObject.FindGameObjectWithTag("Bell").GetComponent<Bell>().PlayDoubleBell();
    }

    public void Restart() {
        pc.Restart();
    }
}
