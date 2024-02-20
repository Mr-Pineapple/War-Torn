using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HipFireState : AimBaseState
{
    public override void EnterState(CameraAimManager aimStateManager) {
        aimStateManager.animator.SetBool("isAiming", false);
    }

    public override void UpdateState(CameraAimManager aimStateManager) {
        if(Input.GetKey((KeyCode)GameManager.Controls.aim)) {
            aimStateManager.SwitchState(aimStateManager.Aim);
        }
    }
}
