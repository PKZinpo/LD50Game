using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomChange : MonoBehaviour, ITrigger {
    public void Trigger() {
        string objName = name.Substring(2);
        Camera.main.gameObject.GetComponent<CameraController>().MoveCameraToPosition(objName);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().ChangePosition(objName);
    }
}
