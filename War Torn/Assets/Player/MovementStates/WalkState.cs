using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : MovementBaseState {
    public override void EnterState(MovementManager movementManager) {
        movementManager.animator.SetBool("Walking", true);
    }

    public override void UpdateState(MovementManager movementManager) {
        if (Input.GetKey(KeyCode.LeftShift)) {
            ExitState(movementManager, movementManager.Run);
        } else if(Input.GetKeyDown(KeyCode.C)) {
            ExitState(movementManager, movementManager.Crouch);
        } else if(movementManager.direction.magnitude < 0.1f) {
            ExitState(movementManager, movementManager.Idle);
        }
        if (movementManager.vInput < 0) movementManager.currentMoveSpeed = movementManager.walkBackSpeed;
        else movementManager.currentMoveSpeed = movementManager.walkSpeed;
    }

    void ExitState(MovementManager movementManager, MovementBaseState state) {
        movementManager.animator.SetBool("Walking", false);
        movementManager.SwitchState(state);
    }
}
