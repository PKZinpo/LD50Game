using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] private float mainMovementSpeed;
    [SerializeField] private float kidMovementSpeed;
    [SerializeField] private GameObject kid;
    [SerializeField] private GameObject dad;
    [SerializeField] private GameObject finalPosition;

    private GameObject currentSprite;
    private Animator currentAnimator;
    private bool toRight = false;
    private bool inTrigger = false;
    private ITrigger triggerObject;
    private GameObject pressF;
    private bool failed = false;
    private int fails = 0;

    private void Awake() {
        pressF = GameObject.FindGameObjectWithTag("PressF");
        pressF.SetActive(false);

        if (kid.activeSelf) {
            currentSprite = kid;
            currentAnimator = kid.GetComponent<Animator>();
        }
        else {
            currentSprite = dad;
            currentAnimator = dad.GetComponent<Animator>();
        }
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
                
        if (GameManager.isInFinal) movement = mainMovementSpeed * Time.deltaTime;
        transform.position += new Vector3(movement, 0f, 0f);


        if (inTrigger && Input.GetKeyDown(KeyCode.F)) {
            triggerObject.Trigger();
            pressF.SetActive(false);
            movement = 0f;
        }

        if (GameManager.isInFinal) return;
        if (movement > 0f && !toRight) {
            FlipPlayer();
        }
        else if (movement < 0f && toRight) {
            FlipPlayer();
        }
        if (!GameManager.isInFinal && !GameManager.ending) currentAnimator.SetBool("IsWalking", movement != 0f);
    }
    public void ToFinal() {
        ChangePlayer();
        transform.position = finalPosition.transform.position;
    }
    public void ChangePlayer() {
        kid.gameObject.SetActive(false);
        dad.gameObject.SetActive(true);
        currentSprite = dad;
        currentAnimator = dad.GetComponent<Animator>();
    }
    private void FlipPlayer() {
        toRight = !toRight;
        currentSprite.transform.localScale = new Vector3(-1f * currentSprite.transform.localScale.x, currentSprite.transform.localScale.y, currentSprite.transform.localScale.z);
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
    public void DoAction() {
        currentAnimator.SetTrigger("Action");
    }
    public void IsActionFailed(bool action) {
        failed = action;
    }
    public void TriggerTrip() {
        if (failed) {
            currentAnimator.SetTrigger("Fail");
            fails++;
        }
        else {
            currentAnimator.SetTrigger("Success");
        }
        FailsCheck();
    }
    private void FailsCheck() {
        if (fails >= 1) {
            currentAnimator.SetTrigger("Die");
        }
    }
    public void Restart() {
        GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<MainCanvasManager>().FadeIn(true);
        fails = 0;
    }
    public void RestartAnimator() {
        currentAnimator.SetTrigger("Restart");
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
