using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour {
    public float moveSpeed = 3;
    [HideInInspector] public Vector3 direction;
    float hzInput, vInput;
    CharacterController controller;

    [SerializeField] float groundYOffset;
    [SerializeField] LayerMask groundMask;
    Vector3 spherePosition;


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

    bool IsGrounded() {
        spherePosition = new Vector3(transform.position.x, transform.position.y - groundYOffset, transform.position.z);
        if (Physics.CheckSphere(spherePosition, controller.radius - 0.05f, groundMask)) {
            return true;
        } else {
            return false;
        }
    }

}
