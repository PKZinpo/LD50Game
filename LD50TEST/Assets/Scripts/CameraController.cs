using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField] private Vector3 cameraOffset;

    private GameObject cameraPositions;

    private void Awake() {
        cameraPositions = GameObject.FindGameObjectWithTag("CameraPositions");
    }

    public void MoveCameraToPosition(string posName) {
        for (int i = 0; i < cameraPositions.transform.childCount; i++) {
            if (cameraPositions.transform.GetChild(i).name == posName) {
                Debug.Log($"[CameraController] Moved to {cameraPositions.transform.GetChild(i).position}");
                transform.position = cameraPositions.transform.GetChild(i).position + cameraOffset;
                break;
            }
        }
    }

}
