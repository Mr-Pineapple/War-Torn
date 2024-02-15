using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : MovementBaseState {
    public override void EnterState(MovementManager movementManager) {
        movementManager.animator.SetBool("Running", true);
    }

    public override void UpdateState(MovementManager movementManager) {
        if(Input.GetKeyUp(KeyCode.LeftShift)) {
            ExitState(movementManager, movementManager.Walk);
        } else if(movementManager.direction.magnitude < 0.1f) {
            ExitState(movementManager, movementManager.Idle);
        }

        if (movementManager.vInput < 0) movementManager.currentMoveSpeed = movementManager.runBackSpeed;
        else movementManager.currentMoveSpeed = movementManager.runSpeed;
    }

    void ExitState(MovementManager movementManager, MovementBaseState state) {
        movementManager.animator.SetBool("Running", false);
        movementManager.SwitchState(state);
    }
}
