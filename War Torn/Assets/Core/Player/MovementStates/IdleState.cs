using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : MovementBaseState {
    public override void EnterState(MovementManager movementManager) {

    }

    public override void UpdateState(MovementManager movementManager) {
        if (movementManager.direction.magnitude > 0.1f) {
            if (Input.GetKey((KeyCode)GameManager.Controls.run)) {
                movementManager.SwitchState(movementManager.Run);
            } else {
                movementManager.SwitchState(movementManager.Walk);
            }
        }
        if(Input.GetKeyDown((KeyCode)GameManager.Controls.crouch)) {
            movementManager.SwitchState(movementManager.Crouch);
        }
    }
}
