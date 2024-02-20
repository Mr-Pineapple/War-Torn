using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimState : AimBaseState {
    public override void EnterState(CameraAimManager aimStateManager) {
        aimStateManager.animator.SetBool("isAiming", true);
    }

    public override void UpdateState(CameraAimManager aimStateManager) {
        if (Input.GetKeyUp((KeyCode)GameManager.Controls.aim)) {
            aimStateManager.SwitchState(aimStateManager.Hip);
        }
    }
}