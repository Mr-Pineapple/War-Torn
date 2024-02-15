using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CrouchState : MovementBaseState {
    public override void EnterState(MovementManager movementManager) {
        movementManager.animator.SetBool("Crouching", true);
    }

    public override void UpdateState(MovementManager movementManager) {
        if(Input.GetKey(KeyCode.LeftShift)) {
            ExitState(movementManager, movementManager.Run);
        } if(Input.GetKeyDown(KeyCode.C)) {
            if(movementManager.direction.magnitude < 0.1f) {
                ExitState(movementManager, movementManager.Idle);
            } else {
                ExitState(movementManager, movementManager.Walk);
            }
        }

        if (movementManager.vInput < 0) movementManager.currentMoveSpeed = movementManager.crouchBackSpeed;
        else movementManager.currentMoveSpeed = movementManager.crouchSpeed;
    }

    void ExitState(MovementManager movementManager, MovementBaseState state) {
        movementManager.animator.SetBool("Crouching", false);
        movementManager.SwitchState(state);
    }
}
