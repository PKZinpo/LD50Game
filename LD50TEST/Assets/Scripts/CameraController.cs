using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField] private Vector3 cameraOffset;

    private GameObject player;
    private GameObject cameraPositions;
    private Animator anim;

    private void Awake() {
        cameraPositions = GameObject.FindGameObjectWithTag("CameraPositions");
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        anim.enabled = false;
    }

    private void Update() {
        //transform.position = player.transform.position + cameraOffset;
    }

    public void MoveCameraToPosition(string posName) {
        for (int i = 0; i < cameraPositions.transform.childCount; i++) {
            Debug.Log(cameraPositions.transform.GetChild(i).name);
            if (cameraPositions.transform.GetChild(i).name == posName) {
                Debug.Log($"[CameraController] Moved to {cameraPositions.transform.GetChild(i).position}");
                transform.position = cameraPositions.transform.GetChild(i).position + cameraOffset;
                break;
            }
        }
    }

    public void ToBasement() {
        anim.enabled = true;
        anim.SetTrigger("ToBasement");
    }
    public void FromMainRoom() {
        anim.enabled = true;
        anim.SetTrigger("FromMain");
    }
    public void ToMainRoom() {
        anim.enabled = true;
        anim.SetTrigger("ToMain");
    }
    public void FromLadder() {
        anim.enabled = true;
        anim.SetTrigger("FromLadder");
    }
    public void FromLadderTran() {
        anim.enabled = true;
        anim.SetTrigger("FromLadderTran");
    }
    public void ToLadder() {
        anim.enabled = true;
        anim.SetTrigger("ToLadder");
    }
    public void ToIdle() {
        anim.enabled = false;
        anim.SetTrigger("ToIdle");
        NextStory();
    }
    public void NextStory() {
        GameObject.FindGameObjectWithTag("StoryManager").GetComponent<StoryManager>().NextSceneInStory();
    }
}
