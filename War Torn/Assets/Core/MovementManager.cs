using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour {
    public float moveSpeed = 3;
    [HideInInspector] public Vector3 direction;
    float hzInput, vInput;
    CharacterController controller;

    void Start() {
        controller = GetComponent<CharacterController>();
    }
    void Update() {
            GetDirectionAndMove();
    }

    void GetDirectionAndMove() {
        hzInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        direction = transform.forward * vInput + transform.right * hzInput;
        controller.Move(direction * moveSpeed * Time.deltaTime);
    }

}
