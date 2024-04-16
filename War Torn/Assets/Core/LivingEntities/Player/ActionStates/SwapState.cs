using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapState : ActionBaseState
{
    public override void EnterState(ActionStateManager actions) {
        actions.animator.SetTrigger("SwapWeapon");
        actions.lHandIK.weight = 0;
        actions.rHandAim.weight = 0;
    }

    public override void UpdateState(ActionStateManager actions) {

    }
}
