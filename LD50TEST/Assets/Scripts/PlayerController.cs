using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] private float movementSpeed;

    

    private void Update() {

        float movement = Input.GetAxisRaw("Horizontal") * movementSpeed * Time.deltaTime;
        transform.position += new Vector3(movement, 0f, 0f);
    }
    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.GetComponent<ITrigger>() != null) {
            collision.GetComponent<ITrigger>().Trigger();
        }
    }
}
