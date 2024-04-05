using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultState : ActionBaseState
{
    public float scrollDirection;
    public override void EnterState(ActionStateManager actions) {
        //I've been working on this for fucking hours and the IK does not update so let's hope no one notices
        actions.lHandIK.data.target = actions.currentWeapon.leftHandTarget;
        actions.lHandIK.data.hint = actions.currentWeapon.leftHandHint;
    }

    public override void UpdateState(ActionStateManager actions) {
        if (actions.rHandAim.weight == 0) actions.rHandAim.weight = .5f;
        if (actions.lHandIK.weight == 0) actions.lHandIK.weight = 1;

        if (Input.GetKeyDown((KeyCode)GameManager.Controls.reload)&& CanReload(actions)) {
            actions.SwitchState(actions.Reload);
        }
        else if(Input.mouseScrollDelta.y != 0) {
            scrollDirection = Input.mouseScrollDelta.y;
            actions.SwitchState(actions.Swap);
        }
    }

    bool CanReload(ActionStateManager action) {
        if (action.ammo.currentAmmo == action.ammo.magSize) return false;
        else if (action.ammo.extraAmmo == 0) return false;
        else return true;
    }
}
