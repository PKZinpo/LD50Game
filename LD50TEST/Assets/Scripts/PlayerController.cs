using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] private float mainMovementSpeed;
    [SerializeField] private float kidMovementSpeed;

    private bool inTrigger = false;
    private ITrigger triggerObject;
    private GameObject pressF;

    private void Awake() {
        pressF = GameObject.FindGameObjectWithTag("PressF");
        pressF.SetActive(false);
    }

    private void Update() {

        if (GameManager.noPlayerMove) return;

        float movement;
        if (GameManager.isInMainSequence) {
            movement = Input.GetAxisRaw("Horizontal") * mainMovementSpeed * Time.deltaTime;
        }
        else {
            movement = Input.GetAxisRaw("Horizontal") * kidMovementSpeed * Time.deltaTime;
        }
        
        //float movement = movementSpeed * Time.deltaTime;
        transform.position += new Vector3(movement, 0f, 0f);

        if (inTrigger && Input.GetKeyDown(KeyCode.F)) {
            triggerObject.Trigger();
            pressF.SetActive(false);
        }
    }
    public void ChangePosition(string posName) {

        GameObject spawnPositions = GameObject.FindGameObjectWithTag("SpawnPositions");
        for (int i = 0; i < spawnPositions.transform.childCount; i++) {
            if (spawnPositions.transform.GetChild(i).name.Substring(5) == posName) {
                Debug.Log($"[PlayerController] Moved to {spawnPositions.transform.GetChild(i).position}");
                transform.position = spawnPositions.transform.GetChild(i).position;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.GetComponent<ITrigger>() != null) {
            inTrigger = true;
            triggerObject = collision.GetComponent<ITrigger>();
            pressF.transform.position = collision.transform.position + new Vector3(0f, 0.3f, 0f);
            pressF.SetActive(true);
        }

        if (collision.GetComponent<IMainTrigger>() != null) {
            collision.GetComponent<IMainTrigger>().MainTrigger();
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        inTrigger = false;
        triggerObject = null;
        pressF.SetActive(false);

        if (collision.GetComponent<IMainTrigger>() != null) {
            collision.GetComponent<IMainTrigger>().MainTriggerLeave();
        }
    }
}
