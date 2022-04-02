using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomChange : MonoBehaviour, ITrigger {
    public void Trigger() {
        
        Camera.main.gameObject.GetComponent<CameraController>().MoveCameraToPosition(name.Substring(2));
    }
}
