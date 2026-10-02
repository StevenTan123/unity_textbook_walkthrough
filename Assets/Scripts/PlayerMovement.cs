using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour {
    public float speed;
    public float rotationSpeed;
    private Vector2 movementValue;
    private float lookValue;
    private Rigidbody rigidBody;

    private void Awake() {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        rigidBody = GetComponent<Rigidbody>();
    }

    private void OnMove(InputValue value) {
        movementValue = value.Get<Vector2>() * speed;
    }

    private void OnLook(InputValue value) {
        lookValue = value.Get<Vector2>().x * rotationSpeed;
    }

    // Update is called once per frame
    void Update() {
        rigidBody.AddRelativeForce(movementValue.x * Time.deltaTime, 0, movementValue.y * Time.deltaTime);
        rigidBody.AddRelativeTorque(0, lookValue * Time.deltaTime, 0);
    }
}
